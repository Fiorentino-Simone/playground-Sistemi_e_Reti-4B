using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ese01_Socket_UDP_Client
{
    public class clsMessage
    {
        private string ip;
        private string port;
        private string messaggio;

        //PROPERTY
        public string Ip
        {
            get { return ip; }
            set { ip = value; }
        }

        public string Port
        {
            get { return port; }
            set { port = value; }
        }

        public string Messaggio
        {
            get { return messaggio; }
            set { messaggio = value; }
        }

        public clsMessage(
            string ip = "",
            string port = "", 
            string msg = "")
        {
            this.ip = ip;
            this.port = port;
            this.messaggio = msg;
        }

        public clsMessage(
            string csv,
            char separator = ';')
        {
            fromCsv(csv,separator);
        }

        private void fromCsv(string csv, char separator)
        {
            string[] param = csv.Split(separator);
            this.ip = param[0];
            this.port = param[1];
            this.messaggio = param[2];
        }

        public string toCsv(char separator = ';')
        {
            return ip + separator + port + separator + messaggio;
        }

        public string[] toArray()
        {
            //restituiamo un vettore il quale verrà inserito nella dgv
            return new string[]
            {
                this.ip,
                this.port,
                this.messaggio
            };
        }
    }
}
