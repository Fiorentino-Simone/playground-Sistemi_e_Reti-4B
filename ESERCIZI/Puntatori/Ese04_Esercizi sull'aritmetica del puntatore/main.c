#include <stdio.h>

int main() {
    /*sostituire i caratteri presenti nel vettore c con 'H','E','L','L','O'*/
    char c[5]={
            'S',
            'A',
            'L',
            'V',
            'E'
    };

    printf("STAMPA VETTORE SENZA PUNTATORE: \n");
    for (int i = 0; i < 5; i++) {
        printf("%c", c[i]);
    }
    printf("\n");

    char *p;
    p=&c[0]; //equivalente a fare p=c;

    *p='H';
    *(++p)='E'; //la dereferenziazione ha la precedenza su tutte le istruzioni quindi non si può mettere p++ siccome prima fa la dereferenziazione poi l'incremento
    *(p+1)='L'; //qui viene preso l'indirizzo di p e gli viene aggiunto 1, ma NON VIENE INCREMENTATO
    *(p+2)='L';
    *(p+3)='O';

    printf("STAMPA CON PUNTATORE: \n");
    int i;
    for (i = 0, p=&c[0]; i < 5; i++, p++){ //potrei fare p+i così evito di spostare il puntatore e NON perdo il riferimento al primo elemento del vettore
        printf("%c", *p);
    }




    return 0;
}