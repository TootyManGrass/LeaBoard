using UnityEngine;
using System.Collections;

public class UsernameDisplay : MonoBehaviour {

	private Renderer rend;

	public bool writeUsername;

	public Material activeMat;
	private Material defaultMat;
	private MeshRenderer gameObjectRenderer;

	public GameObject display;
	private MeshRenderer displayrend;

	void Start() {
		//writeUsername = gameObject.GetComponent<UsernameDisplay>().writeUsername;
		//userDisplay = GetComponent<UsernameDisplay>();

		//rend = GetComponent<Renderer>();

		gameObjectRenderer = GetComponent<MeshRenderer> ();
		defaultMat = gameObjectRenderer.material;
		writeUsername = false;
		displayrend = display.GetComponent<MeshRenderer> ();
		displayrend.material = activeMat;
	}

	void OnTriggerEnter (Collider other) {
		if (other.name == "bone3" && other.transform.parent.name == "index" && other.transform.parent.transform.parent.name == "RigidRoundHand_R") {
			writeUsername = true;
			gameObjectRenderer.material = activeMat;
			displayrend.material = defaultMat;
			//rend.material.color = Color.yellow;
		}
	}


}
