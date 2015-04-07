using UnityEngine;
using System.Collections;

public class ShootableZone : MonoBehaviour {

	private GunShoot gunShoot;

	void Start () {

		gunShoot = GameObject.FindGameObjectWithTag("Ammo").GetComponent<GunShoot> ();
	
	}

	void OnMouseDown () {

		gunShoot.isShooting = true;
		float cooldownTime = (gunShoot.CooldownTime + 0.03f);
		gunShoot.InvokeRepeating ("ShootBullet", 0, cooldownTime);
	 
	}

	void OnMouseUp() {

		gunShoot.isShooting = false;
		gunShoot.CancelInvoke ("ShootBullet");
	
	}
}
