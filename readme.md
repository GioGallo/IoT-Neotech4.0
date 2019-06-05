# G-Tam Tech

ITS Kennedy, Pordenone
Corso IoT 2018/2019

### Prerequisiti

- Per l' utilizzo del seguente progetto è necessario predisporsi dei seguenti software :
    - [Redis](https://redis.io/)
    - [Visual Studio Code]
    - [NodeJs]
    - [Visual Studio 2019]
    
- Prima di avviare il programma per la simulazione dei sensori è necessario configurare i seguenti parametri nel file [app.config](Autobus/app.config):
  - urlApi //url del metodo POST delle API che invia i dati al database
  - idMezzo //id del mezzo che si vuole simulare
  
- Prima di avviare il server delle API è necessario configurare i seguenti parametri nel file [default.json](Api/config/default.json):
  - host //indirizzo ip del database
  - database //nome del database utilizzato

### Installazione

* Configurare Redis sulla porta 6379

* Aprire la cartella " Api " con Visual Studio Code

* Eseguire il seguente comando da terminale:
  ```
  npm install
  ```
* Configurare il file " default.json " con i propri dati.
  
* Avviare il servizio con il seguente comando da terminale:
  ```
  node index.js
  ```
----------------------------------------------------------------------------------------------------------------------------------------
  
* Aprire la cartella " SensoriCli " e aprire con Visual Studio il progetto " SensoriCli.sln ".

* Configurare il file " App.config " con i propri dati e avviare l'applicazione.


## Running the tests

Explain how to run the automated tests for this system

### Break down into end to end tests

Explain what these tests test and why

```
Give an example
```

### And coding style tests

Explain what these tests test and why

```
Give an example
```

## Deployment

Add additional notes about how to deploy this on a live system

## Built With

* Visual Studio 2019
* Docker
* Redis
* InfluxDb

## Autori

* **Gallo Giovanni** 
* **Ongaro Nicholas** 
* **Ottoveggio Stefano** 
* **Pozza Nicola**
* **Trevisan Samuele**


