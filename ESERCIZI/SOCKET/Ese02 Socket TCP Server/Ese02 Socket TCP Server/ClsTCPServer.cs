using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ese02_Socket_TCP_Server
{
    //Definiamo firma procedura di Eventi datiRicevutiHandler
    public delegate void datiRicevutiHandler(clsMessage clsMess);

    //Definiamo firma procedura di Evento erroreConnessioneEvent --> essendo TCP (ad esempio ho la porta oppure l'indirizzo IP sbagliato)
    public delegate void erroreConnessioneEventHandler(string msg);

    //Definiamo lo status della connessione siccome potrebbe avere un calo. Essendo con un protocollo TCP dobbiamo controllarlo
    public delegate void statoConnessioneEventHandler(string msg);

    internal class ClsTCPServer
    {
        const int MAX_BYTE = 1024; //lunghezza max buffer
        const int MAX_CONN = 20; //max numero di connessioni client accettati
        private Socket socketID;
        private EndPoint endPoint; //socket (ip, porta) associato al server
        private Thread threadAscolto;
        private volatile bool threadRun = true;
        private Socket connID; 

        public event datiRicevutiHandler datiRicevutiEvent;
        public event erroreConnessioneEventHandler erroreConnessioneEvent;   
        public event statoConnessioneEventHandler statoConnessioneEvent; 
    
        public ClsTCPServer(IPAddress ip, int porta)
        {
            socketID = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            endPoint = new IPEndPoint(ip, porta);

            socketID.SendTimeout = 10000; //assegniamo il timeout di invio e di ricezione 
            socketID.ReceiveTimeout = 10000;

            socketID.Bind(endPoint); //mettiamo in ascolto su porta specifica
            socketID.Listen(MAX_CONN); // alla funzione listen specifichiamo il numero massimo di connessioni accettate prima di restituire "Server Occupato"
        }

        public void avvia()
        {
            if (threadAscolto == null)
            {
                threadAscolto = new Thread(ricevi);
                threadAscolto.Start();
                while (!threadAscolto.IsAlive) ;//iteriamo all'infinito finche thread non è avviato
            }
        }

        private void termina()
        {
            socketID.Close();   
            threadRun = false;
        }

        public void invia(string msg)
        {
            try
            {
                byte[] bufferTx;
                bufferTx = Encoding.UTF8.GetBytes(msg);
                connID.Send(bufferTx, bufferTx.Length, SocketFlags.None);
            }
            catch (SocketException ex)
            {
                erroreConnessioneEvent(ex.Message);
            }
        }

        private void ricevi()
        {
            byte[] bufferRx = new byte[MAX_BYTE];
            string msg;
            int nByteRicevuti = 0;
            bool esci; 

            while (threadRun)
            {
                try
                {
                    if (connID == null)
                    {
                        //socketID --> si pone in ascolto, però quando riceve una richiesta di connessione passa tutto a connId
                        connID = socketID.Accept(); //va ad instanziare connId, ogni volta che abbiamo una richiesta diversa
                        statoConnessioneEvent("Connesso");
                    }
                }
                catch (Exception ex)
                {
                    erroreConnessioneEvent(ex.Message);
                    chiudiConnessione();
                }
            }
        }

        public void chiudiConnessione()
        {
            try
            {
                connID.Shutdown(SocketShutdown.Both);
                connID.Close();
                connID = null; //rimuovo l'istanza
                statoConnessioneEvent("Disconnesso");
            }
            catch (Exception ex)
            {
                erroreConnessioneEvent(ex.Message);
            }
        }
    }

}
