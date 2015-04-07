using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GunShoot : MonoBehaviour {

	public GameObject ak47;
	public GameObject M4;
	public GameObject AlienRifle;
	public GameObject Glock21;
	public GameObject DesertEagle;
	public GameObject AlienPistol;
	public GameObject Mauser;
	public GameObject Dragunov;
	public GameObject AlienSniper;

	public GameObject pistolAmmo;
	public GameObject ak47Ammo;
	public GameObject sniperAmmo;

	public GameObject SelectedAmmo1;
	public GameObject SelectedAmmo2;
	public GameObject SelectedAmmo3;

	public GameObject reloadingSlider;

	public Transform Glock21Equip;
	public Transform DesertEagleEquip;
	public Transform AlienPistolEquip;
	public Transform Ak47Equip;
	public Transform M4Equip;
	public Transform AlienRifleEquip;
	public Transform MauserEquip;
	public Transform DragunovEquip;
	public Transform AlienSniperEquip;

	public Transform EquipSlot1;
	public Transform EquipSlot2;
	public Transform EquipSlot3;
	public Transform gunParent;

	public int ActualAmmoCount;
	public int MaxAmmoCount;

	public int pooledAmount1;
	public int pooledAmount2;
	public int pooledAmount3;

	public float CooldownTime;
	public float Cooldown;
	public float ReloadTime;
	public float Reload;

	public bool isShooting;
	public bool isReloading;
	
	public List<GameObject> ammosPool1;
	public List<GameObject> ammosPool2;
	public List<GameObject> ammosPool3;

	public List<GameObject> selectedAmmosPool;

	private int isPaused;

	private bool hasWeapon1;
	private bool hasWeapon3;
	
	void Start(){

		Time.timeScale = 1;
		isReloading = false;
		PlayerPrefs.SetInt ("isPaused", 0);
		string SelectedGun1 = PlayerPrefs.GetString ("currentGun1");
		string SelectedGun2 = PlayerPrefs.GetString ("currentGun2");
		string SelectedGun3 = PlayerPrefs.GetString ("currentGun3");

		// 1st weapon
		if (SelectedGun1 != "") {

			hasWeapon1 = true;
		
			if (SelectedGun1 == "Ak47") {
				ak47.SetActive (true);
				Ak47Equip.position = EquipSlot1.position;
				Ak47Equip.GetComponent<Button> ().interactable = false;
				Ak47Equip.gameObject.SetActive (true);
				SelectedAmmo1 = ak47Ammo;
				ActualAmmoCount = 30;
				MaxAmmoCount = 30;
				pooledAmount1 = 10;
				CooldownTime = 0.4f;
				ReloadTime = 4f;
			}
			if (SelectedGun1 == "M4") {
				M4.SetActive (true);
				M4Equip.position = EquipSlot1.position;
				M4Equip.GetComponent<Button> ().interactable = false;
				M4Equip.gameObject.SetActive (true);
				SelectedAmmo1 = ak47Ammo;
				ActualAmmoCount = 30;
				MaxAmmoCount = 30;
				pooledAmount1 = 10;
				CooldownTime = 0.3f;
				ReloadTime = 3f;
			}
			if (SelectedGun1 == "Alien Rifle") {
				AlienRifle.SetActive (true);
				AlienRifleEquip.position = EquipSlot1.position;
				AlienRifleEquip.GetComponent<Button> ().interactable = false;
				AlienRifleEquip.gameObject.SetActive (true);
				SelectedAmmo1 = ak47Ammo;
				ActualAmmoCount = 60;
				MaxAmmoCount = 60;
				pooledAmount1 = 20;
				CooldownTime = 0.2f;
				ReloadTime = 2f;
			}
		}

		// 2nd weapon

		if (!hasWeapon1 && SelectedGun2 == "Glock21") 
		{
			Glock21.SetActive (true);
			Glock21Equip.position = EquipSlot2.position;
			Glock21Equip.GetComponent<Button> ().interactable = false;
			Glock21Equip.gameObject.SetActive (true);
			SelectedAmmo2 = pistolAmmo;
			
			ActualAmmoCount = 10;
			MaxAmmoCount = 10;
			pooledAmount2 = 5;
			CooldownTime = 1f;
			ReloadTime = 2f;
		} 
		if (hasWeapon1 && SelectedGun2 == "Glock21") 
		{
				pooledAmount2 = 5;
				SelectedAmmo2 = pistolAmmo;
			    Glock21Equip.position = EquipSlot2.position;
			    Glock21Equip.gameObject.SetActive(true);
		}
		if (!hasWeapon1 && SelectedGun2 == "Desert Eagle") 
		{
			DesertEagle.SetActive (true);
			DesertEagleEquip.position = EquipSlot2.position;
			DesertEagleEquip.GetComponent<Button> ().interactable = false;
			DesertEagleEquip.gameObject.SetActive (true);
			SelectedAmmo2 = pistolAmmo;
			
			ActualAmmoCount = 7;
			MaxAmmoCount = 7;
			pooledAmount2 = 5;
			CooldownTime = 2f;
			ReloadTime = 3.5f;
		} 
		if (hasWeapon1 && SelectedGun2 == "Desert Eagle") 
		{
			pooledAmount2 = 5;
			SelectedAmmo2 = pistolAmmo;
			DesertEagleEquip.position = EquipSlot2.position;
			DesertEagleEquip.gameObject.SetActive(true);
		}
		if (!hasWeapon1 && SelectedGun2 == "Alien Pistol") 
		{
			AlienPistol.SetActive (true);
			AlienPistolEquip.position = EquipSlot2.position;
			AlienPistolEquip.GetComponent<Button> ().interactable = false;
			AlienPistolEquip.gameObject.SetActive (true);
			SelectedAmmo2 = pistolAmmo;
			
			ActualAmmoCount = 20;
			MaxAmmoCount = 20;
			pooledAmount2 = 10;
			CooldownTime = 0.5f;
			ReloadTime = 2f;
		} 
		if (hasWeapon1 && SelectedGun2 == "Alien Pistol") 
		{
			pooledAmount2 = 10;
			SelectedAmmo2 = pistolAmmo;
			AlienPistolEquip.position = EquipSlot2.position;
			AlienPistolEquip.gameObject.SetActive(true);
		}

		// 3rd weapon
		if (SelectedGun3 != "") {

			hasWeapon3 = true;

			if (SelectedGun3 == "Mauser") {
				pooledAmount3 = 5;
				SelectedAmmo3 = sniperAmmo;
				MauserEquip.position = EquipSlot3.position;
				MauserEquip.gameObject.SetActive(true);
			}
			if (SelectedGun3 == "Dragunov") {
				pooledAmount3 = 5;
				SelectedAmmo3 = sniperAmmo;
				DragunovEquip.position = EquipSlot3.position;
				DragunovEquip.gameObject.SetActive(true);
			}
			if (SelectedGun3 == "Alien Sniper") {
				pooledAmount3 = 5;
				SelectedAmmo3 = sniperAmmo;
				AlienSniperEquip.position = EquipSlot3.position;
				AlienSniperEquip.gameObject.SetActive(true);
			}
		}

		//Ammo pools

	    //Ammo pool 1

		if (hasWeapon1) {
			ammosPool1 = new List<GameObject> ();
			for (int i = 0; i < pooledAmount1; i++) {
			
				GameObject ammoObject1 = (GameObject)Instantiate (SelectedAmmo1);
				ammoObject1.SetActive (false);
				ammosPool1.Add (ammoObject1);
			}
		}

	    //Ammo pool 2

	    ammosPool2 = new List<GameObject> ();
	    for (int i = 0; i < pooledAmount2; i++) {
		
		GameObject ammoObject2 = (GameObject)Instantiate(SelectedAmmo2);
		ammoObject2.SetActive(false);
		ammosPool2.Add(ammoObject2);
	    }

	    //Ammo pool 3

		if (hasWeapon3) {
			ammosPool3 = new List<GameObject> ();
			for (int i = 0; i < pooledAmount3; i++) {
			
				GameObject ammoObject3 = (GameObject)Instantiate (SelectedAmmo3);
				ammoObject3.SetActive (false);
				ammosPool3.Add (ammoObject3);
			}
		}

	if (hasWeapon1) {
			selectedAmmosPool = ammosPool1;
		} else {
			selectedAmmosPool = ammosPool2;
		}

		Reload = 0f;
	
	}

	void Update ()
	{
		isPaused = PlayerPrefs.GetInt ("isPaused");

		Cooldown -= Time.deltaTime;

		if (ActualAmmoCount <= 0 && isPaused == 0 && isReloading == false)
		{
			reloadingSlider.SetActive(true);
			isReloading = true;
		}
		if (isReloading == true && isPaused == 0 && Reload >= ReloadTime) 
		{
			ActualAmmoCount = MaxAmmoCount;
			Reload = 0f;
			reloadingSlider.SetActive (false);
			isReloading = false;
		}

		if (isReloading == true) 
		{
			Reload += Time.deltaTime;
		}
	}

	public void ShootBullet(){

		if (isPaused == 0 && ActualAmmoCount > 0 && isReloading == false && Cooldown <= 0) {

				Cooldown = CooldownTime;

				ActualAmmoCount -= 1;

				float mouseX = Input.mousePosition.x;
				float mouseY = Input.mousePosition.y;

				Vector3 target = Camera.main.ScreenToWorldPoint (new Vector3 (mouseX, mouseY, 10));

				transform.LookAt (target);
				float X = 0.0f;
				float Y = 0.0f;
				float Z = transform.rotation.z;
				float W = transform.rotation.w;

				Quaternion transformRot = new Quaternion (X, Y, Z, W);

				for (int i = 0; i < selectedAmmosPool.Count; i++) {
				if (!selectedAmmosPool [i].activeInHierarchy) {
					 selectedAmmosPool [i].transform.position = transform.position;
					 selectedAmmosPool [i].transform.rotation = transformRot;
					 selectedAmmosPool [i].SetActive (true);
						break;
					}
				}
			if (ActualAmmoCount <= 0)
			{
				ForceReload();
			}
		  
		} 
    }

	public void ForceReload(){
	
		if (ActualAmmoCount != MaxAmmoCount) {

			reloadingSlider.SetActive (true);
			isReloading = true;
		}
	
	}
	
}