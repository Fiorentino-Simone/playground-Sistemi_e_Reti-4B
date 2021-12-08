//////////////////////////////////////////////////////////////FIORENTINO SIMONE 4^B //////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Ese05_Produ_Consu_Singolo
{
    class Program
    {
        const int numDati = 10; //
        const int tempoProduzione = 200; // [ms]
        const int tempoConsumo = 500; // [ms]
        static SemaphoreSlim vuoto = new SemaphoreSlim(1);
        static SemaphoreSlim pieno = new SemaphoreSlim(0);
        static int buffer;
        static Random rnd = new Random(); //utilizzato per generare randomicamente il valore nel buffer
        static void Main(string[] args)
        {
            //CONSEGNA: 

            /*
             * Sviluppare un programma C# (Console .NET Framework) che gestisca la produzione (scrittura) e
                consumo (lettura/modifica) del contenuto di una variabile (buffer)
                Massimizzare l’efficienza del programma utilizzando opportunamente l’oggetto Thread e, se si
                ritiene opportuno, l’oggetto Parallel.
                Nello specifico, all’avvio del programma avverrà una prima fase di ‘produzione’ dove,
                ipoteticamente, verrà scritto all’interno del buffer (per un numero limitato di iterazioni) un valore
                generato casualmente.
                Sarà compito del consumatore, leggere il contenuto e, solo successivamente, dare la possibilità
                al produttore di crearne uno nuovo.
                Gestire la mutua esclusione utilizzando i semafori necessari (oggetto SemaphoreSlim).
                Ovviamente, ogni qual volta viene eseguita una operazione di produzione/consumo, i rispettivi
                thread attendono qualche istante (Sleep).
                PER VERIFICARE L’EFFICIENZA DEL CODICE STAMPARE OGNI PASSAGGIO DI
                PRODUZIONE/CONSUMO. INCLUDENDO ANCHE IL TEMPO DI ELABORAZIONE DEL THREAD
                PRINCIPALE (Main).
            */

            Thread.CurrentThread.Name = "_main_";
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
            Console.WriteLine("Buffer: " + buffer.ToString());
            Console.ReadKey();
        }

        static void Produttore()
        {
            int i = 0;
            while (i < numDati)
            {
                vuoto.Wait();
                // INIZIO SEZIONE CRITICA
                buffer = rnd.Next(1, 500);
                Console.Write("Messaggio creato, tempo: " + DateTime.Now.ToString("hh:mm:ss:fff") + "): " + buffer);
                pieno.Release();
                //FINE SEZIONE CRITICA
                Thread.Sleep(tempoProduzione); //impostiamo la sleep
                i++;
            }
        }

        static void Consumatore()
        {
            int i = 0;
            while (i < numDati)
            {
                pieno.Wait();
                // INIZIO SEZIONE CRITICA
                Console.WriteLine(" - Messaggio ricevuto, tempo: " + DateTime.Now.ToString("hh:mm:ss:fff") + "): " + buffer);
                vuoto.Release();
                //FINE SEZIONE CRITICA
                Thread.Sleep(tempoConsumo); //impostiamo la sleep
                i++;
            }
        }
    }
}
