using UnityEngine;
using System.Collections;

public class DevFunctions : MonoBehaviour {


	public void deleteAllKeys() 
	{
		PlayerPrefs.DeleteAll ();
		PlayerPrefs.Save ();
	}

	public void giveMoney(int Money) 
	{
		PlayerPrefs.SetInt ("money", Money);
		PlayerPrefs.Save ();
	}

	public void giveXp(int Xp) 
	{
		PlayerPrefs.SetInt ("xp", Xp);
		PlayerPrefs.Save ();
	}

	public void giveLevel(int Level)
	{
		PlayerPrefs.SetInt ("lvl", Level);
		PlayerPrefs.Save ();
	}

	public void giveGun(string Gun)
	{
		PlayerPrefs.SetString ("currentGun", Gun);
		PlayerPrefs.Save ();
	}

}