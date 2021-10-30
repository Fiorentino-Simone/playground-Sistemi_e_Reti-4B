////////////////////////////////////////////FIORENTINO SIMONE 4^B INFO (29/09/2021)/////////////////////////////////////////////////////////
#include <stdio.h>
#include <stdlib.h>
#define DIM 20

int main() {

    //DICHIARAZIONE
    char *s;
    char *str;
    char *pAus;
    int *cont;
    int *len;
    char *aus;

    //ASSEGNO E ALLOCO s, len e str
    s = (char*)malloc(sizeof(char));
    len = (int*)calloc(1,sizeof(int));
    str=(char*)malloc(sizeof(char)*(DIM+1));

    //INPUT STRINGA
    printf("Inserisci una stringa (senza spazi): ");
    s=&str[0];
    do
    {
        *s=getche();   // legge un carattere da tastiera
        s++;
        (*len)++;
    }while((*(s-1)!=0x0d));
    printf("\n");
    s--;
    (*len)--;
    *s='\0';  // sostituisco INVIO con il tappo

    // STAMPA DELLA STRINGA
    printf("Stringa scritta: ");
    s=&str[0];
    while((*s)!='\0'){
        printf("%c",*s);
        s++;
    }

    printf("\n");

    //ASSEGNO E ALLOCO DINAMICAMENTE CONT e AUS e PAUS
    aus = (char*)calloc(1,sizeof (char));
    cont=(int*) calloc(1,sizeof (int));
    pAus = (char*)malloc(sizeof(char)*(*len));

    //ASSEGNO CORRETTAMENTE I PUNTATORI
    s=&str[0];
    pAus=&s[(*len)-1];

    //PROCEDIMENTO PER INVERTIRE LA STRINGA
    for (*cont=1; *cont<=(*len)/2; (*cont)++)
    {
        *aus = *s;
        *s = *pAus;
        *pAus = *aus;
        pAus--;
        s++;
    }

    //STAMPA STRINGA INVERTITA
    printf("\nSTAMPA STRINGA INVERTITA:\n");
    s=&str[0];
    while((*s)!='\0'){
        printf("%c",*s);
        s++;
    }

    return 0;
}
