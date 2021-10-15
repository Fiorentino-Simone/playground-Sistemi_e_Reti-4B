#include <stdio.h>
#include <stdlib.h>
void stampaVett(int[], int);
int main() {
    int v[]={
            1,
            2,
            3,
            4,
            5
    };
    printf("Array statico: \n");
    stampaVett(v,5);

    /*MALLOC (numbyte dato dal sizeof):
     * restituisce un puntatore void
     * Se la malloc funziona verrà allocato nell'area di memoria un area definito dal sizeof
     */

    int numEle=10;
    int *p;
    p = (int*) malloc(sizeof(int)*numEle); //bisogna fare il parser int*
    for (int i = 0; i < numEle; i++) {
        p[i]=i;
    }
    printf("\nSTAMPA VETTORE CON UN PUNTATORE\n");
    stampaVett(p,numEle);

    /*CALLOC
     * funziona come la malloc, però azzera/inizializza il contenuto, quindi meglio della malloc
     */

    p = (int*) calloc(numEle, sizeof(int));

    //se aumentiamo il numero di elementi, si può fare una realloc dove inseriremo p e il numero di elementi
    numEle=15;
    p=realloc(p, numEle * sizeof(int)); //cast non necessario perchè mi restiuirà lo stesso tipo del puntatore passato
    printf("\nArray dinamico dopo la realloc\n");
    stampaVett(p,numEle);

    //per liberare queste quindici celle si usa il metodo free
    free(p);//unico parametro è il puntatore che verranno rilasciate
    printf("\nDopo la FREE: \n");
    stampaVett(p,numEle);
    return 0;
}

void stampaVett(int v[], int n){
    for (int i = 0; i < n; i++) {
        printf("%d\t",v[i]);
    }
}