using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ActualXpText : MonoBehaviour {

	private Text actualLevelText;
	private Text actualXpText;

	void Start() {
	
		actualLevelText = transform.parent.FindChild("LevelImage").FindChild("LevelText").gameObject.GetComponent<Text>();
		actualXpText = gameObject.GetComponent<Text> ();
	}

	void Update () {
	
		setXpText ();
	}

	void setXpText(){

	    int xp = PlayerPrefs.GetInt ("xp");
		int xpForNextLevel = PlayerPrefs.GetInt ("xpNext");

		string newLevelString = PlayerPrefs.GetInt ("lvl").ToString ();
		string newXpString = ("Xp : " + xp + " / " + xpForNextLevel);

	if (newLevelString != actualLevelText.text)
		{
		actualLevelText.text = (newLevelString);
		}

	if (newXpString != actualXpText.text) 
		{
		actualXpText.text = (newXpString);
	    }
    }
}

