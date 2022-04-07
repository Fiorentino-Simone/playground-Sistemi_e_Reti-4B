using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading; //ci permette di usare i thread

namespace Ese01_Thread_Console
{
    class Program
    {
        static void Main(string[] args) //quando si preme avvia mi attiva il thread Main
        {
            Thread t1 = new Thread(eseguiLavoro); //gli passiamo direttamente al costruttore la funzione che deve eseguire
            Thread.CurrentThread.Name = "_main_"; //assegniamo un nome al thread attuale.
            t1.Name = "_t1_";

            Console.WriteLine("INIZIO PROGRAMMA: "+DateTime.Now.ToString("hh:mm:ss,fff"));

            /*METODI THREAD*/
            t1.Start(); //istanzia il thread e fa partire la procedura. 
            //la Console è l'oggetto che entrambi utilizzano, quindi bisogna gestire l'accesso alla sezione critica.

            //t1.Join(); //usando questa procedura il thread Main aspetta che la procedura di t1 finisca, però si perde il concetto di parallelismo, siccome i tempi aumentano.                   

            //t1.Suspend(); //sospende il thread.
            //t1.Resume(); //riprende il thread
            
            /*STAMPE*/
            for (int i = 0; i < 20; i++)
                Console.Write("+");
            
            Console.WriteLine("\nFINE PROGRAMMA: " + DateTime.Now.ToString("hh:mm:ss,fff")); //il processo principale si ferma
            Console.ReadKey();
        }

        private static void eseguiLavoro()
        {
            Console.WriteLine("LAVORO THREAD" + Thread.CurrentThread.Name);
            for (int i = 0; i < 20; i++)
                Console.Write("*");
        }
    }
}
