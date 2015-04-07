using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AmmoCountText : MonoBehaviour {

	public Slider reloadSlider;

	private GunShoot gunShoot;
	private Text countText;


	void Start (){
	
		gunShoot = GameObject.FindGameObjectWithTag("Ammo").GetComponent<GunShoot>();
		countText = gameObject.GetComponent<Text> ();
	
	}
	
	void Update () {

		string newCountText = (gunShoot.ActualAmmoCount + " / " + gunShoot.MaxAmmoCount);

		if (newCountText != countText.text) {
		
			countText.text = newCountText;
		}

		if (reloadSlider.maxValue != gunShoot.ReloadTime) 
		{
			reloadSlider.maxValue = gunShoot.ReloadTime;
		}
		if (reloadSlider.value != gunShoot.Reload) 
		{

			reloadSlider.value = gunShoot.Reload;
		}
	
	
	}
}
