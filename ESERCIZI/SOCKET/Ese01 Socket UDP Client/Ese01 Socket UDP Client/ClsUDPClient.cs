using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Ese01_Socket_UDP_Client
{
    public class ClsUDPClient
    {
        private const int MAX_BYTE = 1024;
        private Socket socketID;
        private EndPoint endPointServer;
        
        public ClsUDPClient(
            IPAddress ipServer,
            int portServer)
        {
            socketID = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            endPointServer = new IPEndPoint(ipServer, portServer);
        }

        public void invia(clsMessage clsMessage)
        {
            string messaggio = clsMessage.toCsv();
            byte[] bufferTx; //buffer di trasmissione

            bufferTx = Encoding.ASCII.GetBytes(messaggio);
            socketID.SendTo(bufferTx, bufferTx.Length, SocketFlags.None, endPointServer); //apriamo, accediamo e inviamo al server
        }


    }
}
