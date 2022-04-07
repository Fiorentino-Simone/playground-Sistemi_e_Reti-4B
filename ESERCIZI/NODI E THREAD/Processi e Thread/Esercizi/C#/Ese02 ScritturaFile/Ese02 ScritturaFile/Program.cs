using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace Ese02_ScritturaFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(eseguiScrittura);
            Thread.CurrentThread.Name = "_main_";
            StreamWriter sw;
            

            Console.WriteLine("INIZIO PROGRAMMA: " + DateTime.Now.ToString("hh:mm:ss,fff"));
            t1.Start();
            //se vogliamo scrivere su file non c'è bisogno di gestire la sezione critica con i thread
            //scrittura su secondo file
            sw = new StreamWriter("file_main.txt");
            for (int i = 0; i < 100000000; i++)
                sw.Write("+");
            sw.Close();

            Console.WriteLine("\nFINE PROGRAMMA: " + DateTime.Now.ToString("hh:mm:ss,fff")); //il processo principale si ferma
            Console.ReadKey();

            Process.Start("file_main.txt"); //anche se non sono molto usati nei linguaggio ad alto livello, i processi vengono lo stesso utilizzati per aprire dei file tramite l'applicazione predefinita. Per aprire file specifici bisogna passare un path
            //anche programmi tipo: Process.Start("WINWORD.exe");
            Process.Start("file_thread.txt"); 
        }

        private static void eseguiScrittura()
        {
            Console.WriteLine("INIZIO THREAD: " + DateTime.Now.ToString("hh:mm:ss,fff"));
            Thread.Sleep(1000); //aspetta un secondo e poi parte

            //scrittura su secondo file
            StreamWriter sw = new StreamWriter("file_thread.txt");
            for (int i = 0; i < 100000000; i++)
                sw.Write("*");
            sw.Close();
            Console.WriteLine("FINE THREAD: " + DateTime.Now.ToString("hh:mm:ss,fff"));

        }
    }
}
