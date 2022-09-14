using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_SocketTCP_Server
{
    public class clsMessage
    {
        private string ip;
        private string port;
        private string messaggio;

        public clsMessage(string _ip = "", string _port = "", string _msg = "")
        {
            this.ip = _ip;
            this.port = _port;
            this.messaggio = _msg; 
        }
        public clsMessage(string csv, char separatore = ';')
        {
            fromCSV(csv, separatore);
        }
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

        private void fromCSV(string csv, char separatore)
        {
            string[] param = csv.Split(separatore); 
            this.ip = param[0];
            this.port = param[1];
            this.messaggio = param[2];
        }
        public string toCSV(char separatore = ';')
        {
            return ip + separatore + port + separatore + messaggio;
        }
        public string[] toArray()
        {
            return new string[]  { ip, port, messaggio }; 
        }
    }
}
