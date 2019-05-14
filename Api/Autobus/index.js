const sql = require("mssql");

const fastify = require('fastify')({
    logger: true,
    ignoreTrailingSlash: true
});

const Influx = require('influx');
/*
const influx = new Influx.InfluxDB({
    host: 'localhost',
    database: 'Autobus',
    schema: [
      {
        measurement: 'Posizione',
        fields: { Aperte: Influx.FieldType.INTEGER,
        Latitudine: Influx.FieldType.FLOAT,
        Longitudine: Influx.FieldType.FLOAT,
        Persone: Influx.FieldType.INTEGER },
        tags: ['Id']
      }
    ]
  });
*/
const influx = new Influx.InfluxDB('http://Nicola:nicolapozza@192.168.101.53:8086/Autobus');


/*console.log(influx.query(
    `SHOW TAG VALUES ON "Autobus" FROM "Posizione" WITH KEY = "Id"`
));*/
/*
influx.getDatabaseNames()
  .then(names => {
    if (!names.includes('Autobus')) {
      return influx.createDatabase('Autobus');
    }
  })
  .then(() => {
    app.listen(app.get('port'), () => {
      console.log(`Listening on ${app.get('port')}.`);
    });
    writeDataToInflux(hanalei);
    writeDataToInflux(hilo);
    writeDataToInflux(honolulu);
    writeDataToInflux(kahului);
  })
  .catch(error => console.log({ error }));

influx.query(`
    select * from Posizione`)
  .then( result => response.status(200).json(result) )
  .catch( error => response.status(500).json({ error }));
*/

//SHOW TAG VALUES ON "Autobus" FROM "Posizione" WITH KEY = "Id"
//tutti i dati nel db
fastify.get('/api/autobus', async (request, reply) => {
        influx.query(`
    select * from Posizione`)
  .then( result => reply.status(200).json(result) )
  .catch( error => reply.status(500).json({ error }));
});

//inserimento dei dati nel database

fastify.post('/api/autobus/', async (request, reply) => {

    let id = request.params.id;
    try {
        let res = request.body;
        let pool = await sql.connect(config);
        await pool.query`
        INSERT 
            ${res.Long}
           ,${res.Lat}
           ,${res.Persone}
           ,${res.Porte},
           id=${res.Id}
        `
        sql.close();
        reply.status(201).send('fatto');
    }
    catch (error) {
        sql.close();
        reply.status(500).send('Errore');
        console.log(error);
    }
});

const start = async () => {
    try {
        await fastify.listen(3000)
        fastify.log.info(`server listening on ${fastify.server.address().port}`)
    } catch (err) {
        fastify.log.error(err)
        process.exit(1)
    }
}
start()