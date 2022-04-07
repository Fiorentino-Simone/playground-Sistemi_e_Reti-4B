#ifndef INC_01_NODO_LISTALIB_H
#define INC_01_NODO_LISTALIB_H

#define TRUE 1 /* Per attribuzione var. boolean */
#define FALSE 0 /* Per attribuzione var. boolean */

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef int bool; /* Per dichiarazione var. boolean */

typedef struct atleta{
    int codice;
    char nome[20];
    float saltoA, saltoB, saltoC;
    float punteggio; //campo media
    struct atleta *next;
}Atleta;

Atleta* loadFromFile(Atleta *head, char* file_name_atleti, char* file_name_esiti);
Atleta* addOnHead(Atleta *head); // Add nodo in testa alla lista
Atleta* addOnTail(Atleta *head, Atleta *newSt); // Add nodo in coda alla lista
Atleta* nuovoAtleta(Atleta *head);
Atleta* nuovoAtletaDaFile(int cod, char *nome, float saltoA, float saltoB, float saltoC);


void showList(Atleta *head);
void calcolaPunteggio(Atleta *head);
void ordPerPunteggio(Atleta *head);
void freeLista(Atleta *head);
void showFilterList(Atleta *head);
int contaNodi(Atleta *head);

/**********************************************************FUNCTIONS *///////////////////////////////////////////////////

void showFilterList(Atleta *head){
    Atleta *pLista;
    if (head == NULL)
        printf("Lista Giocatore Vuota\n");
    else{
        pLista = head;
        printf("Lista Atleti che presentano almeno un salto nullo:\n");
        printf("\nCodice\t\tSaltoA\tSaltoB\tSaltoC\t\tNome\t\tPunteggio\n");
        do{
            if(pLista->saltoA==0 || pLista->saltoB==0 || pLista->saltoC==0){
                printf("%d\t\t%.2f\t%.2f\t%.2f\t\t%s\t\t%.2f\n", pLista->codice, pLista->saltoA, pLista->saltoB, pLista->saltoC, pLista->nome,pLista->punteggio);
            }
            pLista = pLista->next;
        }
        while(pLista != NULL);
    }
}


void calcolaPunteggio(Atleta *head){
    Atleta *pLista;
    int lun=contaNodi(head);
    int i=0;
    float media=0;
    pLista=head;

    while(i!=lun){
        media=((pLista->saltoA)+(pLista->saltoB)+(pLista->saltoC))/3;
        pLista->punteggio=media;
        pLista = pLista->next;
        i++;
    }
}

Atleta* nuovoAtleta(Atleta *head){
    //  int codice;
    //    char nome[20];
    //    float saltoA, saltoB, saltoC;
    //    float punteggio; //campo media
    //    struct atleta *next;

    char nome[20+1];
    int cod;
    float saltoA, saltoB, saltoC;
    float punteggio=0;
    int esci=0;
    Atleta *pNew;
    Atleta *pList;

    /*CONTROLLO CODICE*/
    printf("Nuovo atleta:  \n");
    do{
        esci=1;
        printf("Inserisci codice squadra: ");
        scanf("%d",&cod);
        pList=head;
        while(esci==1 && pList->next!=NULL){
            if(pList->codice == cod) esci=0;
            pList=pList->next;
        }
        if(pList->codice == cod) esci=0;
        if(esci==0) printf("Inserisci nuovamente il codice, siccome e' GIA PRESENTE\n");
    }while(esci==0);



    /*INSERIMENTO GIOCATORE*/
    printf("Inserisci nome giocatore: ");
    scanf("%s",nome);



    /*INSERIMENTO SALTO A*/
    do{
        printf("Inserisci saltoA: (compreso tra 7 e 9 oppure 0 [salto nullo]) ");
        scanf("%f",&saltoA);
    }while((saltoA<7.00 || saltoA>9.00) && saltoA!=0);


    /*INSERIMENTO SALTO B*/
    do{
        printf("Inserisci saltoB: (compreso tra 7 e 9 oppure 0 [salto nullo]) ");
        scanf("%f",&saltoB);
    }while((saltoB<7.00 || saltoB>9.00) && saltoB!=0);


    /*INSERIMENTO SALTO C*/
    do{
        printf("Inserisci saltoC: (compreso tra 7 e 9 oppure 0 [salto nullo]) ");
        scanf("%f",&saltoC);
    }while((saltoC<7.00 || saltoC>9.00) && saltoC!=0);

    /* CALCOLO PUNTEGGIO */
    punteggio=(saltoA+saltoB+saltoC)/3;

    /*INSERIRLI NELLA STRUCT*/
    pNew =(Atleta*) malloc(sizeof(Atleta));
    strcpy(pNew->nome,nome);
    pNew->codice=cod;
    pNew->saltoA=saltoA;
    pNew->saltoB=saltoB;
    pNew->saltoC=saltoC;
    pNew->punteggio=punteggio;
    pNew->next=NULL;
    return pNew;
}

Atleta* addOnHead(Atleta *head){
    Atleta *pAtl; // Puntatore al nuovo nodo
    pAtl = nuovoAtleta(head);
    pAtl->next = head;
    return pAtl;
}

