var Hapi = require("Hapi");

var server = new Hapi.Server();

server.connection({
    port: 3001
});

server.route({
    method: "GET",
    path: "/",
    handler: function(request, response) {
        response("Web API");
    }
});

module.exports = server;