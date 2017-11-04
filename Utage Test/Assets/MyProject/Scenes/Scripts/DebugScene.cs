using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

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

	public void ReloadScene(){
		Application.LoadLevel (0);
	}

	public void AddMoney(){
		GameSystemManager.Instance.UserData.mMoney = 9999;
		mMainScene.UpdateMainDisplay ();
		SaveData.SaveUserData ();
	}
	[DllImport("__Internal")]
	private static extern void _ReSetiOSBackGroundAudio ();
	[DllImport("__Internal")]
	private static extern void _SetiOSBackGroundAudio ();

	public void NativeBgmPlay(){
		_SetiOSBackGroundAudio ();
	}
	public void NativeBgmStop(){
		_ReSetiOSBackGroundAudio ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
