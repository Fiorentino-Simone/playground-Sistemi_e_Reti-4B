#include <stdio.h>
#include <stdlib.h>
void stampaVett(int a[], int dim);
int main() {
    int v[] ={1,2,3,4,5};
    int dimV=5;

    stampaVett(v, dimV);

    /*Allocazione dinamica*/
    int numElem=10;
    int *p; //puntatore
    p = (int*)malloc(sizeof(int)*numElem); //alla fine della funzione avremo l'indirizzo dell'elemento creato
    /*Bisogna fare un cast perchè la malloc ritorna un puntatore void
     * Il puntatore ora punto alla prima cella
     * Facendo *numElem crea il numero di elementi, COME SE FOSSE UN VETTORE*/
    return 0;
}

void stampaVett(int a[], int dim){
    for (int i = 0; i < dim; ++i) {
        printf("a[%d]: %d\n", i,a[i]);
    }
}