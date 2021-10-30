////////////////////////////////////////////////////FIORENTINO SIMONE 4^B INFORMATICA/////////////////////////////////////////////

#include <stdio.h>
#include <stdlib.h>

//COSTANTI
#define LEN 20

//FUNCTION
int lenstr(char*);
void uppercase(char*);
char* concat(char*,char*);
void sort(char*);

int main() {
    //DICHIARAZIONE
    int *scelta;
    char *s;
    char *s1;

    //ALLOCAZIONE E INIZIALIZZAZIONE
    scelta = (int*)malloc(sizeof(int)*1);
    s = (char*) calloc(LEN,sizeof (char));
    s1 = (char*) calloc(LEN,sizeof(char));


    //chiedo la scelta in input
    do {
        printf("Inserisci un numero da (1 a 4) per indicare quale funzione sviluppare: ");
        printf("\n1. lenstr() calcola la lunghezza di una stringa"
               "\n2. uppercase() modifica una stringa sostituendo le lettere minuscole con lettere maiuscole"
               "\n3. concat() concatena due stringhe"
               "\n4. sort() ordina i caratteri di una stringa\n N funzione:");
        scanf("%d",scelta);
    }while((*scelta)<=0 || (*scelta)>=5);

    printf("\nInserisci una stringa (senza spazi): ");
    scanf("%s",s);

    s=(char*)realloc(s, sizeof(char)*lenstr(s));//così da evitare di creare una stringa con spazi allocati superiori
    switch (*scelta) {
        case 1: //LUNGHEZZA STRINGA
            printf("LA LUNGHEZZA DELLA STRINGA INSERITA VALE: %i",lenstr(s));
            break;

        case 2: //UPPERCASE
            uppercase(s);
            printf("LA STRINGA MAIUSCOLA VALE: %s", s);
            break;

        case 3: //CONCAT
            printf("\nInserisci una seconda stringa: ");
            scanf("%s",s1);
            printf("\nLa stringa risultante CONCATENATA vale: %s", concat(s,s1));
            break;

        case 4: //SORT
            sort(s);
            printf("\nLa stringa ORDINATA VALE: %s", s);
            break;
    }
    return 0;
}

int lenstr(char* s){
    //DICHIARAZIONE
    int *lun;

    //INIZIALIZZAZIONE
    lun = (int*) calloc(1,sizeof(int));

    //uso del while per calcolare la lunghezza della stringa
    while(*s != '\0'){
        (*lun)++;
        s++;
    }
    return *lun; //return della lunghezza (int)
}

void uppercase(char* s){
    //utilizzo del while per modificare le lettere in maiuscolo
    while(*s != '\0'){
        if((*s)<=122 && (*s)>=97)
            (*s)-=32;
        s++;
    }
}

char* concat(char* s, char* s1){
    /*
     * si poteva anche fare una realloc della s1 che ha gia la stringa s1 copiata al suo interno e poi fare solo un while per concatenare la stringa
     * s1=(char*) realloc(s1,sizeof(char)*(lenstr(s1)+lenstr(s2)+1));
     * s1+=lenstr(s1); //così adesso sono già posizionato su s2
     */


    //DICHIARAZIONE
    char *ris;
    char *aus;

    //ALLOCAZIONE E INIZIALIZZAZIONE
    ris = (char*) calloc( LEN*2,sizeof (char));
    aus = (char*) malloc(sizeof (char));
    aus=ris;

    //utilizzo dei due while per concatenare le stringhe
    while(*s != '\0'){
        *ris=*s;
        ris++;
        s++;
    }

    while(*s1 != '\0'){
        *ris=*s1;
        ris++;
        s1++;
    }
    return aus; //return della stringa concatenata (puntatore char)
}

void sort(char* s){
    //uso algoritmo fondamentale

    //DICHIARAZIONE
    char *aus;
    int *i;
    int *j;
    int *lun;

    //ALLOCAZIONE
    aus= (char*) malloc(sizeof (char)*1);
    i = (int*)malloc(sizeof (int)*1);
    j= (int*)malloc(sizeof (int)*1);
    lun=(int*)malloc(sizeof(int)*1);


    //sviluppo algoritmo
    *lun=lenstr(s);
    for (*i = 0; *i <= (*lun)-2; (*i)++) {
        for (*j = (*i)+1; *j <= (*lun)-1; (*j)++) {
            if(!(*(s+(*i)) <= 57 && *(s+(*i))>=48)){ //controllo che non sia un numero
                if(*(s+(*i)) > *(s+(*j))){
                    *aus=*(s+(*i));
                    *(s+(*i))=*(s+(*j));
                    *(s+(*j))=*aus;
                }
            }
        }
    }
}