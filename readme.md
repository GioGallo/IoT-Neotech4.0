# G-Tam Tech

ITS Kennedy, Pordenone
Corso IoT 2018/2019

### Prerequisiti

- Per l' utilizzo del seguente progetto è necessario predisporsi dei seguenti software :
    - Redis
    - NodeJs
    - InfluxDb
    - Chronograf
    
- Prima di avviare il programma per la simulazione dei sensori è necessario configurare i seguenti parametri nel file **Autobus/app.config**:
  - **urlApi** //url del metodo POST delle API che invia i dati al database
  - **idMezzo** //id del mezzo che si vuole simulare
  
- Prima di avviare il server delle API è necessario configurare i seguenti parametri nel file **Api/config/default.json**:
  - **host** //indirizzo ip del database
  - **database** //nome del database utilizzato

### Installazione e avvio del progetto

* Configurare Redis sulla porta 6379 con l' utilizzo di Docker con il seguente comando da terminale
  ```
  docker run --name pw-redis -p 6379:6379 -d redis
  ```
* Avviare il container con il seguente comando da terminale
  ```
  docker start *nome_container*
  ```
* Aprire la cartella **Api** con Visual Studio Code

    * Eseguire il seguente comando da terminale
      ```
      npm install
      ```
    * Avviare il servizio con il seguente comando da terminale
      ```
      node index.js
      ```
* Aprire la cartella **SensoriCLI** con Visual Studio Community e avviare il programma

* All' interno della cartella **influxdb-1.7.6-1** avviare i seguenti eseguibili
    * **influxd.exe**
    * **influx.exe**
    
* All' interno della cartella **chronograf-1.7.11** avviare il seguente eseguibile
    * **chronograf.exe**
    
* Collegarsi con il browser al servizio online di Chronograf tramite l' indirizzo ip della macchina nella quale sono avviati InfluxDb e Chronograf, sulla porta *8888*
    
  
## Sviluppato con

- Redis
- Visual Studio Code
- NodeJs
- Visual Studio 2019
- InfluxDb
- Chronograf
- Microsoft SQL Server Management Studio

## Autori

* **Gallo Giovanni** 
* **Ongaro Nicholas** 
* **Ottoveggio Stefano** 
* **Pozza Nicola**
* **Trevisan Samuele**


