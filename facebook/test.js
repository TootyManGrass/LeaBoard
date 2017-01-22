var login = require("facebook-chat-api");


login({email: "EMAIL", password: "PASSWORD"}, function callback (err, api) {
    if(err) return console.error(err);

    api.listen(function callback(err, message) {
        console.log(message.body);
    });
});