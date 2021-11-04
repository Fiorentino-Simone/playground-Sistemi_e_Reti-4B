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



Giocatore* loadFromFileGiocatore(Giocatore *head, char* file_name);
Squadra* loadFromFileSquadre(Squadre *head, int *prog, char* file_name);


/*Studente* addOnHead(Studente *head, int *prog); // Add nodo in testa alla lista
Studente* nuovoStudente(int *prog);
Studente* addOnTail(Studente *head, int *prog, Studente *newSt); // Add nodo in coda alla lista
void showList(Studente *head);
int contaNodi(Studente *head);
Studente* addByPos(Studente *head, int *prog, int pos);
Studente* delByPos(Studente *head, int pos);
Studente* loadFromFile(Studente *head, int *prog, char* file_name);
Studente* nuovoStudenteDaFile(int *prog, char *cogn, float med);
void sortList(Studente *head);
void freeLista(Studente **head);*/


/*
Studente* addOnHead(Studente *head, int *prog){
    Studente *pStu; // Puntatore al nuovo nodo
    pStu = nuovoStudente(prog);
    ////////
    pStu->next = head;

    return pStu;
}

Studente* addOnTail(Studente *head, int *prog, Studente *newSt){
    Studente *pLista;
    Studente *pStu;
    if (newSt == NULL)
        pStu = nuovoStudente(prog);
    else
        pStu = newSt;

    if (head == NULL)
        head = pStu;
    else{
        pLista = head;
        while(pLista->next != NULL)
            pLista = pLista->next;
        pLista->next = pStu;
    }
    return head;
}

void showList(Studente *head){
    Studente *pLista;

    if (head == NULL)
        printf("Lista Vuota\n");
    else{
        pLista = head;
        printf("Lista Studenti\n");
        printf("\nCodice\tCognome\t\tMedia");
        do{
            printf("\n%d\t%s\t\t%f\n", pLista->codice, pLista->cognome, pLista->media);
            pLista = pLista->next;
        }
        while(pLista != NULL);
    }
}

Studente* nuovoStudente(int *prog){
    int cod;
    char cogn[20];
    float med;
    Studente *pNew;

    (*prog)++; // Incremento codice studente

    printf("Nuovo Studente numero %d:\n", *prog);
    printf("Inserisci cognome: ");
    scanf("%s", cogn);
    do{
        printf("Inserisci media: ");
        scanf("%f", &med);
    } while(med < 2 || med > 10);

    pNew = (Studente*) malloc(sizeof(Studente));
    pNew->codice = *prog;
    strcpy(pNew->cognome, cogn);
    pNew->media = med;
    pNew->next = NULL;
    return pNew;
}

Studente* nuovoStudenteDaFile(int *prog, char *cogn, float med){
    int cod;
    Studente *pNew;

    (*prog)++; // Incremento codice studente

    pNew = (Studente*) malloc(sizeof(Studente));
    pNew->codice = *prog;
    strcpy(pNew->cognome, cogn);
    pNew->media = med;
    pNew->next = NULL;
    return pNew;
}

int contaNodi(Studente *head){
    int cont = 0;
    Studente *p;
    p = head;

    while(p != NULL){
        cont++;
        p = p -> next;
    }

    return cont;
}

Studente* addByPos(Studente *head, int *prog, int pos){
    int i;

    Studente *pNew;
    Studente *pList;

    if(pos == 1){
        head = addOnHead(head, prog);
    }
    else{
        if(pos > contaNodi(head))
            head = addOnTail(head, prog, NULL);
        else{
            pNew = nuovoStudente(prog);
            pList = head;

            for(i = 1; i < pos - 1; i++){
                pList = pList -> next;
            }

            pNew->next = pList->next;
            pList->next = pNew;
        }
    }
    return head;
}

Studente* delByPos(Studente *head, int pos){
    Studente *pList;
    Studente *pDel;
    pList=head;//faccio puntare la lista a head

    //PRIMO CASO: in cui pos è la testa
    if(pos == 1){
        head = pList->next;
        free(pList);
    }
    else
    {
        //SECONDO CASO: in cui pos è maggiore di 1, ma compreso in contanodi()
        for(int i=1; i<pos-1; i++){
            pList=pList->next; //pList punta al nodo precedente indicato da pos
        }
        pDel=pList->next;
        pList->next=pDel->next;
        free(pDel);
    }
    return head;
}
*/
Giocatore loadFromFile(Giocatore *head, char* fileName){
    FILE *fp;
    Giocatore *pNew;
    char row_file[20+1];
    char cogn[15+1], squadraStr[10], golStr[10];
    int squadra,gol;
    int i=0, j=0;
    fp=fopen(fileName,"r");//bisogna specificare il carattere w (write), r (read)
    if (fp == NULL) // Se fopen non eseguito correttamente
        printf("Apertura file non riuscita\n");
    else{
        while(!feof(fp)){ // Scorro il file, riga per riga, fino a quando non raggiungo EOF, come in c# ==> !EndOfStream()
            //fread(row_file, sizeof(char), sizeof(row_file), fp);
            fgets(row_file, 20+1, fp);
            //fscanf(fp, "%s", row_file);
            //printf("%s\n", row_file);
            int len = strlen(row_file);
            i = 0;
            j = 0;

            /*COGNOME*/
            while(row_file[i] != ';'){
                cogn[i] = row_file[i];
                i++;
            }
            cogn[i] = '\0';
            i++;

            /*NUMERO SQUADRA*/
            while(row_file[i] !=  ';'){
                squadraStr[j] = row_file[i];
                i++;
                j++;
            }
            squadraStr[j] = '\0';
            squadra = atof(squadraStr);

            /*GOL EFFETTUATI*/
            int k=0;
            while(row_file[i] !=  '\0'){
                golStr[k] = row_file[i];
                i++;
                k++;
            }
            golStr[k] = '\0';
            gol = atof(golStr);


            printf("Cogn: %s Squadra: %i GOL: %i\n", cogn, squadra, gol);
            /*pNew = nuovoStudenteDaFile(prog, cogn, media);
            head = addOnTail(head, prog, pNew);*/
        }
    }
    fclose(fp); // Chiusura del file
    return head;
}

