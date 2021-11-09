#ifndef INC_01_NODO_LIBRERIA_H
#define INC_01_NODO_LIBRERIA_H
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct giocatore{
    char nome[20+1];
    int squadra;
    int golfatti;
    struct giocatore *next;
}Giocatore;

typedef struct squadra{
    int cod;
    char nome[20+1];
    struct giocatore *next;
}Squadra;



Giocatore* loadFromFileGiocatore(Giocatore *head, char* fileName);
Giocatore* nuovoGiocatoreDaFile(char* nome, int sq, int gol);
Giocatore* addOnTailGiocatore(Giocatore *head, Giocatore *newGiocatore);
Giocatore* nuovoGiocatore();

Squadra* loadFromFileSquadra(Squadra *head, char* fileName);
Squadra* nuovaSquadraDaFile(char* nome, int *cod);
Squadra* addOnTailSquadra(Squadra *head, Squadra *newSquadra);

void showList(Giocatore *headGc, Squadra *headSq, int val);
//Squadra* loadFromFileSquadre(Squadra *head, int *prog, char* file_name);

Giocatore* loadFromFileGiocatore(Giocatore *head, char* fileName){
    FILE *fp;
    Giocatore *pNew;
    char row_file[20+1];
    char nome[20+1], golStr[10+1];
    char squadraStr[10+1];
    int squadra,gol;
    int i=0, j=0;


    fp=fopen(fileName,"r");//bisogna specificare il carattere w (write), r (read)
    if (fp == NULL) // Se fopen non eseguito correttamente
        printf("Apertura file non riuscita\n");
    else{
        while(!feof(fp)){ // Scorro il file, riga per riga, fino a quando non raggiungo EOF, come in c# ==> !EndOfStream()
            fgets(row_file, 20+1, fp);
            int len = strlen(row_file); //prendiamo la lunghezza della primo valore del file
            i = 0;
            j = 0;

            /*NOME*/
            while(row_file[i] != ';'){
                nome[i] = row_file[i];
                i++;

            }
            nome[i] = '\0';
            i++;

            /*NUMERO SQUADRA*/
            squadraStr[0]=row_file[i];
            i++;
            squadraStr[1]='\0';
            i++;
            squadra = atoi(squadraStr); //restituisce (facendo un cast) il cod in intero, HA BISOGNO DI UN VETTORE DI CHAR

            /*GOL EFFETTUATI*/
            while(row_file[i] !=  '\0'){
                golStr[j] = row_file[i];
                i++;
                j++;
            }
            golStr[j] = '\0';
            j++;
            gol = atoi(golStr);

            //printf("Nome: %s Squadra: %i GOL: %i\n", nome, squadra, gol);
            pNew = nuovoGiocatoreDaFile(nome,squadra,gol);
            head=addOnTailGiocatore(head,pNew);
         }
    }
    fclose(fp); // Chiusura del file
    return head;
}

Giocatore* nuovoGiocatoreDaFile(char* nome, int sq, int gol){
    Giocatore *pNew;

     pNew=(Giocatore*) malloc(sizeof(Giocatore));
     strcpy(pNew->nome,nome);
     pNew->squadra=sq;
     pNew->golfatti=gol;
     pNew->next=NULL;
     return pNew;
}

Giocatore* addOnTailGiocatore(Giocatore *head, Giocatore *newGiocatore){
    Giocatore *pGiocatore;
    Giocatore *pList;

    //controllo in caso devo inserire il giocatore manualmente
    if (newGiocatore == NULL)
        pGiocatore = nuovoGiocatore();
    else
        pGiocatore=newGiocatore;
    printf("%p",pGiocatore);

    if(head==NULL){
        head=pGiocatore;
    }
    else{
        pList=head;
        while(pList->next != NULL){
            pList=pList->next;
        }
        pList->next=pGiocatore;
    }
    return head;
}

