using UnityEngine;
using System.Collections;

public class LetterContainerSelector : MonoBehaviour {
	public GameObject LetCon1;
	public GameObject LetCon2;
	public GameObject LetCon3;
	// Use this for initialization
	void Start () {
		LetCon1.SetActive (true);
		LetCon2.SetActive (false);
		LetCon3.SetActive (false);
	}
	
	// Update is called once per frame
	public virtual void SetCon1 () {
		Debug.Log ("setcon1");
		LetCon1.SetActive (true);
		LetCon2.SetActive (false);
		LetCon3.SetActive (false);
	}

	public virtual void SetCon2 () {
		Debug.Log ("setcon2");
		LetCon1.SetActive (false);
		LetCon2.SetActive (true);
		LetCon3.SetActive (false);
	}

	public virtual void SetCon3 () {
		Debug.Log ("setcon3");
		LetCon1.SetActive (false);
		LetCon2.SetActive (false);
		LetCon3.SetActive (true);
	}

}
