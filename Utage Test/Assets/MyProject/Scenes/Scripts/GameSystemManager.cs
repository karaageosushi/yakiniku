using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundUtil;
using UniRx;
using UniRx.Triggers;
using System.Runtime.InteropServices;

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

	Stack<BaseScene> mSceneHistory = new Stack<BaseScene>();
	public Stack<BaseScene> SceneHistory{
		get{
			return mSceneHistory;
		}
	}

	BaseScene mCurrentScene;
	public BaseScene CurrentScene{
		get{
			return mCurrentScene;
		}
	}

	ReactiveProperty<bool> mIsMainScene = new ReactiveProperty<bool>();
	public ReactiveProperty<bool> IsMainScene{
		get{
			return mIsMainScene;
		}
	}

	[SerializeField]
	MainScene mMainScene;


	[ContextMenu("デバッグで初期情報をセット！")]
	public void SetEarlyUserData(){
		var chara = new CharaSaveData ();
		chara.mCharacterType = (int)CharacterType.EINE;
		mUserData.mCharaSaveDataList.Add (chara);

		chara = new CharaSaveData ();
		chara.mCharacterType = (int)CharacterType.CANNON;
		mUserData.mCharaSaveDataList.Add (chara);

		chara = new CharaSaveData ();
		chara.mCharacterType = (int)CharacterType.HARUNOUMI;
		mUserData.mCharaSaveDataList.Add (chara);

		chara = new CharaSaveData ();
		chara.mCharacterType = (int)CharacterType.GYMNOPEDIE;
		mUserData.mCharaSaveDataList.Add (chara);

		chara = new CharaSaveData ();
		chara.mCharacterType = (int)CharacterType.LUNE;
		mUserData.mCharaSaveDataList.Add (chara);

		chara = new CharaSaveData ();
		chara.mCharacterType = (int)CharacterType.NEUN;
		mUserData.mCharaSaveDataList.Add (chara);

		chara = new CharaSaveData ();
		chara.mCharacterType = (int)CharacterType.PRIMAVERA;
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
		if (mIsBackGround.Value) {
			mBackGroundTime += Time.deltaTime;
		} else {
			mBackGroundTime = 0;
		}
	}

	float mBackGroundTime = 0;
	public float BackGroundTime{
		get{
			return mBackGroundTime;
		}
	}
	//public bool mIsPlayMusic = false;
	ReactiveProperty<bool> mIsBackGround = new ReactiveProperty<bool>(false);
	public ReactiveProperty<bool> IsBackGround{
		get{
			return mIsBackGround;
		}
	}

	bool mIsFailed = false;
	public bool IsFailed{
		get{
			return mIsFailed;
		}
	}
	/// <summary>
	/// 失敗通知をネイティブ側から受け取る
	/// </summary>
	public void SendFailure(string message){
		mIsFailed = true;
		//BGMを止める
		mMainScene.MakeFailedMusic();
		//SoundManager.Instance.StopBgm();
	}
	/// <summary>
	/// フラグをリセット
	/// </summary>
	/// <param name="message">Message.</param>
	public void ResetFailedFlag(string message){
		mIsFailed = false;
	}

}
