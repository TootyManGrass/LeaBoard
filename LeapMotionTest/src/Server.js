var net = require('net');


var globalID = 0;
var clients = [];
var backLog = [];
var removal = [];

var Datagram = require("./DataGram.js").DatagramConstructor


function broadCast(){
	clients.forEach((client)=>{
		if (!client.disconnected){
			for (var i in backLog){
				var data = backLog[i];
				if (data.id != client.id)
					client.write();
			}
		}
	});
	removal.forEach((client)=>{
		var clientIndex = clients.indexOf(client);
		clients.splice(clientIndex, 1);
	})
	removal.splice(0, removal.length);
}

setInterval(broadCast,100);

//Creates a server
net.createServer((socket)=>{

	console.log("Connection from: ", socket.remotePort);
	clients.push(socket)


	socket.id = globalID ++;
	socket.disconnected = false;

	socket.on('data', (data) => {
		var tmp = data.toString();
		console.log(tmp);
		backLog.push(new Datagram(socket.id, tmp));
	});

	socket.on('disconnect', function() {
      	console.log('Got disconnect!');
      	socket.disconnected = true;
   		removal.add(socket);
   	});



}).listen(5000, '127.0.0.1');

console.log("Server running port 5000\n");

