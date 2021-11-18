#include <stdio.h>
#include "libreria.h"

int main() {
    int scelta;
    int codSq;
    Giocatore *testaGiocatore = NULL; // Puntatore al primo nodo di testa giocatore
    Squadra *testaSquadra=NULL; //Puntatore al primo nodo di testa squadre
    do{
        printf("MENU'\n");
        printf("1. Caricare, nelle opportune liste, giocatori e squadre leggendo i file csv rispettivi\n");
        printf("2. Aggiungere un nuovo giocatore ");
        printf("3. Aggiungere nuova squadra (attenzione: il codice squadra e' univoco)\n");
        printf("4. Rimuovere una squadra (attenzione: non possono esistere giocatori senza una squadra di riferimento)\n");
        printf("5. Stampare la classifica marcatori, chi segna piu' gol\n");
        printf("6. Dato in input una squadra stampare in ouput tutti i giocatori che appartengono ad essa,\n con il rispettivo numero di gol\n");
        printf("0. Esci\n");
        printf("Scelta: ");
        scanf("%d", &scelta);
        switch(scelta){
            case 1: // Caricare giocatori e squadre tramite csv ==> DONE
                //IN CLION bisogna inserirlo all'interno della cartella \cmake-build-debug in CODEBLOCK dove c'è il main
                testaGiocatore = loadFromFileGiocatore(testaGiocatore, "giocatori.csv");
                printf("FILE GIOCATORE CARICATO CON SUCCESSO!!!\n");
                showList(testaGiocatore,NULL,0);

                testaSquadra = loadFromFileSquadra(testaSquadra, "squadre.csv");
                printf("FILE SQUADRE CARICATO CON SUCCESSO !!! \n");
                showList(NULL,testaSquadra,1);
                break;

            case 2: // Aggiungere un nuovo giocatore ed una nuova squadra ==> DONE
                /////IMPORTANTE: COntrollare sempre se la lista e' VUOTA perche' senno va in errore 0xC0000005
                testaGiocatore = addOnTailGiocatore(testaGiocatore,NULL);
                printf("NUOVO GIOCATORE CARICATO CON SUCCESSO!!!\n");
                //showList(testaGiocatore,NULL,0);
                break;

            case 3: // Aggiungere una nuova squadra ==> DONE
                testaSquadra=addOnTailSquadra(testaSquadra,NULL);
                printf("NUOVO SQUADRA CARICATA CON SUCCESSO!!!\n");
                showList(NULL,testaSquadra,1);
                break;



            case 4: //Rimuovere una squadra (attenzione: non possono esistere giocatori senza una squadra di riferimento) ==> NOT DONE
                testaSquadra=delSq(testaSquadra,testaGiocatore);
                printf("Eliminazione squadra completata");
                showList(NULL,testaSquadra,1);
                break;

            case 5: //Stampare la classifica marcatori, chi segna piu' gol ==> DONE
                sortList(testaGiocatore);
                printf("nodi della lista ordinati in base ai gol effettuati\n");
                showList(testaGiocatore,NULL,0);
                break;

            case 6: //Dato in input una squadra stampare in ouput tutti i giocatori che appartengono ad essa, con il rispettivo numero di gol ==> DONE
                printf("Inserisci codice sq:  \n");
                scanf("%i",&codSq);
                showFilterList(testaGiocatore,codSq);
                break;
        }
    }while(scelta != 0);
    printf("Programma terminato....\n");
    return 0;
}
