using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace Ese02_Socket_TCP_Server
{
    public class clsAddress
    {
        public static List<IPAddress> ipList;

        static clsAddress()
        {
            ipList = new List<IPAddress>();
        }

        public static void FindIp()
        {
            //va a trovare gli indirizzi IP disponibili di tutte le nostre schede di rete

            IPHostEntry hostInfo; //informazioni che si recuperano dell'HOST

            //aggiungiamo manualmente 127.0.0.1
            ipList.Add(IPAddress.Parse("127.0.0.1"));
            hostInfo = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in hostInfo.AddressList)
            {
                //analizzo indirizzo ip e se IPv4 lo aggiungo alla mia lista
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    ipList.Add(ip);
            } 
        }

        public static IPAddress FindIp(string host)
        {
            IPAddress ip = null;
            IPHostEntry hostInfo; 
            //Verifico se l'host è un indirizzo valido
            if (!(IPAddress.TryParse(host, out ip))) //serve l'out nella variabile di destinazione
            {
                hostInfo = Dns.GetHostEntry(host);
                foreach (IPAddress item in hostInfo.AddressList)
                {
                    if (item.AddressFamily == AddressFamily.InterNetwork)
                    {
                        ip = item;
                    }
                }
            }
            return ip;
        }
    }
}
