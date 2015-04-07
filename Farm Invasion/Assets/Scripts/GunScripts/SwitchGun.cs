using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SwitchGun : MonoBehaviour {

	private GunShoot gunShoot;

	private Transform gunsParent;

	private string ActualGun;

	private string ActualEquipedGun;
	private string NewEquipedGun;

	private int OldActualAmmo1;
	private int OldActualAmmo2;
	private int OldActualAmmo3;

	void Start () {

		gunsParent = transform.FindChild ("Guns");
		gunShoot = GameObject.FindGameObjectWithTag("Ammo").GetComponent<GunShoot> ();
		if (PlayerPrefs.GetString ("currentGun1") != "") {
			ActualEquipedGun = ("Equip" + PlayerPrefs.GetString ("currentGun1"));
			ActualGun = PlayerPrefs.GetString ("currentGun1");
		} else {
			ActualEquipedGun = ("Equip" + PlayerPrefs.GetString ("currentGun2"));
			ActualGun = PlayerPrefs.GetString ("currentGun2");
		}
	}

	public void EquipGun(string Gun)
	{
		if (gunShoot.isReloading != true) {
			if (PlayerPrefs.GetString ("currentGun1") == Gun) {
				if (ActualGun == PlayerPrefs.GetString ("currentGun2")) {
					OldActualAmmo2 = gunShoot.ActualAmmoCount;
				} else {
					OldActualAmmo3 = gunShoot.ActualAmmoCount;
				}
				gunShoot.selectedAmmosPool = gunShoot.ammosPool1;
			}
			if (PlayerPrefs.GetString ("currentGun2") == Gun) {
				if (ActualGun == PlayerPrefs.GetString ("currentGun1")) {
					OldActualAmmo1 = gunShoot.ActualAmmoCount;
				} else {
					OldActualAmmo3 = gunShoot.ActualAmmoCount;
				}
				gunShoot.selectedAmmosPool = gunShoot.ammosPool2;
			}
			if (PlayerPrefs.GetString ("currentGun3") == Gun) {
				if (ActualGun == PlayerPrefs.GetString ("currentGun1")) {
					OldActualAmmo1 = gunShoot.ActualAmmoCount;
				} else {
					OldActualAmmo2 = gunShoot.ActualAmmoCount;
				}
				gunShoot.selectedAmmosPool = gunShoot.ammosPool3;
			}
		
			NewEquipedGun = ("Equip" + Gun);
			transform.FindChild (NewEquipedGun).GetComponent<Button> ().interactable = false;
			transform.FindChild (ActualEquipedGun).GetComponent<Button> ().interactable = true;
			gunsParent.FindChild (Gun).gameObject.SetActive (true);
			gunsParent.FindChild (ActualGun).gameObject.SetActive (false);
			ActualEquipedGun = NewEquipedGun;
			ActualGun = Gun;
		}
	}
	
	public void SetAk47Stats()
	{
		if (gunShoot.isReloading != true) {
			gunShoot.MaxAmmoCount = 30;
			if (OldActualAmmo1 != gunShoot.MaxAmmoCount && OldActualAmmo1 > 0) {
				gunShoot.ActualAmmoCount = OldActualAmmo1;
			} else {
				gunShoot.ActualAmmoCount = 30;
			}
			gunShoot.CooldownTime = 0.4f;
			gunShoot.Cooldown = 0f;
			gunShoot.ReloadTime = 4f;
		}
	}
	public void SetM4Stats()
	{
		if (gunShoot.isReloading != true) {
			gunShoot.MaxAmmoCount = 30;
			if (OldActualAmmo1 != gunShoot.MaxAmmoCount && OldActualAmmo1 > 0) {
				gunShoot.ActualAmmoCount = OldActualAmmo1;
			} else {
				gunShoot.ActualAmmoCount = 30;
			}
			gunShoot.CooldownTime = 0.3f;
			gunShoot.Cooldown = 0f;
			gunShoot.ReloadTime = 3f;
		}
	}
	public void SetAlienRifleStats()
	{
		if (gunShoot.isReloading != true) {
			gunShoot.MaxAmmoCount = 60;
			if (OldActualAmmo1 != gunShoot.MaxAmmoCount && OldActualAmmo1 > 0) {
				gunShoot.ActualAmmoCount = OldActualAmmo1;
			} else {
				gunShoot.ActualAmmoCount = 60;
			}
			gunShoot.CooldownTime = 0.2f;
			gunShoot.Cooldown = 0f;
			gunShoot.ReloadTime = 2f;
		}
	}
	public void SetGlock21Stats()
	{
		if (gunShoot.isReloading != true) {
			gunShoot.MaxAmmoCount = 10;
			if (OldActualAmmo2 != gunShoot.MaxAmmoCount && OldActualAmmo2 > 0) {
				gunShoot.ActualAmmoCount = OldActualAmmo2;
			} else {
				gunShoot.ActualAmmoCount = 10;
			}
			gunShoot.CooldownTime = 1f;
			gunShoot.Cooldown = 0f;
			gunShoot.ReloadTime = 2f;
		}
	}
	public void SetDesertEagleStats()
	{
		if (gunShoot.isReloading != true) {
			gunShoot.MaxAmmoCount = 7;
			if (OldActualAmmo2 != gunShoot.MaxAmmoCount && OldActualAmmo2 > 0) {
				gunShoot.ActualAmmoCount = OldActualAmmo2;
			} else {
				gunShoot.ActualAmmoCount = 7;
			}
			gunShoot.CooldownTime = 2f;
			gunShoot.Cooldown = 0f;
			gunShoot.ReloadTime = 3.5f;
		}
	}
	public void SetAlienPistolStats()
	{
		if (gunShoot.isReloading != true) {
			gunShoot.MaxAmmoCount = 20;
			if (OldActualAmmo2 != gunShoot.MaxAmmoCount && OldActualAmmo2 > 0) {
				gunShoot.ActualAmmoCount = OldActualAmmo2;
			} else {
				gunShoot.ActualAmmoCount = 20;
			}
			gunShoot.CooldownTime = 0.5f;
			gunShoot.Cooldown = 0f;
			gunShoot.ReloadTime = 2f;
		}
	}

	public void SetMauserStats()
	{
		if (gunShoot.isReloading != true) {
			gunShoot.MaxAmmoCount = 5;
			if (OldActualAmmo3 != gunShoot.MaxAmmoCount && OldActualAmmo3 > 0) {
				gunShoot.ActualAmmoCount = OldActualAmmo3;
			} else {
				gunShoot.ActualAmmoCount = 5;
			}
			gunShoot.CooldownTime = 3f;
			gunShoot.Cooldown = 0f;
			gunShoot.ReloadTime = 6f;
		}
	}
	public void SetDragunovStats()
	{
		if (gunShoot.isReloading != true) {
			gunShoot.MaxAmmoCount = 10;
			if (OldActualAmmo3 != gunShoot.MaxAmmoCount && OldActualAmmo3 > 0) {
				gunShoot.ActualAmmoCount = OldActualAmmo3;
			} else {
				gunShoot.ActualAmmoCount = 10;
			}
			gunShoot.CooldownTime = 2f;
			gunShoot.Cooldown = 0f;
			gunShoot.ReloadTime = 4.5f;
		}
	}
	public void SetAlienSniperStats()
	{
		if (gunShoot.isReloading != true) {
			gunShoot.MaxAmmoCount = 5;
			if (OldActualAmmo3 != gunShoot.MaxAmmoCount && OldActualAmmo3 > 0) {
				gunShoot.ActualAmmoCount = OldActualAmmo3;
			} else {
				gunShoot.ActualAmmoCount = 5;
			}
			gunShoot.CooldownTime = 2f;
			gunShoot.Cooldown = 0f;
			gunShoot.ReloadTime = 4f;
		}
	}
	
}
