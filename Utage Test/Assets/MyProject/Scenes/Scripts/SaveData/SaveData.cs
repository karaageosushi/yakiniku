using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData  {

	const string SAVE_KEY = "SaveData";
	public static void SaveUserData(){
		PlayerPrefs.SetString(SAVE_KEY, GameSystemManager.Instance.UserData.ToJson());
		PlayerPrefs.Save();
	}
	public static void ResetUserData(){
		PlayerPrefs.DeleteAll ();
	}

	public static UserData LoadUserData(){
		var json = PlayerPrefs.GetString (SAVE_KEY,"");
		if (json == "")
			return null;
		return UserData.FromJson (json);
	}

}
