var net = require('net');
var responseMap = require("./ResponseMap.js");
var DataGram = require("./DataGram.js").DatagramConstructor

var globalID = 0;
var clients = [];
var backLog = [];
var removal = [];



function broadCast(){
	clients.forEach((client)=>{
		if (!client.disconnected){
			for (var i in backLog){
				var data = backLog[i];
				if (data.id != client.id){
					try {
						var obj = JSON.stringify(data.data+"\n");
						client.write(obj);
					} catch (err){

					}
				}
			}
		}
	});
	removal.forEach((client)=>{
		var clientIndex = clients.indexOf(client);
		if (client.disconnected)
			clients.splice(clientIndex, 1);
	})
	removal.length = 0;
	backLog.length = 0;
}

setInterval(broadCast,100);

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

	socket.on('disconnect', function() {
      	console.log('Got disconnect!');
      	socket.disconnected = true;
   		removal.add(socket);
   	});



}).listen(5002);

console.log("Server running port 5002\n");

