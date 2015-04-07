using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShopScript : MonoBehaviour {
	
	public GameObject Buy;
	public GameObject Equip;

	public GameObject Glock21;
	public GameObject DesertEagle;
	public GameObject AlienPistol;
	public GameObject Ak47;
	public GameObject M4;
	public GameObject AlienRifle;
	public GameObject Mauser;
	public GameObject Dragunov;
	public GameObject AlienSniper;

	public Text DesertEagleOwnedText;
	public Text AlienPistolOwnedText;
	public Text Ak47OwnedText;
	public Text M4OwnedText;
	public Text AlienRifleOwnedText;
	public Text MauserOwnedText;
	public Text DragunovOwnedText;
	public Text AlienSniperOwnedText;

	private Button BuyButton;
	private Button EquipButton;

	private Text buyText;
	
	private GameObject selectedButton1;
	private GameObject selectedButton2;
	private GameObject selectedButton3;

	private GameObject OldEquipedBg1;
	private GameObject OldEquipedBg2;
	private GameObject OldEquipedBg3;

	private GameObject OldButton1;
	private GameObject OldButton2;
	private GameObject OldButton3;

	private GameObject currentSelection;

	private string newEquipString;
	private string gunToSelect;
	private string selectedGun;

	void Start () {

		string CurrentGunPref1 = PlayerPrefs.GetString ("currentGun1");
		string CurrentGunPref2 = PlayerPrefs.GetString ("currentGun2");
		string CurrentGunPref3 = PlayerPrefs.GetString ("currentGun3");

		buyText = Buy.GetComponentInChildren<Text>();
		BuyButton = Buy.GetComponent<Button> ();
		EquipButton = Equip.GetComponent<Button> ();

		if (CurrentGunPref1 != "") 
		{
			if(CurrentGunPref1 == "Ak47")
			{
				selectedButton1 = Ak47;
			}
			if(CurrentGunPref1 == "M4")
			{
				selectedButton1 = M4;
			}
			if(CurrentGunPref1 == "Alien Rifle")
			{
				selectedButton1 = AlienRifle;
			}
			selectedButton1.GetComponent<Button> ().interactable = false;
			selectedButton1.GetComponent<Image>().color = Color.green;

			string EquipedBgString1 = (CurrentGunPref1 + "_TextEquipedBg");

			OldEquipedBg1 = selectedButton1.transform.FindChild (EquipedBgString1).gameObject;
			OldEquipedBg1.SetActive (true);
			OldButton1 = selectedButton1;
		}

		if (CurrentGunPref2 == "Glock21") 
		{
			selectedButton2 = Glock21;
		}
		if (CurrentGunPref2 == "Desert Eagle") 
		{
			selectedButton2 = DesertEagle;
		}
		if (CurrentGunPref2 == "Alien Pistol") 
		{
			selectedButton2 = AlienPistol;
		}
			selectedButton2.GetComponent<Button> ().interactable = false;
		    selectedButton2.GetComponent<Image>().color = Color.green;

		    string EquipedBgString2 = (CurrentGunPref2 + "_TextEquipedBg");

			OldEquipedBg2 = selectedButton2.transform.FindChild (EquipedBgString2).gameObject;
			OldEquipedBg2.SetActive (true);
		    OldButton2 = selectedButton2;

		if (CurrentGunPref3 != "") 
		{
			if (CurrentGunPref3 == "Mauser")
			{
				selectedButton3 = Mauser;
			}
			if (CurrentGunPref3 == "Dragunov")
			{
				selectedButton3 = Dragunov;
			}
			if (CurrentGunPref3 == "Alien Sniper")
			{
				selectedButton3 = AlienSniper;
			}
			selectedButton3.GetComponent<Button> ().interactable = false;
			selectedButton3.GetComponent<Image>().color = Color.green;

			string EquipedBgString3 = (CurrentGunPref3 + "_TextEquipedBg");

			OldEquipedBg3 = selectedButton3.transform.FindChild (EquipedBgString3).gameObject;
			OldEquipedBg3.SetActive (true);
			OldButton3 = selectedButton3;
		}

		if (PlayerPrefs.GetString ("isOwnedDesert Eagle") == "true")
		{
			DesertEagleOwnedText.text = "Desert Eagle - Owned";
		}
		if (PlayerPrefs.GetString ("isOwnedAlien Pistol") == "true")
		{
			AlienPistolOwnedText.text = "Alien Pistol - Owned";
		}
		if (PlayerPrefs.GetString ("isOwnedAk47") == "true")
		{
			Ak47OwnedText.text = "Ak47 - Owned";
        }
		if (PlayerPrefs.GetString ("isOwnedM4") == "true")
		{
			M4OwnedText.text = "M4 - Owned";
		}
		if (PlayerPrefs.GetString ("isOwnedAlien Rifle") == "true")
		{
			AlienRifleOwnedText.text = "Alien Rifle - Owned";
		}
		if (PlayerPrefs.GetString ("isOwnedMauser") == "true")
		{
			MauserOwnedText.text = "Mauser - Owned";
		}
		if (PlayerPrefs.GetString ("isOwnedDragunov") == "true")
		{
			DragunovOwnedText.text = "Dragunov - Owned";
		}
		if (PlayerPrefs.GetString ("isOwnedAlien Sniper") == "true")
		{
		    AlienSniperOwnedText.text = "Alien Sniper - Owned";
		}
		
	}

	public void selectGun(string GunToSelect) {

		string isOwned = ("isOwned" + GunToSelect);
		string isOwnedString = PlayerPrefs.GetString (isOwned);
		string currentGun1 = PlayerPrefs.GetString ("currentGun1");
		string currentGun2 = PlayerPrefs.GetString ("currentGun2");
		string currentGun3 = PlayerPrefs.GetString ("currentGun3");

		if (isOwnedString == "true") 
		{		
			EquipButton.interactable = true;
			BuyButton.interactable = false;
		} else
		{
			EquipButton.interactable = false;
			BuyButton.interactable = true;
		}

		if (currentSelection != null){ 
			if(selectedGun != currentGun1 && selectedGun != currentGun2 && selectedGun != currentGun3) {
		
			currentSelection.GetComponent<Button>().interactable = true;
			}
		}

		setBuyText ();

		if (GunToSelect == "Ak47" || GunToSelect == "M4" || GunToSelect == "Alien Rifle") 
		{
			newEquipString = "currentGun1";
		}
		if (GunToSelect == "Glock21" || GunToSelect == "Desert Eagle" || GunToSelect == "Alien Pistol") 
		{
			newEquipString = "currentGun2";
		}
		if (GunToSelect == "Mauser" || GunToSelect == "Dragunov" || GunToSelect == "Alien Sniper") 
		{
			newEquipString = "currentGun3";
		}

		GameObject obj = transform.FindChild ("Background").FindChild (GunToSelect).gameObject;

		obj.GetComponent<Button> ().interactable = false;
		currentSelection = obj;
		selectedGun = GunToSelect;
		
	}

	public void equipGun(){

		if (newEquipString == "currentGun1" && OldEquipedBg1 != null) 
		{
			OldEquipedBg1.SetActive (false);
			OldButton1.GetComponent<Button>().interactable = true;
			OldButton1.GetComponent<Image>().color = Color.white;
			OldEquipedBg1 = currentSelection.transform.FindChild (selectedGun + "_TextEquipedBg").gameObject;
			OldEquipedBg1.SetActive (true);
			OldButton1 = currentSelection;
			OldButton1.GetComponent<Image>().color = Color.green;
		}
		if (newEquipString == "currentGun2" && OldEquipedBg2 != null) 
		{
			OldEquipedBg2.SetActive (false);
			OldButton2.GetComponent<Button>().interactable = true;
			OldButton2.GetComponent<Image>().color = Color.white;
			OldEquipedBg2 = currentSelection.transform.FindChild (selectedGun + "_TextEquipedBg").gameObject;
			OldEquipedBg2.SetActive(true);
			OldButton2 = currentSelection;
			OldButton2.GetComponent<Image>().color = Color.green;
		}
		if (newEquipString == "currentGun3" && OldEquipedBg3 != null) 
		{
			OldEquipedBg3.SetActive (false);
			OldButton3.GetComponent<Button>().interactable = true;
			OldButton3.GetComponent<Image>().color = Color.white;
			OldEquipedBg3 = currentSelection.transform.FindChild (selectedGun + "_TextEquipedBg").gameObject;
			OldEquipedBg3.SetActive (true);
			OldButton3 = currentSelection;
			OldButton3.GetComponent<Image>().color = Color.green;
		}

		EquipButton.interactable = false;
		PlayerPrefs.SetString (newEquipString, selectedGun);
		PlayerPrefs.Save ();
	
	}

	public void buyGun(){

		string TextBuyOwnedBg = (selectedGun + "_TextBuyOwnedBg");
		string TextBuyOwned = (selectedGun + "_TextBuyOwned");
		string OwnedText = (selectedGun + " - Owned");
		string TextEquipedBg = (selectedGun + "_TextEquipedBg");

		int playerMoney = PlayerPrefs.GetInt ("money"); 
		int Cost = 0;
		
		if (selectedGun == "Desert Eagle"){
			Cost = 100;
		}
		if (selectedGun == "Alien Pistol") {
			Cost = 500;
		}
		if (selectedGun == "Ak47") {
			Cost = 250;
		}
		if (selectedGun == "M4") {
			Cost = 500;
		}
		if (selectedGun == "Alien Rifle") {
			Cost = 1000;
		}
		if (selectedGun == "Mauser") {
			Cost = 500;
		}
		if (selectedGun == "Dragunov") {
			Cost = 1000;
		}
		if (selectedGun == "Alien Sniper") {
			Cost = 2000;
		}

		if (playerMoney >= Cost) {

			string isOwnedString = ("isOwned" + selectedGun);
			PlayerPrefs.SetString (newEquipString, selectedGun);
			BuyButton.interactable = false;
			GameObject SetOwnedText = currentSelection.transform.FindChild (TextBuyOwnedBg).FindChild(TextBuyOwned).gameObject;
			SetOwnedText.GetComponent<Text>().text = OwnedText;

			currentSelection.GetComponent<Image>().color = Color.green;
			currentSelection.transform.FindChild (TextEquipedBg).gameObject.SetActive(true);

			if (newEquipString == "currentGun1")
			{
				PlayerPrefs.SetString ("currentGun1", selectedGun);
				PlayerPrefs.Save ();
			if (OldEquipedBg1 != null) 
			{
				OldButton1.GetComponent<Button>().interactable = true;
				OldButton1.GetComponent<Image>().color = Color.white;
				OldEquipedBg1.SetActive (false);
				OldEquipedBg1 = currentSelection.transform.FindChild (selectedGun + "_TextEquipedBg").gameObject;
				OldButton1 = currentSelection;
			} else {
					OldEquipedBg1 = currentSelection.transform.FindChild (selectedGun + "_TextEquipedBg").gameObject;
					OldButton1 = currentSelection;
				}
			}
			if (newEquipString == "currentGun2") 
			{
				PlayerPrefs.SetString ("currentGun2", selectedGun);
				PlayerPrefs.Save ();
			if (OldEquipedBg2 != null) 
			{
				OldButton2.GetComponent<Button>().interactable = true;
				OldButton2.GetComponent<Image>().color = Color.white;
				OldEquipedBg2.SetActive (false);
				OldEquipedBg2 = currentSelection.transform.FindChild (selectedGun + "_TextEquipedBg").gameObject;
				OldButton2 = currentSelection;
			} else {
					OldEquipedBg2 = currentSelection.transform.FindChild (selectedGun + "_TextEquipedBg").gameObject;
					OldButton2 = currentSelection;
				}
			}
			if (newEquipString == "currentGun3") 
			{
				PlayerPrefs.SetString ("currentGun3", selectedGun);
				PlayerPrefs.Save ();
			if (OldEquipedBg3 != null)
			{
				OldButton3.GetComponent<Button>().interactable = true;
				OldButton3.GetComponent<Image>().color = Color.white;
				OldEquipedBg3.SetActive (false);
				OldEquipedBg3 = currentSelection.transform.FindChild (selectedGun + "_TextEquipedBg").gameObject;
				OldButton3 = currentSelection;
			} else {
					OldEquipedBg3 = currentSelection.transform.FindChild (selectedGun + "_TextEquipedBg").gameObject;
					OldButton3 = currentSelection;
				}
			}

			playerMoney -= Cost;
			PlayerPrefs.SetInt ("money", playerMoney);
			PlayerPrefs.SetString (isOwnedString, "true");
			PlayerPrefs.Save();
		
		} else 
		{
		buyText.text = "Not enough money";
		}
	}

	void setBuyText(){
		if (buyText.text == "Not enough money")
		{
			buyText.text = "Buy";
		}
	}
	public void SetRifleType()
	{
		if (Glock21.activeInHierarchy) 
		{
			Glock21.SetActive (false);
			DesertEagle.SetActive (false);
			AlienPistol.SetActive (false);
		}
		if (Mauser.activeInHierarchy) 
		{
			Mauser.SetActive (false);
			Dragunov.SetActive (false);
			AlienSniper.SetActive (false);
		}
		Ak47.SetActive (true);
		M4.SetActive (true);
		AlienRifle.SetActive (true);
	}
	public void SetPistolType()
	{
		if (Ak47.activeInHierarchy) 
		{
			Ak47.SetActive (false);
			M4.SetActive (false);
			AlienRifle.SetActive (false);
		}
		if (Mauser.activeInHierarchy) 
		{
			Mauser.SetActive (false);
			Dragunov.SetActive (false);
			AlienSniper.SetActive (false);
		}
		Glock21.SetActive (true);
		DesertEagle.SetActive (true);
		AlienPistol.SetActive (true);
	}
	public void SetSniperType()
	{
		if (Glock21.activeInHierarchy) 
		{
			Glock21.SetActive (false);
			DesertEagle.SetActive (false);
			AlienPistol.SetActive (false);
		}
		if (Ak47.activeInHierarchy) 
		{
			Ak47.SetActive (false);
			M4.SetActive (false);
			AlienRifle.SetActive (false);
		}
		Mauser.SetActive (true);
		Dragunov.SetActive (true);
		AlienSniper.SetActive (true);
	}
}
