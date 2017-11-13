using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADVManager : SingletonMonoBehaviour<ADVManager> {
	UserData mUserData = new UserData();
	public UserData UserData{
		get{
			return mUserData;
		}
	}

	void Awake(){
		mUserData = SaveData.LoadUserData();
	}
	// Use this for initialization
	void Start () {
		
	}

}
