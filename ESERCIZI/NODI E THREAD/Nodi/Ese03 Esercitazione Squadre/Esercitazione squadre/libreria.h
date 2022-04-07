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
    struct squadra *next;
}Squadra;



Giocatore* loadFromFileGiocatore(Giocatore *head, char* fileName);
Giocatore* nuovoGiocatoreDaFile(char* nome, int sq, int gol);
Giocatore* addOnTailGiocatore(Giocatore *head, Giocatore *newGiocatore);
Giocatore* nuovoGiocatore();

Squadra* loadFromFileSquadra(Squadra *head, char* fileName);
Squadra* nuovaSquadraDaFile(char* nome, int *cod);
Squadra* addOnTailSquadra(Squadra *head, Squadra *newSquadra);
Squadra* nuovaSquadra(Squadra *head);
Squadra* delSq(Squadra *head, int cod);

void showList(Giocatore *headGc, Squadra *headSq, int val);
void sortList(Giocatore *head);
void showFilterList(Giocatore *headGc, int codSq);

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
    Giocatore *pList;
    Giocatore *pGiocatore;

    //controllo in caso devo inserire il giocatore manualmente
    if (newGiocatore == NULL)
        pGiocatore = nuovoGiocatore();
    else
        pGiocatore=newGiocatore;

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
    char gc[20+1];
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
    scanf("%i",&gol);

    /*INSERIRLI NELLA STRUCT*/
    pNew =(Giocatore*) malloc(sizeof(Giocatore));
    strcpy(pNew->nome,gc);
    pNew->squadra=cod;
    pNew->golfatti=gol;
    pNew->next=NULL;
    return pNew;
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
    Squadra *pSquadra;
    Squadra *pList;

    if (newSquadra == NULL)
        pSquadra = nuovaSquadra(head);
    else
        pSquadra = newSquadra;

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

Squadra* nuovaSquadra(Squadra *head){
    //cod squadra (univoco), nome squadra
    char nomeSq[20+1];
    int cod;
    int controllo=0;
    Squadra *pNew;
    Squadra *pList;

    /*CODICE*/
    if(head==NULL){ //vuol dire che non ci sono elementi
        printf("Inserisci codice squadre");
        scanf("%i",&cod);
    }
    else{
        do{
            controllo=1;
            printf("Inserisci codice squadra: ");
            scanf("%i",&cod);
            pList=head;
            while(controllo==1 && pList->next !=NULL){
                if(pList->cod == cod) controllo=0;
                pList=pList->next;

            }
            if(pList->cod == cod) controllo=0;
            if(controllo==0) printf("Inserisci nuovamente il codice, siccome è GIA PRESENTE\n");
        }while(controllo==0);
    }


    printf("Nuovo Squadra: \n");
    printf("Inserisci nome squadra: ");
    scanf("%s",nomeSq);

    pNew = (Squadra*) malloc(sizeof(Squadra));
    pNew->cod=cod;
    strcpy(pNew->nome,nomeSq);
    pNew->next=NULL;
    return pNew;
}

Squadra* delSq(Squadra *head, int cod){
     //Chidere al prof: funziona solo la eliminazione della squadra, ma non dei rispettivi giocatori
     Squadra *pList;
     Squadra *pDel;

     pList=head;
     while(pList->cod != cod){
        pList=pList->next;
    }
    pDel=pList->next;
    pList->next=pDel->next;
    free(pDel);
    return head;
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

void sortList(Giocatore *head){
    //si può anche fare con il for usando i e j
    //ALGORITMO: BOUBLE SORT
    Giocatore *i=NULL; //ricordo che la i++, significa PASSARE AL NODO SUCCESSIVO (i=i->next)
    Giocatore *j=NULL;
    int cod;
    char nome[20+1];
    int gol;
    int rifare=1;

    while(rifare==1){
        rifare=0;
        for(i=head; i->next != NULL; i=i->next){
            for(j=i->next; j!=NULL; j=j->next){
                if(i->golfatti < j->golfatti){ //ordine decrescente < , invece ordine crescente >
                    /*Codice*/
                    cod=i->squadra;
                    i->squadra=j->squadra;
                    j->squadra=cod;

                    /*Nome Squadra*/
                    strcpy(nome,i->nome);
                    strcpy(i->nome, j->nome);
                    strcpy(j->nome, nome);

                    /*Gol*/
                    gol=i->golfatti;
                    i->golfatti=j->golfatti;
                    j->golfatti=gol;

                    //in caso in cui entra nella if deve di nuovo ripartire dalla testa, quindi con una bool mettiamo in un while il tutto
                    rifare=1;
                }
            }
        }
    }//FINE WHILE
}

void showFilterList(Giocatore *headGc, int codSq){
    Giocatore *pListaGc;
    int controllo=0;
    if (headGc == NULL)
        printf("Lista Giocatore Vuota\n");
    else{
        pListaGc = headGc;

        printf("Lista Giocatore che appartengono alla squadra con codice: %i\n",codSq);
        printf("\nNOME:\tSQUADRA:\tGOL:\t\n");
        do{
            if(codSq==pListaGc->squadra){
                printf("\n%s\t%i\t%i\t\n", pListaGc->nome, pListaGc->squadra, pListaGc->golfatti);
                controllo=1;
            }
            pListaGc = pListaGc->next;
        }
        while(pListaGc != NULL);
        if(controllo==0) printf("Codice inserito non corretto !!!\n");
    }
}




#endif //INC_01_NODO_LIBRERIA_H
