using UnityEngine;
using System.Collections;

public class XpScript : MonoBehaviour {

	void Start () {
	
		int startLvl = PlayerPrefs.GetInt ("lvl");

		if (startLvl <= 0) {

			PlayerPrefs.SetString ("currentGun2", "Glock21");
			PlayerPrefs.SetString ("isOwnedGlock21", "true");
			PlayerPrefs.SetInt ("money", 0);
			PlayerPrefs.SetInt ("lvl", 1);
			PlayerPrefs.SetInt ("xp", 0);
			PlayerPrefs.SetInt ("xpNext", 10);
			PlayerPrefs.SetInt ("currentScene", 1);
			PlayerPrefs.SetFloat ("playerHealth", 100);

			PlayerPrefs.Save ();
		}
	}

	void Update() {
	
		levelUp ();
	
	}

	void levelUp() {

		int currentXp = PlayerPrefs.GetInt ("xp");
		int xpForNextLevel = PlayerPrefs.GetInt ("xpNext");

		if (currentXp >= xpForNextLevel) {

			int level = PlayerPrefs.GetInt ("lvl"); 

			PlayerPrefs.SetInt ("lvl", level + 1);
			PlayerPrefs.SetInt ("xp", 0);
			xpNeedIncrease();
		}
	}

	void xpNeedIncrease() {
		int xpForNextLevel = PlayerPrefs.GetInt ("xpNext");
		int newXpForNextLevel = ((int)(xpForNextLevel * 1.5));
		PlayerPrefs.SetInt("xpNext", newXpForNextLevel);
	}
}
