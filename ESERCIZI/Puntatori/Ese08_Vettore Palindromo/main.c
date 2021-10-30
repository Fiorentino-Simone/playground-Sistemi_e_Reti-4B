////////////////////////////////////////////FIORENTINO SIMONE 4^B INFO (29/09/2021)/////////////////////////////////////////////////////////

#include <stdio.h>
#include <stdlib.h>
#include <time.h>

//FUNCTION
stampaVett(int*,int);

int main() {

    //DICHIARAZIONE PUNTATORI:
    int *n;
    int *cont;
    int *a;
    int *i;
    int *j;

    //ALLOCAZIONE DINAMICA E INIZIALIZZAZIONE DI DIM VETTORE
    n=(int*) calloc(1,sizeof (int));
    do {
        printf("Inserisci la dimensione N del vettore: ");
        scanf("%d",n);
    }while(*n<=0);

    //Inizializzazione del seme per la generazione casuale
    srand(time(NULL));

    //ALLOCAZIONE DINAMICA DI CONT E DEL VETTORE A
    cont=(int*) malloc(sizeof(int)*(*n));
    a=(int*) calloc(*n,sizeof (int));

    for ((*cont) = 1; (*cont) <= (*n); (*cont)++)
        *(a+(*cont))=(rand()%(10-0+1))+0 +1; //assegno al vettore il valore generato casualmente

    printf("Stampa del vettore allocato dinamicamente: ");
    stampaVett(a,*n);
    

    //CONTROLLO SE PALINDROMO
    i=a+1;
    j=a+((*n)-1);
    while((*i)==(*j) && i<j){
        i++;
        j--;
    }

    if((*i) == (*j))
        printf("\nSI PALINDROMO");
    else printf("\nNO PALINDROMO");

    return 0;
}

void stampaVett(int *v, int n){ //i vettori si passano sempre nei parametri con la star
    for (int i=1; i <= (*n); i++)
        printf("\na[%i] = %i",i,(*(a+i));
}
