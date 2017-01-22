using UnityEngine;
using System.Collections;

public class DetectKey : MonoBehaviour
{
    private float prevTime;
    private string letter;

    private GameObject rig;
    private socketScript s_script;

    void Start()
    {
        rig = GameObject.Find("LMHeadMountedRig");
        s_script = rig.GetComponent<socketScript>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Button" && Time.realtimeSinceStartup - prevTime > 0.3)
        {
            string letter = other.name;
            Debug.Log(letter);

            int len = s_script.message.Length;
            if (letter == '-' && len != 0)
            {
                s_script.message = s_script.message.Remove(len - 1);
            }
            else
            {
                s_script.message += letter;
            }
        }
    }

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Button") {
			prevTime = Time.realtimeSinceStartup;
		}
	}
}
