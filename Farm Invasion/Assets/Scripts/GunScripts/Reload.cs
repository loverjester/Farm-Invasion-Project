using UnityEngine;
using System.Collections;

public class Reload : MonoBehaviour {

	private GunShoot gunShoot;
	
	void Start () {

		gunShoot = GameObject.FindGameObjectWithTag ("Ammo").GetComponent<GunShoot> ();
	
	}

	void OnClick(){
	
		print ("click");
		gunShoot.ForceReload ();
	
	}
}
