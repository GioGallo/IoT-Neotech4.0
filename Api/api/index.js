const Influx=require('influx');
const influx = new Influx.InfluxDB({
    host: '192.168.101.53',
    database: 'Autobus',
    schema: [
      {
        measurement: 'Posizione2',
        fields: { Aperte: Influx.FieldType.BOOLEAN,
            Latitudine: Influx.FieldType.FLOAT,
            Longitudine: Influx.FieldType.FLOAT,
        Persone: Influx.FieldType.INTEGER },
        tags: ['Id']
      }
    ]
  });


async function routes (fastify, options) {
    fastify.post('/', async (request, reply) => {
        var data=request.body;
        //console.log(JSON.stringify(data));

        influx.getDatabaseNames()
        .then(names => {
          if (!names.includes('Autobus')) {
            return influx.createDatabase('Autobus');
          }
        })
        .then(() => {
        
          var timestamp=data.orario;
          influx.writePoints([
              {
                measurement: 'Posizione2',
                tags: {
                    Id:data.id
                },
                fields: {Aperte: data.Aperto,
                    Latitudine: data.latitudine,
                    Longitudine: data.longitudine,
                Persone: data.persone},
                timestamp: timestamp,
              }
            ], {
              database: 'Autobus'
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
