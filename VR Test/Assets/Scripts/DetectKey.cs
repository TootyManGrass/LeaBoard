using UnityEngine;
using System.Collections;

public class DetectKey : MonoBehaviour {
	private float prevTime;
	private string letter;

    private GameObject rig;
    private socketScript s_script;

    void Start ()
    {
        rig = GameObject.Find("LMHeadMountedRig");
        s_script = rig.GetComponent<socketScript>();
    }

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Button" && Time.realtimeSinceStartup - prevTime > 0.3) {
			string letter = other.name;
			Debug.Log (letter);

            //GameObject rig = GameObject.Find("LMHeadMountedRig");
            //socketScript s_script = rig.GetComponent<socketScript>();
            s_script.message += letter;

            prevTime = Time.realtimeSinceStartup;
		}
	}
}
