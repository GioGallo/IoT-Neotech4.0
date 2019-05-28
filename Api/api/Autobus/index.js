const sql = require("mssql");
const config = require('config');

const configs = {
    user: config.get('userMssql'),
    password: config.get('password'),
    server: config.get('server'),
    database: config.get('databaseMssql'),
    option: {
        encrypt: true
    }
};
async function routes (fastify, options) {
fastify.get('/', async (request, reply) => {
    try {   
        sql.close();
        let pool = await sql.connect(configs);
        let result = await pool.request().query('Select * from Autobus');
        sql.close();
        return result.recordset;
    } catch (error) {
        console.log(error);
        reply.status(404).send('Errore');
        
    }
});

fastify.get('/:id', async (request, reply) => {
    
    var idp = request.params.id;
try {
    sql.close();
    let pool = await sql.connect(configs);
    let result = await pool.query(`
    Select * 
    From Autobus
    Where Id = ${idp}`);
    if (result.recordset.lenght == 0) {
        reply.status(404).send('Prodotto non trovato');
        
    }
    else {
        return result.recordset[0];
       
    }
    sql.close();
    return result.recordset;
    

} catch (error) {
    console.log(error);
    reply.status(404).send('Errore');
}

});

}
module.exports=routes;