////////////////////////////////////////////FIORENTINO SIMONE 4^B INFO (29/09/2021)/////////////////////////////////////////////////////////

#include <stdio.h>
#include <stdlib.h>
#define ITEMS 3

int main() {

    //DICHIARAZIONE
    int *p;
    int *cont;
    float *media;

    p = (int*) malloc(sizeof(int)*ITEMS);
    cont = (int*) malloc(sizeof (int));

    printf("PRENDO IN INPUT I VALORI: ");
    for (*cont = 1; *cont <= ITEMS; (*cont)++) {
        printf("\nInserisci il %i numero: ",*cont);
        scanf("%i",p+(*cont));
    }

    printf("STAMPA VALORI CON PUNTATORE:\n ");
    for (*cont = 1; *cont <= ITEMS; (*cont)++)
        printf("%i\t",*(p+(*cont)));

    //CALCOLO DELLA MEDIA
    media = (float*) calloc(1,sizeof (float));
    for (*cont = 1; *cont <= ITEMS; (*cont)++)
        *media+=*(p+(*cont));

    printf("\nLa Media vale: %.2f",(*media)/ITEMS);

    //DEALLOCO LE VARIABILI
    /*
        for (*cont = 1; *cont <= ITEMS; (*cont)++) //solo se abbiamo una matrice 
            free(p+(*cont));
    */
    free(p);
    free(cont);
    free(media);
    return 0;
}