Atleta* addOnTail(Atleta *head, Atleta *newSt){
    Atleta *pLista;
    Atleta *pAtl;
    if (newSt == NULL)
        pAtl = nuovoAtleta(head);
    else
        pAtl = newSt;

    if (head == NULL)
        head = pAtl;
    else{
        pLista = head;
        while(pLista->next != NULL)
            pLista = pLista->next;
        pLista->next = pAtl;
    }
    return head;
}
void showList(Atleta *head){
    Atleta *pLista;

    /*RICHIAMO LA CALCOLA PUNTEGGIO COSI DA ANDARE A STAMPARE I VALORI CORRETTI */
    if (head == NULL)
        printf("Lista Vuota\n");
    else{
        pLista = head;
        printf("Lista Atleti\n");
        printf("\nCodice\t\tSaltoA\tSaltoB\tSaltoC\t\tNome\t\tPunteggio\n");
        do{
            printf("%d\t\t%.2f\t%.2f\t%.2f\t\t%s\t\t%.2f\n", pLista->codice, pLista->saltoA, pLista->saltoB, pLista->saltoC, pLista->nome,pLista->punteggio);
            pLista = pLista->next;
        }
        while(pLista != NULL);
    }
}

Atleta* nuovoAtletaDaFile(int cod, char *nome, float saltoA, float saltoB, float saltoC){
    Atleta *pNew;

    pNew = (Atleta*) malloc(sizeof(Atleta));
    pNew->codice = cod;
    strcpy(pNew->nome, nome);
    pNew->saltoA = saltoA;
    pNew->saltoB = saltoB;
    pNew->saltoC = saltoC;
    pNew->punteggio = -1;
    pNew->next = NULL;
    return pNew;
}
int contaNodi(Atleta *head){
    int cont = 0;
    Atleta *p;
    p = head;

    while(p != NULL){
        cont++;
        p = p -> next;
    }

    return cont;
}
Atleta* loadFromFile(Atleta *head, char* file_name_atleti, char* file_name_esiti){
    FILE *fpA, *fpE;
    Atleta *pNew;
    bool trovato;
    char row_file[20+1];
    int cod, codE;
    char codStr[5], codEStr[5], saltoAStr[5], saltoBStr[5], saltoCStr[5];
    char nome[20+1];
    float saltoA, saltoB, saltoC;
    int i=0, j=0;
    fpA = fopen(file_name_atleti, "r"); // Apertura file in modalità read

    if (fpA == NULL && fpE == NULL)
        printf("Apertura files non riuscita\n");
    else{
        while(!feof(fpA)){ // Scorro il file, riga per riga, fino a quando non raggiungo EOF
            fscanf(fpA, "%s %s", codStr, nome);
            cod = atoi(codStr);
            trovato = FALSE;
            fpE = fopen(file_name_esiti, "r"); // Apertura file in modalità read
            while((!feof(fpE)) && trovato==FALSE){
                fscanf(fpE, "%s %s %s %s", codEStr, saltoAStr, saltoBStr, saltoCStr);
                codE = atoi(codEStr);
                if (cod == codE)
                    trovato = TRUE;
            }
            fclose(fpE); // Chiusura del file
            if (trovato == TRUE){
                saltoA = atof(saltoAStr);
                saltoB = atof(saltoBStr);
                saltoC = atof(saltoCStr);
                pNew = nuovoAtletaDaFile(cod, nome, saltoA, saltoB, saltoC);
                head = addOnTail(head, pNew);
            }
        }
    }
    fclose(fpA); // Chiusura del file
    return head;
}

void freeLista(Atleta *head){
    Atleta *pList;
    while(head != NULL){ //scorro fino a che il contenuto della testa(per quello *) vale NULL
        pList=head->next;
        free(head);
        head=pList;//riassegno head a pList
    }
}

void ordPerPunteggio(Atleta *head){
    Atleta *i=NULL; //ricordo che la i++, significa PASSARE AL NODO SUCCESSIVO (i=i->next)
    Atleta *j=NULL;
    /*
        int codice;
        char nome[20];
        float saltoA, saltoB, saltoC;
        float punteggio; //campo media
        struct atleta *next;
     */

    int cod;
    char nome[20+1];
    float saltoA,saltoB,saltoC;
    float punteggio;
    int rifare=1;

    calcolaPunteggio(head);
    while(rifare==1){
        rifare=0;
        for(i=head; i->next != NULL; i=i->next){
            for(j=i->next; j!=NULL; j=j->next){
                if(i->punteggio < j->punteggio){ //ordine decrescente < , invece ordine crescente >
                    /*Codice*/
                    cod=i->codice;
                    i->codice=j->codice;
                    j->codice=cod;

                    /*Nome*/
                    strcpy(nome,i->nome);
                    strcpy(i->nome, j->nome);
                    strcpy(j->nome, nome);

                    /*SALTO A*/
                    saltoA=i->saltoA;
                    i->saltoA=j->saltoA;
                    j->saltoA=saltoA;

                    /*SALTO B*/
                    saltoB=i->saltoB;
                    i->saltoB=j->saltoB;
                    j->saltoB=saltoB;

                    /*SALTO C*/
                    saltoC=i->saltoC;
                    i->saltoC=j->saltoC;
                    j->saltoC=saltoC;

                    /*PUNTEGGIO*/
                    punteggio=i->punteggio;
                    i->punteggio=j->punteggio;
                    j->punteggio=punteggio;

                    rifare=1;
                }
            }
        }
    }//FINE WHILE
}
#endif
