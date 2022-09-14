using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _02_SocketTCP_Server
{
    // Definiamo firma della procedura di Evento datiRicevutiEvent
    public delegate void datiRicevutiEventHandler(clsMessage msg);
    // Definiamo firma della procedura di Evento erroreConnessioneEvent
    public delegate void erroreConnessioneEventHandler(string msg);
    // Definiamo firma della procedura di Evento statoConnessioneEvent
    public delegate void statoConnessioneEventHandler(string msg); 

    public class clsTCPServer
    {
        const int MAX_BYTE = 1024; // lunghezza max buffer
        const int MAX_CONN = 20; // max connessione client accettati
        private Socket socketID;
        private EndPoint endPoint; // socket (ip, porta) associato al Server
        private Thread threadAscolto;
        private volatile bool threadRun = true;
        private Socket connID;
        // Definiamo puntatori agli eventi 
        public event datiRicevutiEventHandler datiRicevutiEvent; 
        public event erroreConnessioneEventHandler erroreConnessioneEvent;
        public event statoConnessioneEventHandler statoConnessioneEvent;

        public clsTCPServer(IPAddress ip, int porta)
        {
            socketID = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            endPoint = new IPEndPoint(ip, porta);

            socketID.SendTimeout = 10000; // Impostazione timeout per il tempo di Invio
            socketID.ReceiveTimeout = 10000; // Impostazione timeout per il tempo di Ricezione

            socketID.Bind(endPoint); // Mettiamo Server in ascolto su porta specifica
            // max lunghezza coda connessioni accettate prima di restituire "Server Occupato" 
            socketID.Listen(MAX_CONN);
        }

        public void avvia()
        {
            if (threadAscolto == null)
            {
                // Instanzio un nuovo Thread 
                threadAscolto = new Thread(ricevi);
                // Avvio il Thread 
                threadAscolto.Start();
                // Aspetto finchè il Thread non è avviato  
                while (!(threadAscolto.IsAlive)) ;
            }
        }
        public void invia(string msg)
        {
            try
            {
                byte[] bufferTX;
                // Serializzo la Stringa ricevuta 
                bufferTX = Encoding.ASCII.GetBytes(msg);
                // Invio la Stringa ricevuta all' endPoint 
                connID.Send(bufferTX, bufferTX.Length, 0);
            }
            catch (SocketException ex)
            {
                erroreConnessioneEvent(ex.Message);
            }
        }
        private void ricevi()
        {
            int nBytesRicevuti = 0;
            string msg;
            byte[] bufferRX;
            bufferRX = new byte[MAX_BYTE];

            bool esci;
            int tm;
            while (threadRun)
            {
                try
                {
                    // Il socket principale (sockID) non attende l'arrivo di messaggi 
                    // ma richieste di connessione. 
                    // Ogni volta che arriva una richiesta di connessione
                    // il server si clona con un nuovo thread restituendo dentro connID un socket DEDICATO
                    // alla gestione di quella connessione, mentre sockID continua a mettere in coda ulteriori connessioni
                    // finchè non chiudo connID la connessione col client resta attiva
                    if (connID == null)  //se null vuol dire sono alla prima connessione o il client precedente si è disconnesso
                    {
                        connID = socketID.Accept();
                        statoConnessioneEvent("Connesso");
                    }

                    //nBytesRicevuti = connID.Receive(bufferRX, maxBYTE, 0);
                    //// Converte il Vettore di Byte BufferRx in una Stringa 
                    //msg = Encoding.ASCII.GetString(bufferRX, 0, nBytesRicevuti);

                    // ricevo byte fino a quando non ho <EOF>
                    esci = false;
                    msg = null;
                    while (!esci && connID.Connected)
                    {
                        tm = connID.ReceiveTimeout;
                        bufferRX = new byte[MAX_BYTE];
                        nBytesRicevuti = connID.Receive(bufferRX);
                        msg += Encoding.ASCII.GetString(bufferRX, 0, nBytesRicevuti);
                        if ((msg.IndexOf("<EOF>") > -1) || (nBytesRicevuti == 0))
                        {
                            esci = true;
                        }
                    }
                    if (nBytesRicevuti > 0)
                    {
                        //tolgo <EOF>
                        msg = msg.Substring(0, msg.Length - 5);
                        // Genero evento per Visualizzare i Dati ricevuti 
                        datiRicevutiEvent(messaggio(msg));
                    }
                    else
                        chiudiConnessione();  //quando chiudo la connessione dal client mi va in loop e contunua a ricevere 0 byte
                }
                catch (SocketException ex)
                {
                    if (ex.ErrorCode != 10004) //ignoro errore generato quando termino il thread
                    {
                        erroreConnessioneEvent(ex.Message);
                        //se ho un eccezione chiudo il socket attualmente aperto e ritorno in ascolto
                        chiudiConnessione();
                    }
                }
            }
        }
        public void chiudiConnessione()
        {
            try
            {
                //chiudo la connessione con il client,.
                //così adesso vengono serviti eventuali altri client in coda
                connID.Shutdown(SocketShutdown.Both);
                connID.Close();
                connID = null;
                statoConnessioneEvent("Disconnesso");
            }
            catch (SocketException ex)
            {
                erroreConnessioneEvent(ex.Message);
            }
        }
        public void termina()
        {
            // Chiudo il Socket 
            socketID.Close();
            // Arresto il Thread 
            threadRun = false;
            //if (threadAscolta != null)
            //    try
            //    {
            //        threadAscolta.Abort();
            //    }
            //    catch (Exception ex)
            //    { }
        }

        private clsMessage messaggio(string msg)
        {
            clsMessage m = new clsMessage();
            m.Ip = ((IPEndPoint)connID.RemoteEndPoint).Address.ToString();
            m.Port = ((IPEndPoint)connID.RemoteEndPoint).Port.ToString();
            m.Messaggio = msg;
            return m;
        }
    }
}
