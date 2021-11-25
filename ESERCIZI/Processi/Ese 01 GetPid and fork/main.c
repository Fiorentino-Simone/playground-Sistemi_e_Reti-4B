#include <stdlib.h>
#include <stdio.h>
#include <unistd.h>
#include <sys/types.h>
#include <sys/wait.h>

/*int main(void){  ==> PRIMO PROGRAMMA 
    int ret, status;
    printf("Inizio programma.. processo padre[%d]\n",getpid());

    ret =fork();
    if(ret!=0){
        printf("Sono il processo padre [%d]\n",getpid());
        wait(&status);
        printf("Figlio terminato status [%d]\n",status);
    }
    else{
        printf("Sono il processo figlio [%d]\n",getpid()); 
    }
    return 0;
}*/

int main(void){
    int nFigli;
    int ret;
    printf("Inserisci numero figlio da generare");
    scanf("%d",&nFigli);
    int pidFigli[nFigli]; //Vettore per memorizzare ID processi figli

    for(int i=0; i<nFigli && ret!=0; i++){  //(ret) ==> significa ret != 0
        ret=fork();
        if(ret!=0){
            pidFigli[i]=ret;
        }
    }
    if(ret!=0){ //PADRE

    }
    else{ //FIGLIO
        printf("Sono il processo figlio [%d]\n",getpid()); 
    }
    printf("[%d] termine programma...\n",getpid());
    return 0;
}
