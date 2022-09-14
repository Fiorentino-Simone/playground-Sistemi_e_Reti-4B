using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _02_SocketTCP_Server
{
    public class clsAddress
    {
        public static List<IPAddress> ipList; 

        static clsAddress()
        {
            ipList = new List<IPAddress>();
        }
        public static void findIP()
        {
            IPHostEntry hostInfo; // Recuperare le informazioni dell'HOST 
            // Aggiungo IP Localhost 
            ipList.Add(IPAddress.Parse("127.0.0.1")); 
            hostInfo = Dns.GetHostEntry(Dns.GetHostName());
            foreach(IPAddress ip in hostInfo.AddressList)
            {
                // Analizzo indirizzo ip e se IPv4 lo aggiungo alla mia List
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    ipList.Add(ip);
            }
        }

        public static IPAddress findIP(string host)
        {
            IPAddress ip = null;
            IPHostEntry hostInfo; 
            // Verifico se l'host è un indirizzo valido 
            if (!(IPAddress.TryParse(host, out ip)))
            {
                hostInfo = Dns.GetHostEntry(host); 
                foreach(IPAddress ip1 in hostInfo.AddressList)
                {
                    if(ip1.AddressFamily == AddressFamily.InterNetwork)
                    {
                        ip = ip1;
                        break;
                    }
                }
            }
            return ip; 
        }
    }
}
