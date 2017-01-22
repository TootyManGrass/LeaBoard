using UnityEngine;
using System.Collections;

public class DetectKey : MonoBehaviour {
	private float prevTime;
	private string letter;

	void OnTriggerEnter (Collider other) {
		if (Time.realtimeSinceStartup - prevTime > 0.3) {
			string letter = other.name;
			Debug.Log (letter);
			prevTime = Time.realtimeSinceStartup;
		}
	}
}
