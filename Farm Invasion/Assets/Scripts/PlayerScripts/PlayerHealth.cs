using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public float playerHealth;

	public Slider healthSlider;
	public GameObject GameOver;

	void Start(){


		float startHealthValue = PlayerPrefs.GetFloat ("playerHealth");
		playerHealth = startHealthValue;

		healthSlider.value = startHealthValue;
		healthSlider.maxValue = startHealthValue;

	}

	void Update () {

		if (playerHealth != healthSlider.value) 
		{
			healthSlider.value = playerHealth;
		}

		if (playerHealth <= 0)
		{
			GameOver.SetActive(true);
			Time.timeScale = 0;
			PlayerPrefs.SetInt("isPaused", 1);
	    }
	}
}
