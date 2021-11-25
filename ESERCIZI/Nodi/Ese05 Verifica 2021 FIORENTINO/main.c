#include <stdlib.h>
#include <stdio.h>
#include "listalib.h"

int main()
{
    int scelta;
    int caricamento;
    Atleta *testa = NULL; // Puntatore al primo nodo

    testa = loadFromFile(testa, "atleti.csv", "esiti.csv");
    showList(testa);

    do{
        printf("MENU'\n");
        printf("1. Calcola Punteggio Atleta (media dei 3 salti)\n");
        printf("2. Nuovo Atleta (in testa e/o coda)\n");
        printf("3. Ricerca e Stampa Atleti con salto nullo\n");
        printf("4. Stampa Classifica (ordinata per punteggio)\n");
        printf("Scelta: ");
        scanf("%d", &scelta);
        switch(scelta){
            case 1: ///1. Calcola Punteggio Atleta (media dei 3 salti) ==> DONE
                calcolaPunteggio(testa);
                printf("STAMPA CON I PUNTEGGI: ");
                showList(testa);
                break;

            case 2: /// 2. Nuovo Atleta (in testa e/o coda) ==> DONE
                printf("vuoi inserire in testa o in coda? \n inserisci 0 (testa) 1 (coda)");
                scanf("%d",&caricamento);
                if(caricamento==0) //testa
                    testa = addOnHead(testa);
                else //coda
                    testa=addOnTail(testa,NULL);
                printf("NUOVO ATLETA CARICATO CON SUCCESSO!!!\n");
                showList(testa);
                break;

            case 3: /// 3. Ricerca e Stampa Atleti con salto nullo ==> DONE
                showFilterList(testa);
                break;

            case 4: ///4. Stampa Classifica (ordinata per punteggio) ==> DONE
                ordPerPunteggio(testa);
                printf("Nodi della lista ordinati in base al punteggio !!\n");
                showList(testa);
                break;
        }
    }while(scelta != 0);
    /* DEALLOCA LISTA ATLETI */
    freeLista(testa);
    printf("Lista completamente disallocata!!!\n");
    printf("PROGRAMMA TERMINATO...\n");
    return 0;
}