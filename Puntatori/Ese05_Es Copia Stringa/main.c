#include <stdio.h>

int main() {
    char s1[20];
    char s2[20];
    char *p;
    char *p2;

    printf("Inserisci una stringa: ");
    scanf("%s",s1);

    p=s1; //ci posizioniamo alla prima cella
    p2=s2;
    do {
        *p2=*p;
        p2++;
        p++;
    }while(*p != '\0');
    *p2='\0'; //IMPORTANTE!!!
    printf("La stringa copiata in s2: %s\n",s2);
    return 0;
}