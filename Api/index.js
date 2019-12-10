const fastify = require('fastify')({
    logger: true,
    ignoreTrailingSlash: true
});


fastify.register(require('./api/Sensor'), { prefix: '/api/sensor' });
fastify.register(require('./api/Autobus'), { prefix: '/api/autobus' });

const start = async () => {
    try {
        await fastify.listen(3000)
        fastify.log.info(`server listening on ${fastify.server.address().port}`)
    } catch (err) {
        fastify.log.error(err)
        process.exit(1)
    }
}
start();