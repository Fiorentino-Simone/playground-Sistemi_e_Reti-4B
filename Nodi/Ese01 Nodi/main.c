//////////////////////////////////////////////////////////////////FIORENTINO SIMONE 4^B INFO///////////////////////////////////////////////////////////////////////////

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct studente{ //dichiarazione della struttura
    int codice;
    char cognome[20];
    float media;
    struct studente *next; //puntatore al nodo successivo
}Studente; //Studente nome della struttura, tipo della struttura

Studente* addOnHead(Studente *head, int *progStud);
Studente* nuovoStudente(int *prog);
Studente* addOnTail(Studente *head, int *progStud);
void showList(Studente *head);
int contaNodi(Studente* head);
Studente* AddByPos(Studente* head, int *progStud);

int main() {
    int progStud=0; //Progressivo per il codice dello studente
    Studente *testa = NULL; //Puntatore al primo nodo, senza di questo perderemmo la lista

    //OBBIETTIVO: creare una serie di nodi concatenati e stampare il risultato
    int scelta;
    do{
        printf("MENU':\n");
        printf("1. Aggiungi Nodo in TESTA\n");
        printf("2. Aggiungi Nodo in CODA\n");
        printf("3. Stampa Lista\n");
        printf("4. Lunghezza della lista\n");
        printf("5. Aggiungi nella lista un nodo in una posizione in input\n");
        printf("0. Esci\n");
        printf("Scelta: ");
        scanf("%d",&scelta);
        switch(scelta){
            case 1:
                //funzione che aggiunge un nodo in testa, e quindi aggiorno il puntatore testa
                testa = addOnHead(testa,&progStud); //& è come passarlo per ref di c#
                break;
            case 2:
                //Add nodo in coda
                testa = addOnTail(testa,&progStud);
                break;

            case 3:
                //Stampa Lista
                showList(testa);
                break;

            case 4:
                //conta il numero di nodi in una lista
                printf("Il numero di nodi nella lista sono: %i\n", contaNodi(testa));
                break;

            case 5:
                //Aggiungi nodo in una pos in input
                testa=AddByPos(testa, &progStud);
                break;
        }
    }while(scelta!=0);
    return 0;
}

void showList(Studente *head){
    Studente *pLista;

    if(head==NULL){
        printf("Lista Vuota!! \n");
    }
    else{
        pLista=head;
        printf("Lista Studenti: ");
        printf("\nCodice\tCognome\t\tMedia");
        do{
            printf("\n%d\t%s\t\t%f\n",pLista->codice,pLista->cognome,pLista->media);
            pLista=pLista->next;
        }while(pLista!=NULL);
    }
}

Studente* addOnTail(Studente *head, int *prog){
    Studente *pStu;
    Studente *pLista;
    pStu=nuovoStudente(prog);

    if(head == NULL){ //vuol dire che non ce nessun nodo collegato alla lista
        head=pStu;
    }
    else{
        //ora lo colleghiamo all'ultimo nodo (che ha come next == NULL)
        pLista=head;
        while (pLista->next != NULL)
            pLista=pLista->next; //andiamo ad associarli il puntatore successivo
        pLista->next=pStu;
    }
    return head;
}



Studente* addOnHead(Studente *head, int *prog){
    Studente *pStu; //Puntatore al nuovo nodo
    pStu = nuovoStudente(prog); //passo prog solo siccome è gia un puntatore(siccome l'abbiamo passato per parametro)

    //modifico il puntatore collegandolo alla testa
    pStu->next=head;
    return pStu;
}


Studente* AddByPos(Studente* head, int *prog){
    Studente *NodoPrecedente;
    Studente* pLista;
    Studente* pStu;
    int pos; //variabile con la posizione in input
    int cont; //lunghezza della lista
    int i = 1;//indice lista

    pStu = nuovoStudente(prog);
    pLista = head;
    NodoPrecedente = head;
    printf("Inserisci la posizione: ");
    scanf("%i", &pos);
    if(head == NULL)
        head = pStu;
    else
    {
        cont = contaNodi(head);
        if(pos>cont)
        {
            while(pLista->next != NULL)
                pLista = pLista->next;
            pLista->next = pStu;
        }
        else
        {
            do
            {
                if(pos == 1)
                {
                    if(i==pos)
                    {
                        NodoPrecedente = pStu;
                        pStu->next = pLista;
                    }
                    else
                    {
                        NodoPrecedente = pLista;
                        pLista= pLista->next;
                    }
                }
                else
                {
                    if(i == pos)
                    {

                        NodoPrecedente->next = pStu;
                        pStu->next = pLista;
                    }
                    else
                    {
                        NodoPrecedente = pLista;
                        pLista = pLista->next;
                    }
                }
                i++;
            }
            while(i<=cont);
        }
        if(pos == 1)
            return pStu;
    }
    return head;
}

Studente* nuovoStudente(int *prog){
    //bisogna allocare un nuovo spazio per l'intera struttura (quindi 4 "contenitori" ==> vedi struttura Studente)
    char cogn[20];
    float med;
    Studente *pNew;

    *prog = *prog+1;
    printf("Nuovo Studente numero %d: \n",*prog);
    printf("Inserisci cognome: ");
    scanf("%s",cogn);
    do{
        printf("Inserisci Media: ");
        scanf("%f",&med);
    }while(med < 2 || med>10);

    //ALLOCO IL NODO
    pNew=(Studente*) malloc(sizeof(Studente));

    //ASSEGNO I CAMPI DEL NODO
    pNew->codice=*prog;
    strcpy(pNew->cognome, cogn); //prende il contenuto e lo copia in cognome (IMPORTANTE!!, non posso fare l'assegnazione pNew->cognome=cogn)
    pNew->media=med;
    pNew->next=NULL; //Punta a NULL, dovessimo aggiungere il nodo alla fine potremmo lasciare NULL senno bisogna inserirli testa (vedere la funzione precedente)
    return pNew;
}

int contaNodi(Studente* head)
{
    int cnt = 1;
    Studente *pLista;
    pLista = head;
    if(pLista == NULL)
        return cnt;
    else
    {
        while(pLista->next != NULL)
        {
            pLista = pLista->next;
            cnt++;
        }
        return cnt;
    }
}