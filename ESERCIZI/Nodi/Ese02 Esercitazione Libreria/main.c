#include "listalib.h"

int main()
{
    int post;
    int scelta;
    int progStu = 0; // Progressivo Codice Studente
    Studente *testa = NULL; // Puntatore al primo nodo
    do{
        printf("MENU'\n");
        printf("1. Aggiungi Nodo in Testa\n");
        printf("2. Aggiungi Nodo in Coda\n");
        printf("3. Stampa Lista\n");
        printf("4. Conta nodi\n");
        printf("5. Aggiungi Nodo in una posizione\n");
        printf("6. Carica lista da File\n");
        printf("7. Elimina Nodo in una posizione\n");
        printf("8. Ordinare i nodi nella lista\n");
        printf("0. Esci\n");
        printf("Scelta: ");
        scanf("%d", &scelta);
        switch(scelta){
            case 1: // Add nodo in testa
                testa = addOnHead(testa, &progStu); // Aggiungo nuovo nodo in testa alla lista
                break;
            case 2: // Add nodo in coda
                testa = addOnTail(testa, &progStu, NULL); // Aggiungo nuovo nodo in coda alla lista
                break;
            case 3: // Stampa lista
                showList(testa);
                break;
            case 4:
                printf("Totale nodi: %d\n", contaNodi(testa));
                break;
            case 5:
                printf("\nInserisci la posizione:");
                scanf("%d", &post);
                testa = addByPos(testa, &progStu, post);
                break;
            case 6:
                testa = loadFromFile(testa, &progStu, "studenti.csv");
                break;
            case 7: /* data la posizione del nodo eliminarlo ricordandosi la deallocazione dalla memoria */
                printf("\nInserisci la posizione:");
                scanf("%d", &post);
                testa = delByPos(testa, post);
                printf("Eliminazione effettuata!!!");
                break;
            case 8:
                sortList(testa);
                printf("Nodi della lista ordinati!!!\n");
                break;
        }
    }while(scelta != 0);
    return 0;
}
