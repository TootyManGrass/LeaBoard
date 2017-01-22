var net = require('net');
var responseMap = require("./ResponseMap.js");
var DataGram = require("./DataGram.js").DatagramConstructor

var globalID = 0;
var clients = [];
var removal = [];




//Creates a server
net.createServer((socket)=>{

	console.log("Connection from: ", socket.remotePort);
	clients.push(socket)

	socket.setNoDelay(true);
	socket.id = globalID ++;
	socket.state = 0;
	socket.disconnected = false;

	socket.on('data', (data) => {
		try{
			var rec = JSON.parse(data.toString().trim());
			responseMap[socket.state](socket, rec);
		} catch (err){

			
		}	
	});

	socket.on('end', function() {
      	socket.disconnected = true;
   		var clientIndex = clients.indexOf(socket);
		clients.splice(clientIndex, 1);
   	});



}).listen(5002);

console.log("Server running port 5002\n");

