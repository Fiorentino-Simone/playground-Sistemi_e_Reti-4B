#include <stdio.h>
#include "libreria.h"

int main() {
    int scelta;
    Giocatore *testaGiocatore = NULL; // Puntatore al primo nodo
    Squadra *testaSquadra=NULL; //Puntatore al primo nodo
    do{
        printf("MENU'\n");
        printf("1. Caricare, nelle opportune liste, giocatori e squadre leggendo i file csv rispettivi\n");
        printf("2. Aggiungere un nuovo giocatore ed una nuova squadra (attenzione: il codice squadra è univoco)\n");
        printf("3. Rimuovere una squadra (attenzione: non possono esistere giocatori senza una squadra di riferimento)\n");
        printf("4. Stampare la classifica marcatori, chi segna più gol\n");
        printf("5. Dato in input una squadra stampare in ouput tutti i giocatori che appartengono ad essa, con il rispettivo numero di gol\n");
        printf("0. Esci\n");
        printf("Scelta: ");
        scanf("%d", &scelta);
        switch(scelta){
            case 1: // Caricare giocatori e squadre tramite csv
                testaGiocatore = loadFromFileGiocatore(testaGiocatore, "giocatori.csv");
                printf("FILE GIOCATORE CARICATO CON SUCCESSO!!!\n");
                //showList(testaGiocatore,NULL,0);
                testaSquadra = loadFromFileSquadra(testaSquadra, "squadre.csv");
                printf("FILE SQUADRE CARICATO CON SUCCESSO !!! \n");
                //showList(NULL,testaSquadra,1);
                break;

            case 2: // Aggiungere un nuovo giocatore ed una nuova squadra
                testaGiocatore = addOnTailGiocatore(testaGiocatore,NULL);
                printf("NUOVO GIOCATORE CARICATO CON SUCCESSO!!!\n");
                showList(testaGiocatore,NULL,0);
                break;
        }
    }while(scelta != 0);
    return 0;
}
