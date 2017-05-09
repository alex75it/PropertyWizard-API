var server = require("./server");

server.start(function(){
    console.log("Sever running at:" + server.info.uri);
});