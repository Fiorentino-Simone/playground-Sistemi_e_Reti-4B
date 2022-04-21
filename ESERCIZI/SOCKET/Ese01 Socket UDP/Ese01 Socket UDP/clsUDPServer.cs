using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ese01_Socket_UDP
{
    public delegate void datiRicevutiEventHandler(clsMessage messaggio); //firma del metodo, evento per i dati 
    internal class clsUDPServer
    {
        private const int MAX_BYTES = 1024;
        private Socket socketID; //per instaurare la connessione serve utilizzare un oggetto socket
        private EndPoint endPointServer; //interfaccia (porta) di trasmissione dei dati del server
        private EndPoint endPointClient; //interfaccia del client
        private Thread threadAscolto; //thread che va ad ascoltare in quella specifica porta
        private volatile bool running = true;

        public event datiRicevutiEventHandler datiRicevutiEvent;

        public clsUDPServer(
            IPAddress ip, 
            int port)
        {
            socketID = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Dgram, //Dgram per quelli UDP, senno stream
                ProtocolType.Udp);

            endPointServer = new IPEndPoint(ip, port);

            //attiviamo il socket su quella porta
            socketID.Bind(endPointServer); 
        }

        public void avviaAscolto()
        {
            if (threadAscolto == null)
            {
                threadAscolto = new Thread(new ThreadStart(ricevi));
                threadAscolto.Start();
                while (!threadAscolto.IsAlive) ; //rimaniamo bloccati su questa linea finche non arriva un false
                //istruzione analoga alla join
            }
        }

        private void ricevi()
        {
            int nByteRicevuti; //esso è uno stream di byte
            string msg;
            byte[] bufferRx; //buffer dei dati di risposta
            clsMessage message;

            bufferRx = new byte[MAX_BYTES];
            endPointClient = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5555);

            //quando stoppiamo il server andiamo a terminare la ricezione del thread 
            while (running)
            {
                //si pona in ascolto sull'endPoint
                try
                {
                    //sempre usare una trycatch perchè lavoriamo con un protocollo TCP
                    nByteRicevuti = socketID.ReceiveFrom(bufferRx, MAX_BYTES, SocketFlags.None, ref endPointClient);
                    msg = Encoding.UTF8.GetString(bufferRx); //conversione del messaggio in stringa
                    message = new clsMessage(msg, ';');
                    
                    message.Ip = (endPointClient as IPEndPoint).Address.ToString();
                    message.Port = (endPointClient as IPEndPoint).Port.ToString();

                    datiRicevutiEvent(message);
                }
                catch (SocketException ex)
                {
                    Console.WriteLine(ex.ErrorCode + " : " + ex.Message);
                }
            }
        }

        public void chiudi()
        {
            running = false;
            socketID.Close();
        }
    }
}
