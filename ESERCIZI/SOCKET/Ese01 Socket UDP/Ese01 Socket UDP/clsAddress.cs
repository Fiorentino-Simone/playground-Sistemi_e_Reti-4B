using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ese01_Socket_UDP
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
            IPHostEntry hostInfo; //informazioni che si recuperano dell'HOST

            //aggiungiamo manualmente 127.0.0.1
            ipList.Add(IPAddress.Parse("127.0.0.1"));
            hostInfo = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in hostInfo.AddressList)
            {
                //analizzo indirizzo ip e se IPv4 lo aggiungo alla mia lista
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    ipList.Add(ip);
            } 
        }
    }
}
