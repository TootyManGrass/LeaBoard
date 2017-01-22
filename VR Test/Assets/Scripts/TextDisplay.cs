using UnityEngine;
using System.Collections;

public class TextDisplay : MonoBehaviour {

	private Renderer rend;

	//public Material activeMat;
	//private Material defaultMat;
	//private MeshRenderer gameObjectRenderer;

	//public bool writeUsername;
	private UsernameDisplay userDisplay;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();

		userDisplay = GetComponent<UsernameDisplay>();

		//writeUsername = gameObject.GetComponent<UsernameDisplay>().writeUsername;

		//gameObjectRenderer = GetComponent<MeshRenderer> ();
		//defaultMat = gameObjectRenderer.material;
	}

	/*void OnTriggerEnter (Collider other) {
		if (other.name == "bone3" && other.transform.parent.name == "index" && other.transform.parent.transform.parent.name == "RigidRoundHand_R") {
			writeUsername = false; 
		}		
	}

	void Update() {
		if (writeUsername) {
			rend.material.color = Color.green;
		} 
		else {
			rend.material.color = Color.white;
		}
	}*/

	void OnTriggerExit (Collider other) {
		if (other.name == "bone3" && other.transform.parent.name == "index" && other.transform.parent.transform.parent.name == "RigidRoundHand_R") {
			userDisplay.writeUsername = false;
		}
	}

	void Update(){
		if (userDisplay.writeUsername) {
			//gameObjectRenderer.material = activeMat;
			rend.material.color = Color.white;
		}
		else {
			//gameObjectRenderer.material = defaultMat;
			rend.material.color = Color.green;
		}
	}
}
