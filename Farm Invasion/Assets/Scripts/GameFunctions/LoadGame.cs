using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadGame : MonoBehaviour {

	public GameObject MainMenu;
	public GameObject LoadConfirmMenu;
	public GameObject NewGameConfirmMenu;

	public void loadGame(){

		int level = PlayerPrefs.GetInt ("lvl");
			
		if (level == 0) {

			MainMenu.SetActive (false);
			LoadConfirmMenu.SetActive (true);
			
		} else {
			PlayerPrefs.SetInt ("currentScene", 1);
			Application.LoadLevel (1);

		}

	}

	public void newGame(){
		
		PlayerPrefs.DeleteAll ();
		PlayerPrefs.SetInt ("lvl", 0);
		PlayerPrefs.SetInt ("currentScene", 1);
		PlayerPrefs.Save ();
		
		Application.LoadLevel (1);
	}

	public void NewGameMenu(){

		MainMenu.SetActive (false);
		NewGameConfirmMenu.SetActive (true);
	}

	public void backNewGame(){
		MainMenu.SetActive (true);
		NewGameConfirmMenu.SetActive (false);
	}

	public void back(){

		MainMenu.SetActive (true);
		LoadConfirmMenu.SetActive (false);
	}
	
}
