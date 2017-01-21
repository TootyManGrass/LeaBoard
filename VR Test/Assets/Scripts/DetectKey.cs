using UnityEngine;
using System.Collections;

public class DetectKey : MonoBehaviour {
	private float prevTime;
	private string letter;

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Button" && Time.realtimeSinceStartup - prevTime > 0.3) {
			string letter = other.name;
			Debug.Log (letter);
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.tag == "Button" && Time.realtimeSinceStartup - prevTime > 0.3) {
			prevTime = Time.realtimeSinceStartup;
		}
	}
}
