using UnityEngine;
using System.Collections;

public class TextController : MonoBehaviour {
	private int numOfNewLines;
	private TextMesh screentxt;
	private GameObject rig;
	private socketScript s_script;
	public GameObject Username_Display_Text;
	private TextMesh Username_Text;

	void Start(){
		screentxt = gameObject.GetComponent<TextMesh>();
		rig = GameObject.Find("LMHeadMountedRig");
		s_script = rig.GetComponent<socketScript>();
		numOfNewLines = 0;
		Username_Text = Username_Display_Text.GetComponent<TextMesh> ();
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

	public void updateScreen_me(string text){
		text = ResolveTextSize (text, 60);

		screentxt.text = "To [" + Username_Text.text + "]: " + text +"\n"+screentxt.text;
		numOfNewLines++;
		while (numOfNewLines >= 9) {
			screentxt.text = screentxt.text.Substring (0, screentxt.text.LastIndexOf ("\n"));
			numOfNewLines--;
		}
	}

	public void updateScreen_them(string text){
		text = ResolveTextSize (text, 60);
		screentxt.text =  text + "\n" +screentxt.text;
		numOfNewLines++;
		while (numOfNewLines >= 9) {
			screentxt.text = screentxt.text.Substring (0, screentxt.text.LastIndexOf ("\n"));
			numOfNewLines--;
		}
	}

}
