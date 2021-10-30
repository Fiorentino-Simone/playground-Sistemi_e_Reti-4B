#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#define DIM 20

int main()
{
    //VER.2.0 dell'esercizio invertire stringa

    char *c;
    int *i;
    char *ci;
    int *j;
    char *aus;
    char *cf;

    c=(char*)malloc(sizeof(char)*DIM);
    aus=(char*)malloc(sizeof(char));

    printf("Inserisci la stringa: ");
    scanf("%s",c);

    c=(char*)realloc(c,strlen(c)+1);//per liberare le caselle non utilizzate, si usa c= siccome l'indirizzo potrebbe cambiare

    ci=c;
    cf=c+strlen(c)-1;
    do{
        *aus=*ci;
        *ci=*cf;
        *cf=*aus;
        ci++;
        cf--;
    }while(c<cf);

    printf("STRINGA VALE: %s",c);
    return 0;
}
