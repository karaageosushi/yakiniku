using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystemManager : SingletonMonoBehaviour<GameSystemManager> {

	UserData mUserData = new UserData();
	public UserData UserData{
		get{
			return mUserData;
		}
	}

	[ContextMenu("デバッグで初期情報をセット！")]
	public void SetEarlyUserData(){

		//mUserData.mCharaSaveDataList = new List<CharaSaveData> ();
		var chara = new CharaSaveData ();
		chara.mCharacterType = (int)CharacterType.CANON;
		mUserData.mCharaSaveDataList.Add (chara);

		chara = new CharaSaveData ();
		chara.mCharacterType = (int)CharacterType.BEETHOVEN;
		mUserData.mCharaSaveDataList.Add (chara);

		chara = new CharaSaveData ();
		chara.mCharacterType = (int)CharacterType.BRAHMS;
		mUserData.mCharaSaveDataList.Add (chara);

		mUserData.mCurrentSelectedCharacter = CharacterType.CANON;
		/*
		mUserData.mCharaSaveDataList = new List<CharaSaveData> ();
		var chara = new CharaSaveData ();
		chara.mCharacterType = (int)CharacterType.CANON;
		mUserData.mCharaSaveDataList.Add (chara);
		//------------------------------------
		var chara2 = new CharaSaveData ();
		chara.mCharacterType = (int)CharacterType.BEETHOVEN;
		mUserData.mCharaSaveDataList.Add (chara);
		//------------------------------------
		var chara3 = new CharaSaveData ();
		chara.mCharacterType = (int)CharacterType.BEETHOVEN;
		mUserData.mCharaSaveDataList.Add (chara);

		mUserData.mCurrentSelectedCharacter = CharacterType.CANON;
		*/
	}

	void Awake(){
		//一旦はデバッグで情報をセットする！後々はローカルにセーブしたデータに差し替える
		//DebugSetUserData ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
