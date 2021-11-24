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
Squadra* delSq(Squadra *head);
Squadra* delByPosSq(Squadra *head, int pos);


void showList(Giocatore *headGc, Squadra *headSq, int val);
void sortList(Giocatore *head);
void showFilterList(Giocatore *headGc, int codSq);
//Giocatore* removePlayers(Giocatore* head, int cod);

int contaNodi(Squadra *head);

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
    FILE *fp; //puntatore al file
    Squadra *pNew;
    char lineLetta[20+1];
    char nome[20+1], codiceStr[20+1];
    int cod;
    int i=0, j=0;


    fp=fopen(fileName,"r");//bisogna specificare il carattere w (write), r (read)
    if (fp == NULL) // Se fopen non eseguito correttamente
        printf("Apertura file non riuscita\n");
    else{
        while(!feof(fp)){ // Scorro il file, riga per riga, fino a quando non raggiungo EOF, come in c# ==> !EndOfStream()
            fgets(lineLetta, 20+1, fp);
            i = 0;
            j = 0;

            /*CODICE*/
            while(lineLetta[i] != ';'){
                codiceStr[i] = lineLetta[i];
                i++;
            }
            codiceStr[i] = '\0';
            i++;
            cod=atoi(codiceStr);

            /*NOME SQUADRA*/
            while(lineLetta[i] !=  '\0'){
                nome[j] = lineLetta[i];
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

    if(head==NULL){ //significa che non ci sono altri nodi
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
            if(controllo==0) printf("Inserisci nuovamente il codice, siccome � GIA PRESENTE\n");
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

int contaNodi(Squadra *head){
    int cont = 0;
    Squadra *p;
    p = head;

    while(p != NULL){
        cont++;
        p = p -> next;
    }
    return cont;
}



Squadra* delSq(Squadra *head){
    Squadra* pList;
    int cod;
    int esci=0;
    int lun= contaNodi(head); //contanodi senno non scorre fino all'ultimo nodo
    int i=0;
    int posNodo;

    // 0 ==> FALSE
    // 1 ==> TRUE

    /*CONTROLLO CODICE*/
    if(head==NULL){ //vuol dire che non ci sono elementi
        printf("Inserisci codice squadre");
        scanf("%i",&cod);
    }
    else{
        do{
            //controllo=1;
            printf("Inserisci codice squadra: ");
            scanf("%i",&cod);
            pList=head;

            while(esci==0 && i!=lun){
                if(pList->cod == cod){
                    esci=1;
                    posNodo=i; //ci segniamo la posizione del nodo
                }
                pList=pList->next;
                i++;
            }
            if(esci==0) {
                printf("Inserisci nuovamente il codice, siccome non � presente nessuna corrispondenza\n");
                i=0;
            }
        }while(esci==0);
    }


    /*ADESSO SI RICHIAMA LA DEL BY POS*/
    posNodo++;
    head = delByPosSq(head,posNodo);
    return head;
}

/*
    //poi dopo tramite while(pList->next!=NULL) andare a eliminare con la free(pDel) il giocatore appartenente a quella squadra, poi anche qua la delbyPos faceva il resto

    Giocatore* pList;
    int lun= contaNodi(head); //contanodi senno non scorre fino all'ultimo nodo
    int i=0;
    int posizioni[20];

    // 0 ==> FALSE
    // 1 ==> TRUE

    Giocatore *pDel;
    pList=head;//faccio puntare la lista a head

    //primo punto: faccio una ricerca e cerco le posizioni di pList che devo cancellare
    int j=0;
    while(i!=lun){
        if(pList->squadra == cod){
            posizioni[j]=i;
            j++;
        }
        pList=pList->next;
        i++;
    }
    i=0;
    j=0;

    pList=head;
    //PRIMO CASO: in cui pos � la testa
    if(posizioni[i] == 0){
        head = pList->next;
        free(pList);
    }
    else
    {
        for (i = 0;i < lun; i++) {
            if(i==posizioni[j]){
                pDel=pList->next;
                pList->next=pDel->next;
                free(pDel);
            }
            pList=pList->next;
        }
    }*/

/*Giocatore* removePlayers(Giocatore* head, int cod)
{
        ///cancellazione dei giocatori relativi alla squadra

        Giocatore* pListaG = head;
        Giocatore* pDelG;
        int cont = 0;


        for(pListaG = head; pListaG != NULL; pListaG = pListaG->next)
        {
            if(pListaG->squadra == cod)
                cont++;
        }
        pListaG = head;

        if(contaNodi(head) == cont)
        {
            while(pListaG != NULL)///free totale della lista
            {
                pListaG = head->next;
                free(head);
                head = pListaG;
            }
        }
        else
        {
            if(head->squadra == cod)
                head = head->next;

            while(pListaG->next != NULL)
            {
                if(pListaG->next->squadra == cod)
                {
                    pDelG = pListaG->next;

                    pListaG->next = pDelG->next;
                    free(pDelG);

                }
                else
                    pListaG = pListaG->next;

            }
        }

        ///Stampa giocatori (per vedere se funziona)
        /*pListaG = head;
        while(pListaG != NULL)
        {
            printf("%s-%d-%d\n",pListaG->nome, pListaG->squadra, pListaG->golfatti);
            pListaG = pListaG->next;
        }

        return head;
}*/



Squadra* delByPosSq(Squadra *head, int pos){
    Squadra *pList;
    Squadra *pDel;
    pList=head;//faccio puntare la lista a head

    //la pos passata � inizializzata a 1 e NON a 0

    //PRIMO CASO: in cui pos � la testa
    if(pos == 1){
        head = pList->next;
        free(pList);
    }
    else
    {
        //SECONDO CASO: in cui pos � maggiore di 1, ma compreso in contanodi()
        for(int i=1; i<pos-1; i++){
            pList=pList->next; //pList punta al nodo precedente indicato da pos
        }
        pDel=pList->next;
        pList->next=pDel->next;
        free(pDel);
    }
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
                printf("\nNOME:\tSQUADRA:\tGOL:\t\n");
                do{
                    printf("\n%s\t%i\t%i\t\n", pListaGc->nome, pListaGc->squadra, pListaGc->golfatti);
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
                printf("\nCOD:\tSQUADRA:");
                do{
                    printf("\n%i\t%s\t\n", pListaSq->cod, pListaSq->nome);
                    pListaSq = pListaSq->next;
                }
                while(pListaSq != NULL);
            }
            break;
    }
    printf("\n\n\n\n\n");
}

void sortList(Giocatore *head){
    //si pu� anche fare con il for usando i e j
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
