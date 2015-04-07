using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadScene : MonoBehaviour {

	public void loadScene(int SceneToLoad){

		PlayerPrefs.SetInt ("currentScene", SceneToLoad);
		Time.timeScale = 1;
		
		Application.LoadLevel (SceneToLoad);
	}

	public void restartScene() {
	
		int sceneToRestart = PlayerPrefs.GetInt ("currentScene");
		Time.timeScale = 1;

       	Application.LoadLevel (sceneToRestart);
	}
}
