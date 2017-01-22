using UnityEngine;
using System.Collections;

public class ButtonResponse : MonoBehaviour {
	public Material activeMat;
	private Material defaultMat;
	private MeshRenderer gameObjectRenderer;

	void Start() {
		gameObjectRenderer = GetComponent<MeshRenderer> ();
		defaultMat = gameObjectRenderer.material;
	}

	void OnTriggerEnter (Collider other) {
		if (other.name == "bone3" && other.transform.parent.name == "index" && other.transform.parent.transform.parent.name == "RigidRoundHand_R") {
		Debug.Log (other.name);	
		Debug.Log (other.transform.parent.name);
		gameObjectRenderer.material = activeMat;
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.name == "bone3" && other.transform.parent.name == "index" && other.transform.parent.transform.parent.name == "RigidRoundHand_R") {
			gameObjectRenderer.material = defaultMat;
		}
	}
}
