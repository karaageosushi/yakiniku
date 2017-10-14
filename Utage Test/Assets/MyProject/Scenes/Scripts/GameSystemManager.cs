using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundUtil;

public class GameSystemManager : SingletonMonoBehaviour<GameSystemManager> {

	UserData mUserData = new UserData();
	public UserData UserData{
		get{
			return mUserData;
		}
	}
	[SerializeField]
	Transform mDialogEmmiter;
	public Transform DialogEmmiter{
		get{
			return mDialogEmmiter;
		}
	}

	[ContextMenu("デバッグで初期情報をセット！")]
	public void SetEarlyUserData(){
		var chara = new CharaSaveData ();
		chara.mCharacterType = (int)CharacterType.AINE;
		mUserData.mCharaSaveDataList.Add (chara);

		chara = new CharaSaveData ();
		chara.mCharacterType = (int)CharacterType.CANNON;
		mUserData.mCharaSaveDataList.Add (chara);

		chara = new CharaSaveData ();
		chara.mCharacterType = (int)CharacterType.HALNAUMY;
		mUserData.mCharaSaveDataList.Add (chara);

		chara = new CharaSaveData ();
		chara.mCharacterType = (int)CharacterType.JEMENOPPEEDY;
		mUserData.mCharaSaveDataList.Add (chara);

		chara = new CharaSaveData ();
		chara.mCharacterType = (int)CharacterType.LIEUNNE;
		mUserData.mCharaSaveDataList.Add (chara);

		chara = new CharaSaveData ();
		chara.mCharacterType = (int)CharacterType.MNOINE;
		mUserData.mCharaSaveDataList.Add (chara);

		chara = new CharaSaveData ();
		chara.mCharacterType = (int)CharacterType.PLIMMAVAERHA;
		mUserData.mCharaSaveDataList.Add (chara);


		mUserData.mCurrentSelectedCharacter = CharacterType.CANNON;
	}

	void Awake(){
		//一旦はデバッグで情報をセットする！後々はローカルにセーブしたデータに差し替える
		var UserData = SaveData.LoadUserData();
		if (UserData == null) {
			SetEarlyUserData();
			SaveData.SaveUserData ();
		} else {
			mUserData = UserData;
		}
		SoundManager.Instance.volume.bgm = mUserData.mVolBgm;
		SoundManager.Instance.volume.se = mUserData.mVolSe;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
