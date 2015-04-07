using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public float enemyHealth;
	public int enemyXp;
	public int enemyMoney;

	void Update(){

		if (enemyHealth <= 0) {
			int xp = PlayerPrefs.GetInt ("xp");
			int money = PlayerPrefs.GetInt("money");
			PlayerPrefs.SetInt ("xp", xp + enemyXp);
			PlayerPrefs.SetInt ("money", money + enemyMoney);
			Destroy (gameObject);
		}
	}
	
}
