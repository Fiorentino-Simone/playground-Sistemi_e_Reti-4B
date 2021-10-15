#include <stdio.h>

int main() {
    //DICHIARAZIONE VARIABILI SEMPLICI
    int i=10;
    char c='a';

    //DICHIARAZIONE PUNTATORI
    int *pi; //puntatore di tipo int
    char *pc; //puntatore di tipo char

    printf("i: %d - c: %c",i,c);
    printf("\nChar %d byte, Int %d byte\n", sizeof(char), sizeof(int)); //tramite il sizeof si può capire la grandezza dei tipi di variabili
    printf("\nPuntatore char %d byte - Puntatore int %d byte \n", sizeof(char*), sizeof(int*)); //i puntatori infatti hanno LA STESSA GRANDEZZA

    /* ASSEGNAZIONE INDIRIZZO A PUNTATORE*/
    pi=&i;
    pc=&c; //passaggio di parametri per referenza in c# con ref qui con il &

    /*STAMPA INDIRIZZO DEI PUNTATORI*/
    printf("\nIndirizzo del puntatori pi: %p - Indirizzo del puntatore di pc: %p\n",&pi,&pc); //si usa il %p per la stampa di indirizzi

    /*STAMPA INDIRIZZO CONTENUTO NEL PUNTATORE*/
    printf("\nIndirizzo di memoria di i, puntato da pi: %p - Indirizzo di memoria di c, puntato da pc: %p\n",pi,pc); //si usa il %p per la stampa di indirizzi

    /*STAMPA DEL CONTENUTO DEL PUNTATORE*/
    printf("\nContenuto della variabile i, tramite dereferenziazione del puntatore pi: %i", *pi);
    printf("\nContenuto della variabile c, tramite dereferenziazione del puntatore pc: %c", *pc);

    /*MODIFICA DEL CONTENUTO*/
    *pi=i+25; //facendo questa operazione io vado indirettamente a modificare anche la variabile i, siccome ricordo io non cambio il valore del puntatore ma il contenuto del puntatore quindi i
    printf("\nIl valore di i vale: %i - Contenuto della variabile i, tramite dereferenziazione del puntatore pi: %i", i,*pi);
    return 0;
}