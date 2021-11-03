#ifndef INC_01_NODO_LISTALIB_H
#define INC_01_NODO_LISTALIB_H
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct studente{
    int codice;
    char cognome[20];
    float media;
    struct studente *next;
}Studente;

Studente* addOnHead(Studente *head, int *prog); // Add nodo in testa alla lista
Studente* nuovoStudente(int *prog);
Studente* addOnTail(Studente *head, int *prog, Studente *newSt); // Add nodo in coda alla lista
void showList(Studente *head);
int contaNodi(Studente *head);
Studente* addByPos(Studente *head, int *prog, int pos);
Studente* delByPos(Studente *head, int pos);
Studente* loadFromFile(Studente *head, int *prog, char* file_name);
Studente* nuovoStudenteDaFile(int *prog, char *cogn, float med);
void sortList(Studente *head);


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
    int i=1;
    Studente *pStu;
    int cnt=contaNodi(head);
    if(pos == 1 || cnt == 1)
        head = head->next;
    else
    {
        pStu = head;
        if(cnt <= pos)
        {
            for(i=1;i< (cnt-1);i++)
                pStu = pStu->next;
            pStu->next = NULL;
        }
        else
        {
            while(i < pos - 1)
            {
                i++;
                pStu = pStu->next;
            }
            pStu->next = pStu->next->next;
        }
    }
    return head;
}

Studente* loadFromFile(Studente *head, int *prog, char* fileName){
    FILE *fp;
    Studente *pNew;
    char row_file[20+1];
    char cogn[15+1], med_str[10];
    float media;
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
            while(row_file[i] != ';'){
                cogn[i] = row_file[i];
                i++;
            }
            cogn[i] = '\0';
            i++;
            while(row_file[i] != '\0'){
                med_str[j] = row_file[i];
                i++;
                j++;
            }
            med_str[j] = '\0';
            media = atof(med_str);
            //printf("Cogn: %s Media: %.2f\n", cogn, media);
            pNew = nuovoStudenteDaFile(prog, cogn, media);
            head = addOnTail(head, prog, pNew);
        }
    }
    fclose(fp); // Chiusura del file
    return head;
}

void sortList(Studente *head){
    Studente *pList;
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
    }
}

#endif //INC_01_NODO_LISTALIB_H




