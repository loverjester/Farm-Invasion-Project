using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingsScript : MonoBehaviour {

	public Slider VolumeSlider;
	public GameObject SettingsMenu;
	public GameObject MainMenu;
	public GameObject unMuteButton;
	public GameObject applyConfirm;

	private float VolumePref;
	private int isMuted;


	void Start () {

		VolumePref = PlayerPrefs.GetFloat ("Volume");
		isMuted = PlayerPrefs.GetInt ("Muted");
		int level = PlayerPrefs.GetInt ("lvl");

		VolumeSlider = gameObject.GetComponent<Slider> ();

		if (isMuted == 1) 
		{
			unMuteButton.SetActive (true);
			AudioListener.volume = 0f;

		} else{
			unMuteButton.SetActive (false);
		}
		if (level == 0) {
			VolumeSlider.value = 0.5f;
			PlayerPrefs.SetFloat ("Volume", 0.5f);
			PlayerPrefs.Save ();
		} else 
		{
        	VolumeSlider.value = VolumePref;
		}

		VolumeSlider.onValueChanged.AddListener(NewVolume);
	}
	

	void NewVolume (float volume) 
	{
		if (isMuted == 0) 
		{
			AudioListener.volume = volume;
		}
	}

	public void Mute()
	{
		AudioListener.volume = 0f;
		PlayerPrefs.SetInt ("Muted", 1);
		unMuteButton.SetActive (true);
	}

	public void unMute()
	{
		AudioListener.volume = VolumeSlider.value;
		PlayerPrefs.SetInt ("Muted", 0);
		unMuteButton.SetActive (false);
	}

	public void openSettings()
	{
		if (MainMenu) 
		{
			MainMenu.SetActive (false);
		}
		SettingsMenu.SetActive (true);
	}

	public void backSettings()
	{
		if (MainMenu) 
		{
			MainMenu.SetActive (true);
		}
		SettingsMenu.SetActive (false);
	}

	public void Apply()
	{
		applyConfirm.SetActive (true);
		PlayerPrefs.SetFloat ("Volume", VolumeSlider.value);
		PlayerPrefs.Save ();
	}

	public void CloseApply()
	{
		applyConfirm.SetActive (false);
	}
}


