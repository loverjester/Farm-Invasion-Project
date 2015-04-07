using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ActualMoney : MonoBehaviour {

	void Update () {

		setMoneyText ();
	}

	void setMoneyText () {
		
		int actualMoney = PlayerPrefs.GetInt ("money");
		string newString = ("Money : " + actualMoney);
		Text actualMoneyText = gameObject.GetComponent<Text> ();
		
		if (newString != actualMoneyText.text) {
			
			actualMoneyText.text = (newString);
		}
	}
}
