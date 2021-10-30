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
        }
    }while(scelta != 0);

    return 0;
}
