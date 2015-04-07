using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectScene : MonoBehaviour {

	public GameObject startButton;
	public Transform selection;

	private int selectedScene;
	private bool isSelected;
	private Button start;
	private GameObject selectedButton;

	void Start () {
		isSelected = false;
		start = startButton.GetComponent<Button> ();
	}

	public void selectScene(int SceneToSelect){

		if (isSelected == true) {

			Button SelectedButton = selectedButton.GetComponent<Button> ();

			SelectedButton.interactable = true;

		} else {
		
			start.interactable = true;
		
		}

		string objName = "Lvl_" + (SceneToSelect - 2) + "_Button";
		GameObject obj = GameObject.Find (objName);
		Button lvlButton = obj.GetComponent<Button> ();

		lvlButton.interactable = false;
		selectedButton = obj;
		selectedScene = SceneToSelect;
		isSelected = true;

	}

	public void startScene(){

		PlayerPrefs.SetInt ("currentScene", selectedScene);
		Application.LoadLevel(selectedScene);

	
	}
}
