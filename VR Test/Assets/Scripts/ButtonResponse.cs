using UnityEngine;
using System.Collections;

public class ButtonResponse : MonoBehaviour {
	//public bool writeUsername;

	//private Renderer rend;

	//private UsernameDisplay userDisplay;

	public Material activeMat;
	private Material defaultMat;
	private MeshRenderer gameObjectRenderer;

	void Start() {
		//writeUsername = gameObject.GetComponent<UsernameDisplay>().writeUsername;
		//userDisplay = GetComponent<UsernameDisplay>();

		//rend = GetComponent<Renderer>();

		gameObjectRenderer = GetComponent<MeshRenderer> ();
		defaultMat = gameObjectRenderer.material;
	}

	void OnTriggerEnter (Collider other) {
		if (other.name == "bone3" && other.transform.parent.name == "index" && other.transform.parent.transform.parent.name == "RigidRoundHand_R") {
			gameObjectRenderer.material = activeMat;
			//rend.material.color = Color.yellow;
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.name == "bone3" && other.transform.parent.name == "index" && other.transform.parent.transform.parent.name == "RigidRoundHand_R") {
			gameObjectRenderer.material = defaultMat;
			//if (userDisplay.writeUsername) {
			//	rend.material.color = Color.white;
			//}
			//else {
			//	rend.material.color = Color.green;
			//}
		}
	}
}
