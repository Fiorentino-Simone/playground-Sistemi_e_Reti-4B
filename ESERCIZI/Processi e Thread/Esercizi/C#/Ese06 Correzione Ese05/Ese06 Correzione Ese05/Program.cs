using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace Ese06_Correzione_Ese05
{
    class Program
    {
        const int N_DATI = 10;
        const int TEMPO_PRODUZIONE = 200;
        const int TEMPO_CONSUMA = 500;

        static SemaphoreSlim vuoto = new SemaphoreSlim(1);
        static SemaphoreSlim pieno = new SemaphoreSlim(0);
        static int buffer;
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("Un produttore, un consumatore, un buffer singolo: ");
            sw.Start(); //inizia il tempo

            Parallel.Invoke(
                () => produci (1,N_DATI),
                () => consuma (N_DATI)
            ); //andiamo a creare direttamente un instanza a cui definiamo dei parametri (procedura chiamata action)

            sw.Stop();
            Console.WriteLine("Elaborazione terminata. Tempo totale trascorso: " + sw.ElapsedMilliseconds + " ms");
            Console.ReadKey();
        }

        private static void produci(int inizio, int fine) //passiamo un numero definito di iterazioni
        {
            //bisogna far produrre il messaggio e inserirlo nel buffer
            Stopwatch swProduttore = new Stopwatch();
            swProduttore.Start();

            int threadId; //inizializzo una varibile che mi dice quale thread sta modificando o meno la risorsa critica
            int prod; //valore generico

            threadId = Thread.CurrentThread.ManagedThreadId; //ci restituisce l'id generico del thread
            for (int i = inizio; i <= fine; i++)
            {
                //1. INDIVIDUARE LA RISORSA CRITICA: in questo caso è il buffer
                //2. CAPIRE QUALI SONO LE GESTIONI LEGATA ALLA RISORSA CRITICA: minimizzare le linee di codice

                prod = rnd.Next(1, 11);
                Thread.Sleep(TEMPO_PRODUZIONE);
                vuoto.Wait(); //ROSSO A VUOTO
                //INIZIO SEZIONE CRITICA
                buffer = prod; //questa è il codice critico quindi bisogna gestirlo
                //FINE SEZIONE CRITICA
                pieno.Release(); //VERDE A PIENO
                Console.WriteLine("Il thread n°:" + threadId
                    + " ha prodotto il numero: " + prod);
            }
            swProduttore.Stop();
            Console.WriteLine("Tempo impiegato dal produttore: " + swProduttore.ElapsedMilliseconds + " ms");
        }

        private static void consuma(int quanti) //quanti dati sono da consumare
        {
            Stopwatch swConsu = new Stopwatch();
            swConsu.Start();

            int threadId; //inizializzo una varibile che mi dice quale thread sta modificando o meno la risorsa critica
            int consu; //valore generico

            threadId = Thread.CurrentThread.ManagedThreadId; //ci restituisce l'id generico del thread

            for (int i = 1; i <= quanti; i++)
            {
                //BISOGNA GESTIRE LA PRIORITA', siccome si rischia di perdere il dato

                pieno.Wait(); //ROSSO A PIENO
                //INIZIO SEZIONE CRITICA
                consu = buffer;
                //FINE SEZIONE CRITICA
                vuoto.Release(); //VERDE A VUOTO
                Console.WriteLine("Il thread n°:" + threadId
                    + " ha consumato il numero: " + consu);
                Thread.Sleep(TEMPO_CONSUMA);
            }
            swConsu.Stop();
            Console.WriteLine("Tempo impiegato dal consumatore: " + swConsu.ElapsedMilliseconds + " ms");
        }
    }
}
