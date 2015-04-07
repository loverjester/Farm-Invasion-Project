using UnityEngine;
using System.Collections;

public class NonShootableZone : MonoBehaviour {

	private GunShoot gunShoot;

	void Start () {

		gunShoot = GameObject.FindGameObjectWithTag ("Ammo").GetComponent<GunShoot>();
	
	}

	void OnMouseEnter () {

		bool isShooting = gunShoot.isShooting;

		if (isShooting) {
		
			gunShoot.CancelInvoke ("ShootBullet");
			gunShoot.isShooting = false;
		
		}
	
	}
}
