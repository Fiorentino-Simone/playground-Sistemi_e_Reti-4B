using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Ese02_Socket_TCP_Client
{
    public delegate void erroreConnectionEventHandler(string msg);

    internal class clsTCPClient
    {
        private const int MAX_BYTE = 1024;
        private Socket socketID; //socket principale
        private EndPoint endPoint; //lavora con ip e porta
        
        public event erroreConnectionEventHandler erroreConnessioneEvent;

        public clsTCPClient(
            IPAddress ip,
            int port)
        {
            socketID = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socketID.SendTimeout = 10000;
            socketID.ReceiveTimeout = 10000;
            //endpoint 
            endPoint = new IPEndPoint(ip, port);
        }

        public void Connetti()
        {
            try
            {
                socketID.Connect(endPoint);
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
                byte[] bufferTx;
                msg += "<EOF>"; //inserisco il carattere finale senno il server va in loop
                //Serializzo e invio
                bufferTx = Encoding.UTF8.GetBytes(msg);
                socketID.Send(bufferTx, bufferTx.Length, SocketFlags.None);

            }
            catch (SocketException ex)
            {
                erroreConnessioneEvent(ex.Message);
            }
        }


        public clsMessage ricevi()
        {
            int nByteRicevuti;
            string msg;
            byte[] bufferRx;

            try
            {
                bufferRx = new byte[MAX_BYTE];
                nByteRicevuti = socketID.Receive(bufferRx, MAX_BYTE, SocketFlags.None);
                //deserializzo
                msg = Encoding.UTF8.GetString(bufferRx);
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
            clsMessage clsMessage = new clsMessage();
            clsMessage.Messaggio = endP[2];
            clsMessage.Port = endP[0];
            clsMessage.Ip = endP[1];
            return clsMessage;
        }

        public void Disconnetti()
        {
            //chiude la connessione
            try
            {
                socketID.Shutdown(SocketShutdown.Both);
                socketID.Close();
            }
            catch (SocketException ex)
            {
                erroreConnessioneEvent(ex.Message);
            }
        }
    }
}
