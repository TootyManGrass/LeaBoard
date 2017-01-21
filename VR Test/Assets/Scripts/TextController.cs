using UnityEngine;
using System.Collections;

public class TextController : MonoBehaviour {

	private TextMesh screentxt;
	private GameObject rig;
	private socketScript s_script;

	void Start(){
		screentxt = gameObject.GetComponent<TextMesh>();
		rig = GameObject.Find("LMHeadMountedRig");
		s_script = rig.GetComponent<socketScript>();
	}

	// Wrap text by line height
	private string ResolveTextSize(string input, int lineLength){
		string[] words = input.Split(" "[0]);
		string result = "";
		string line = "";

		foreach(string s in words){
			string temp = line + " " + s;

			if(temp.Length > lineLength){
				result += line + "\n";
				line = s;
			}

			else {
				line = temp;
			}
		}

	 	result += line;

	 	return result.Substring(1,result.Length-1);
	}

	public void updateScreen(string text){
		text = ResolveTextSize (text, 21);
		screentxt.text += text;
	}


}
