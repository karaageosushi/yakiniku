using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugScene : BaseScene {

	[SerializeField]
	GetRewordDialog mGetRewordDialog;

	public void OpenGetRewordDialog(){
		mGetRewordDialog.Init(1);
	}

	public void SaveUserData(){
		SaveData.SaveUserData ();
	}
	public void ResetUserData(){
		SaveData.ResetUserData ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
