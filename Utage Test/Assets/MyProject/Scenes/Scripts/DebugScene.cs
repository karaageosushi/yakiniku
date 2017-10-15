using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugScene : BaseScene {

	[SerializeField]
	GetRewordDialog mGetRewordDialog;
	[SerializeField]
	MainScene mMainScene;

	public void OpenGetRewordDialog(){
		mGetRewordDialog.Init(1);
	}

	public void SaveUserData(){
		SaveData.SaveUserData ();
	}
	public void ResetUserData(){
		SaveData.ResetUserData ();
		Application.Quit ();
	}

	public void AddMoney(){
		GameSystemManager.Instance.UserData.mMoney = 9999;
		mMainScene.UpdateMainDisplay ();
		SaveData.SaveUserData ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
