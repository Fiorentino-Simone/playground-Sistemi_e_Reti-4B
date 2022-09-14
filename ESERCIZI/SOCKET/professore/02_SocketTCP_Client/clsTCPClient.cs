using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _02_SocketTCP_Client
{
    public delegate void erroreConnessioneEventHandler(string msg); 

    public class clsTCPClient
    {
        const int MAX_BYTE = 1024;
        private Socket socketID; // Socket principale 
        private EndPoint endPoint;  // endPoint(ip, port) associato al Server 
        public event erroreConnessioneEventHandler erroreConnessioneEvent;

        public clsTCPClient(IPAddress ip, int porta)
        {
            // istanza socket 
            socketID = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // timeout 
            socketID.SendTimeout = 10000;
            socketID.ReceiveTimeout = 10000;
            // endPoint 
            endPoint = new IPEndPoint(ip, porta); 
        }
        public void connetti()
        {
            try
            {
                // endPoint in questo momento contiene coordinate del server (assegnate al momento dell'istanza costrutture) 
                socketID.Connect(endPoint);
            }
            catch (SocketException ex)
            {
                erroreConnessioneEvent(ex.Message);
            }
        }
        public void disconnetti()
        {
            try
            {
                socketID.Shutdown(SocketShutdown.Both); // Disconnetto sia per ricezione che invio 
                socketID.Close();
            }
            catch (SocketException ex)
            {
                erroreConnessioneEvent(ex.Message);
            }
        }
        public void invia(string msg)
        {
            try
            {
                // Aggiungo EOF alla stringa da inviare
                msg += "<EOF>";
                byte[] bufferTx;
                // Serializzo la Stringa ricevuta
                bufferTx = Encoding.ASCII.GetBytes(msg);
                // Invio strnga ricevuta all'endPoint
                socketID.Send(bufferTx, bufferTx.Length, SocketFlags.None);
            }
            catch (SocketException ex)
            {
                erroreConnessioneEvent(ex.Message);
            }
        }
        public clsMessage ricevi()
        {
            int nBytesRicevuti;
            string msg;
            byte[] bufferRx;

            try
            {
                bufferRx = new byte[MAX_BYTE];
                // Riceve i dati nel buffer e termina (eventuali dati in più rispetto a MAX_BYTE sono troncati) 
                nBytesRicevuti = socketID.Receive(bufferRx, MAX_BYTE, SocketFlags.None);
                // Converte il vettore di byte bufferRx in una stringa
                msg = Encoding.ASCII.GetString(bufferRx);
            }
            catch (SocketException ex)
            {
                erroreConnessioneEvent(ex.Message);
                msg = "";
            }
            return messaggio(msg);
        }
        private clsMessage messaggio(string msg)
        {
            string[] endP = endPoint.ToString().Split(':');
            clsMessage clsMsg = new clsMessage();
            clsMsg.Ip = endP[0];
            clsMsg.Port = endP[1];
            clsMsg.Messaggio = msg;
            return clsMsg;
        }
    }
}