void sortList(Studente *head){
    /*Studente *pList;
    Studente *i;
    char temp[20+1];
    int prog;
    float media;

    pList=head;
    i=NULL;

    if(head==NULL){
        return;
    }
    else{
        while(pList!=NULL){
            i=pList->next;  //si va a puntaree il nodo successivo in i
            while(i!=NULL){
                if(strcmp(pList->cognome,i->cognome)>0){ //se il nodo corrente e più grande del nodo indice si va a fare l'ordinamento
                    strcpy(temp, pList->cognome);
                    strcpy(pList->cognome, i->cognome);
                    strcpy(i->cognome, temp);

                    prog=pList->codice;
                    pList->codice=i->codice;
                    i->codice=prog;

                    media=pList->media;
                    pList->media=i->media;
                    i->media=media;
                }
                i=i->next;
            }
            pList=pList->next;
        }
    }*/

    //si può anche fare con il for usando i e j
    //ALGORITMO: BOUBLE SORT
    Studente *i=NULL; //ricordo che la i++, significa PASSARE AL NODO SUCCESSIVO (i=i->next)
    Studente *j=NULL;
    int cod;
    char cogn[20+1];
    float media;
    int rifare=1;

    while(rifare==1){
        rifare=0;
        for(i=head; i->next != NULL; i=i->next){
            for(j=i->next; j!=NULL; j=j->next){
                if(strcmp(i->cognome,j->cognome)>0){
                    /*Codice*/
                    cod=i->codice;
                    i->codice=j->codice;
                    j->codice=cod;

                    /*Cognome*/
                    strcpy(cogn,i->cognome);
                    strcpy(i->cognome, j->cognome);
                    strcpy(j->cognome, cogn);

                    /*Media*/
                    media=i->media;
                    i->media=j->media;
                    j->media=cod;

                    //in caso in cui entra nella if deve di nuovo ripartire dalla testa, quindi con una bool mettiamo in un while il tutto
                    rifare=1;
                }
            }
        }
    }//FINE WHILE
}

void freeLista(Studente **head){
    Studente *pList;
    while(*head != NULL){ //scorro fino a che il contenuto della testa(per quello *) vale NULL
        pList=*head->next;
        free(*head);
        *head=pList;//riassegno head a pList
    }
}

#endif //INC_01_NODO_LIBRERIA_H




