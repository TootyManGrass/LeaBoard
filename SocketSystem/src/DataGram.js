module.exports = {

	DatagramConstructor : function(id, name, text, valid){
		this.id = id;
		this.data = {
			"user": name, 
			"text": text,
			"valid": valid
		};
	}


}