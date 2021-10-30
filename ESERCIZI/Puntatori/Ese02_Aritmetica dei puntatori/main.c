#include <stdio.h>

int main() {

    //Il vettore è passato gia per referenza quando viene inizializzato.
    int a[] ={
            10,
            34,
            62
    };
    int *pa;


    for (int i = 0; i < 3; i++){
            printf("a[%d]: %d\t %p\n",i,a[i],&a[i]);
    }

    /*STAMPA CON INDICI E CON PUNTATORI */
    //facendo cosi si capisce come a è il puntatore della prima cella del vettore
    //quindi grazie alla aritmetica del puntatori facendo a++ vado alla seconda cella del vettore
    for (int i = 0; i < 3; i++) {
        printf("Indirizzo con indice: %p\t Indirizzo con puntatore: %p\n",&a[i],a+i);
    }

    //ASSEGNO LA PRIMA CELLA AL MIO PUNTATORE
    pa=&a[0];
    printf("Indirizzo puntatore: %p\t Il suo contenuto: %d\n", pa, *pa+1);
    return 0;
}