#include <stdio.h>
#include "libreria.h"

int main() {

    /*int post;
     // Progressivo Codice Studente*/
    int scelta;
    int progGiocatori = 0;
    Giocatore *testaGiocatore = NULL; // Puntatore al primo nodo*/
    Squadre *testaSquadre = NULL;
    do{
        printf("MENU'\n");
        printf("1. Caricare, nelle opportune liste, giocatori e squadre leggendo i file csv rispettivi\n");
        printf("2. Aggiungere un nuovo giocatore ed una nuova squadra (attenzione: il codice squadra è univoco)\n");
        printf("3. Rimuovere una squadra (attenzione: non possono esistere giocatori senza una squadra di riferimento)\n");
        printf("4. Stampare la classifica marcatori\n");
        printf("5. Dato in input una squadra stampare in ouput tutti i giocatori che appartengono ad essa, con il rispettivo numero di gol\n");
        printf("0. Esci\n");
        printf("Scelta: ");
        scanf("%d", &scelta);
        switch(scelta){
            case 1: // Caricare giocatori e squadre tramite csv
                testaGiocatore = loadFromFileGiocatore(testaGiocatore, "giocatori.csv");
                break;
        }
    }while(scelta != 0);
    return 0;
}
