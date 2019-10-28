const Influx=require('influx');
const config = require('config');
const influx = new Influx.InfluxDB({
    host: config.get('hostInflux'),
    database: config.get('databaseInflux'),
    schema: [
      {
        measurement: 'Posizione3',
        fields: { 
            Velocità:Influx.FieldType.INTEGER,
            Aperte: Influx.FieldType.BOOLEAN,
            Latitudine: Influx.FieldType.FLOAT,
            Longitudine: Influx.FieldType.FLOAT,
        Persone: Influx.FieldType.INTEGER },
        tags: ['Id']
      }
    ]
  });


async function routes (fastify, options) {
  fastify.get('/', async (request, reply) => {
    try {   
        return influx.query(`select * from Posizione3 order by time desc limit 1 `);
    } catch (error) {
        console.log(error);
        reply.status(400).send('Errore');
        
    }
});

  fastify.post('/', async (request, reply) => {
        var data=request.body;
        //console.log(JSON.stringify(data));

        influx.getDatabaseNames()
        .then(names => {
          if (!names.includes(config.get('databaseInflux'))) {
            return influx.createDatabase(config.get('databaseInflux'));
          }
        })
        .then(() => {
        
          var timestamp=data.orario;
          influx.writePoints([
              {
                measurement: 'Posizione3',
                tags: {
                    Id:data.id
                },
                fields: {
                    Velocità:data.Velocità,
                    Aperte: data.Aperto,
                    Latitudine: data.latitudine,
                    Longitudine: data.longitudine,
                Persone: data.Persone},
                timestamp: timestamp,
              }
            ], {
              database: config.get('databaseInflux')
            }).then(function(){
              reply.code(200).send();
              console.log("Query avvenuta con successo-----------------------------------------------");
            })
            .catch(error => {
              //console.error(`Error saving data to InfluxDB! ${err.stack}`)
              console.log("                              ERRORE:                                                                  "+error);
              reply.code(500).send(error);
              
          });
        })
        .catch(error => console.log({ error }));
    });
}
module.exports=routes;
