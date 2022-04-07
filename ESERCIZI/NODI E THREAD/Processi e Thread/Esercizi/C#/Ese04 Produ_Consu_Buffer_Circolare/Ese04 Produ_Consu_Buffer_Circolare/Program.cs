///////////////////////////////////////////////////////////////////////////FIORENTINO SIMONE 4^B /////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Ese04_Produ_Consu_Buffer_Circolare
{
    class Program
    {
        const int numDati = 10; //
        const int tempoProduzione = 200; // [ms]
        const int tempoConsumo = 500; // [ms]
        const int MAX_DIM = 10; 
        static SemaphoreSlim vuoto = new SemaphoreSlim(1);
        static SemaphoreSlim pieno = new SemaphoreSlim(0);
        static SemaphoreSlim space = new SemaphoreSlim(MAX_DIM); //semaforo che contiene il numero di spazi
        static int[] buffer = new int[MAX_DIM];
        static Random rnd = new Random(); 

        static void Main(string[] args)
        {

            //CONSEGNA: 

            /*
             *  Un produttore, un consumatore, buffer circolare: 
                Partendo dall’esercitazione precedente sviluppare una soluzione gestendo un buffer circolare =>
                static int[] buffer = new int[dimBuffer];
            */

            Thread produttore = new Thread(Produttore);
            Thread consumatore = new Thread(Consumatore);
            Console.WriteLine("INIZIO PROGRAMMA: " + DateTime.Now.ToString("hh:mm:ss,fff"));

            produttore.Start();
            consumatore.Start();
            //Parallel.Invoke(Produttore, Consumatore); //la procedura invoke permette di assegnare le funzioni a thread singoli, quindi le esegue parallelamente.

            //li riuniamo, bloccando il thread
            produttore.Join();
            consumatore.Join();


            Console.WriteLine("FINE PROGRAMMA: " + DateTime.Now.ToString("hh:mm:ss,fff"));
            Console.ReadKey();
        }

        static void Produttore()
        {
            int i = 0;
            int put = 0; //indice interno usato per aggiornare il buffer dopo aver prodotto il messaggio
            while (i != numDati)
            {
                space.Wait();
                vuoto.Wait();
                // INIZIO SEZIONE CRITICA
                buffer[put] = rnd.Next(1, 500);
                Console.WriteLine("Messaggio creato, tempo: " + DateTime.Now.ToString("hh:mm:ss:fff") + "): " + buffer[put].ToString());
                put = (put + 1) % MAX_DIM; //aggiorniamo l'indice
                vuoto.Release();
                pieno.Release();
                //FINE SEZIONE CRITICA
                Thread.Sleep(tempoProduzione); //impostiamo la sleep
                i++;
            }
        }

        static void Consumatore()
        {
            int i = 0;
            int get = 0; //indice interno usato per aggiornare il buffer dopo aver consumato il messaggio
            while (i != numDati)
            {
                pieno.Wait();
                vuoto.Wait();
                // INIZIO SEZIONE CRITICA
                Console.WriteLine(" - Messaggio ricevuto, tempo: " + DateTime.Now.ToString("hh:mm:ss:fff") + "): " + buffer[get].ToString());
                get = (get + 1) % MAX_DIM; //aggiorniamo l'indice
                vuoto.Release();
                space.Release();
                //FINE SEZIONE CRITICA
                Thread.Sleep(tempoConsumo); //impostiamo la sleep
                i++;
            }
        }
    }
}
