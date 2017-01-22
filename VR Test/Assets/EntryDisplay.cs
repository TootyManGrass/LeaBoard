using UnityEngine;
using System.Collections;

public class EntryDisplay : MonoBehaviour {

	public GameObject username_disp;
	private UsernameDisplay displayscript;
	private MeshRenderer displayrend;

	public Material activeMat;
	private Material defaultMat;
	private MeshRenderer gameObjectRenderer;
	// Use this for initialization
	void Start () {
		displayscript = username_disp.GetComponent<UsernameDisplay> ();
		gameObjectRenderer = GetComponent<MeshRenderer> ();
		displayrend = username_disp.GetComponent<MeshRenderer> ();
		defaultMat = gameObjectRenderer.material;
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
		if (other.name == "bone3" && other.transform.parent.name == "index" && other.transform.parent.transform.parent.name == "RigidRoundHand_R") {
			displayscript.writeUsername = false;
			gameObjectRenderer.material = activeMat;
			displayrend.material = defaultMat;
			//rend.material.color = Color.yellow;
		}
	}
}
