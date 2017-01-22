var Datagram = require("./DataGram.js").DatagramConstructor
var facebookScripts = require("../../facebook/FacebookThing.js")
module.exports = {
	0: (socket, data)=>{
		console.log(data);
		var credentials = {"email" : data.user, "password" : data.text};

		facebookScripts.login(credentials).then(
			(api) => {

				socket.api = api;
				socket.state = 1;
				return facebookScripts.recieveMessage(api, socket);
			}, (err) => {
				var obj = new DataGram(
					socket.id,
					"xd",
					"xdAgain",
					false
				);
				socket.write(JSON.stringify(obj.data) + "\n");
			}
		);
			
	},
	1: (socket, data)=>{
		facebookScripts.sendMessage(socket.api, data);
		return new Datagram(socket.id, data.name, data.text, true);
	}
}