Giocatore* nuovoGiocatore(){
    //nome giocatore, cod squadra, golfatti

    char gc[20];
    int cod, gol;
    Giocatore *pNew;

    /*INSERIMENTO GIOCATORE*/
    printf("Nuovo giocatore:  \n");
    printf("Inserisci nome giocatore: ");
    scanf("%s",gc);

    /*INSERIMENTO COD*/
    do{
        printf("Inserisci cod Squadra: ");
        scanf("%i",&cod);
    }while(cod<1 || cod>=9);

    /*INSERIMENTO GOL*/
    printf("Inserisci golfatti: ");
    scanf("%i",gol);

    /*INSERIRLI NELLA STRUCT*/
    pNew =(Giocatore*) malloc(sizeof(Giocatore));
    printf("instanza creata\n");
    strcpy(pNew->nome,gc);
    printf("nome inserito\n");
    pNew->squadra=cod;
    printf("squadra inserita\n");
    pNew->golfatti=gol;
    printf("Gol inseriti \n");
    pNew->next=NULL;
    return pNew;
}

void showList(Giocatore *headGc, Squadra *headSq, int val){
    Giocatore *pListaGc;
    Squadra *pListaSq;
    switch(val){
        case 0:
            if (headGc == NULL)
                printf("Lista Giocatore Vuota\n");
            else{
                pListaGc = headGc;
                printf("Lista Giocatore\n");
                printf("\nNOME:                             SQUADRA:                       GOL:             \n");
                do{
                    printf("\n%s                              %i                            %i                     \n", pListaGc->nome, pListaGc->squadra, pListaGc->golfatti);
                    pListaGc = pListaGc->next;
                }
                while(pListaGc != NULL);
            }
            break;
        case 1:
            if (headSq == NULL)
                printf("Lista Squadre Vuota\n");
            else{
                pListaSq = headSq;
                printf("Lista Squadre\n");
                printf("\nCOD:                             SQUADRA:");
                do{
                    printf("\n%i                            %s                     \n", pListaSq->cod, pListaSq->nome);
                    pListaSq = pListaSq->next;
                }
                while(pListaSq != NULL);
            }
            break;
    }
    printf("\n\n\n\n\n");
}

Squadra* loadFromFileSquadra(Squadra *head, char* fileName){
    FILE *fp;
    Squadra *pNew;
    char row_file[20+1];
    char nome[20+1], codiceStr[20+1];
    int cod;
    int i=0, j=0;


    fp=fopen(fileName,"r");//bisogna specificare il carattere w (write), r (read)
    if (fp == NULL) // Se fopen non eseguito correttamente
        printf("Apertura file non riuscita\n");
    else{
        while(!feof(fp)){ // Scorro il file, riga per riga, fino a quando non raggiungo EOF, come in c# ==> !EndOfStream()
            fgets(row_file, 20+1, fp);
            int len = strlen(row_file); //prendiamo la lunghezza della primo valore del file
            i = 0;
            j = 0;

            /*CODICE*/
            while(row_file[i] != ';'){
                codiceStr[i] = row_file[i];
                i++;
            }
            codiceStr[i] = '\0';
            i++;
            cod=atoi(codiceStr);

            /*NOME SQUADRA*/
            while(row_file[i] !=  '\0'){
                nome[j] = row_file[i];
                i++;
                j++;
            }
            nome[j] = '\0';
            j++;

            //printf("Nome: %s Squadra: %i GOL: %i\n", nome, squadra, gol);
            pNew = nuovaSquadraDaFile(nome,cod);
            head=addOnTailSquadra(head,pNew);
         }
    }
    fclose(fp); // Chiusura del file
    return head;
}

Squadra* nuovaSquadraDaFile(char* nome, int *cod){
     Squadra *pNew;

     pNew=(Squadra*) malloc(sizeof(Squadra));
     pNew->cod=cod;
     strcpy(pNew->nome,nome);
     pNew->next=NULL;
     return pNew;
}

Squadra* addOnTailSquadra(Squadra *head, Squadra *newSquadra){
    Squadra *pSquadra=newSquadra;
    Squadra *pList;
    if(head==NULL){
        head=pSquadra;
    }
    else{
        pList=head;
        while(pList->next != NULL){
            pList=pList->next;
        }
        pList->next=pSquadra;
    }
    return head;
}
#endif //INC_01_NODO_LIBRERIA_H




