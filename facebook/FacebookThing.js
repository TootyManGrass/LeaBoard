/**
 * Created by Ray on 2017-01-21.
 */

var readline = require('readline');
var login = require("facebook-chat-api");

var rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

rl.question("What is your email and password? \n", function lambda(answer) {
    var string = answer.split(' ');
    var email = string[0];
    var password = string[1];
    console.log("Thank you for your valuable feedback:", answer);

    login({email: email, password: password}, function callback (err, api) {
        if(err) {
            rl.question("What is your email and password? \n", lambda);
        }
        else{

            api.getUserID("Tony Kung", function(err, data) {
                if(err) return callback(err);
                var threadID = data[0].userID;
                api.sendMessage('sampleMessage', threadID);
            });
        }
    });
    //rl.close();
    //process.stdin.destroy();
});
