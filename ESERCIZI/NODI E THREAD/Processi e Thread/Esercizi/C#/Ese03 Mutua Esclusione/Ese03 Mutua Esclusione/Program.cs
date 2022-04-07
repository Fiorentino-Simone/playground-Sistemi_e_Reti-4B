using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Ese03_Mutua_Esclusione
{
    class Program
    {
        const int MAX_INTERAZIONI = 100000;
        static int n; //risorsa condivisa, come nel primo esercizio è la console.
        static SemaphoreSlim sem = new SemaphoreSlim(1); //1 ==> semaforo verde, 0 ==> semaforo rosso

        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "_main_";
            Console.WriteLine("INIZIO PROGRAMMA: " + DateTime.Now.ToString("hh:mm:ss,fff"));
            n = 0;
            Parallel.Invoke(incrementa, decrementa); //la procedura invoke permette di assegnare le funzioni a thread singoli, quindi le esegue parallelamente.
            //inoltre il thread main viene momentaneamente sospeso, fino alla loro esecuzione. 
            Console.WriteLine("FINE PROGRAMMA: " + DateTime.Now.ToString("hh:mm:ss,fff"));
            Console.WriteLine("N: " + n.ToString());
            Console.ReadKey();
        }

        //a livello teorico ricordo che i thread sono diversi dai processi siccome tra di essi hanno la memoria condivisa cosa che i processi no.
        // quindi quando andiamo a modificare la variabile e la andiamo a salvare siccome i thread vengono eseguiti in maniera parallela quindi io vado a sovrascrivere in N un valore che è gia cambiato.
        // a livello teorico è la stessa cosa della TEST AND SET, per gestire n useremo un semaforo

        static void incrementa()
        {
            int i = 0;
            int temp; //dove mi salvo la variabile n
            while (i<MAX_INTERAZIONI)
            {
                sem.Wait(); // procedura a livello teorico P (mette a rosso senno se è gia rosso (se è arrivato prima descrementa lo mette in coda al semaforo))
                // INIZIO SEZIONE CRITICA 
                temp = n;
                temp++;
                n = temp;
                //FINE SEZIONE CRITICA
                sem.Release(); // a livello teorico V (mette a verde liberando il semaforo)
                i++;
            }
        }

        static void decrementa()
        {
            int i = 0;
            int temp; //dove mi salvo la variabile locale nb
            while (i < MAX_INTERAZIONI)
            {
                sem.Wait();
                // INIZIO SEZIONE CRITICA 
                temp = n;
                temp--;
                n = temp;
                //FINE SEZIONE CRITICA
                sem.Release();
                i++;
            }
        }
    }
}
