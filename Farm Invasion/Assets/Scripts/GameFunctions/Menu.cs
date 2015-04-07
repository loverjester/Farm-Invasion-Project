using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Menu : MonoBehaviour {

	public GameObject MenuOpen;
	public GameObject MenuPause;

	private bool canPause;
	
	void Start() {

		PlayerPrefs.SetInt("isPaused", 0);
		canPause = true;

	}

public void menuPause () {

		if (canPause) {

			MenuOpen.SetActive(false);
			MenuPause.SetActive(true);
			canPause = false;
			PlayerPrefs.SetInt("isPaused", 1);
			Time.timeScale = 0;

		}
	}

public void menuResume() {
	
		if (!canPause) {

			MenuOpen.SetActive(true);
			MenuPause.SetActive(false);
			canPause = true;
			PlayerPrefs.SetInt("isPaused", 0);
		    Time.timeScale = 1;

		}
	}
}
