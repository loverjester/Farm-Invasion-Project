using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ActualXp : MonoBehaviour {

	void Update () {

		setXpValue ();
	
	}

	void setXpValue() {
	    int actualXp = PlayerPrefs.GetInt ("xp");
		int maxXp = PlayerPrefs.GetInt ("xpNext");
		Slider xpSlider = gameObject.GetComponent<Slider> ();
		
		if (actualXp != xpSlider.value) {	

			xpSlider.value = actualXp;
		}
		if (maxXp != xpSlider.maxValue) {
		
			xpSlider.maxValue = maxXp;
		}
	}

}

