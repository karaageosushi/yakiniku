using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScene : MonoBehaviour {
	[SerializeField]
	MusicSelectScene mMusicSelectScene;
	[SerializeField]
	SettingScene mSettingScene;
	[SerializeField]
	CharacterImageSelector mCharacterImageSelector;

	[SerializeField]
	Text mDegreeLoveLabel;
	[SerializeField]
	Text mCharaNameLabel;
	[SerializeField]
	Text mCharaCommentLabel;
	[SerializeField]
	Text mTimeLabel;

	public void OpenMusicSelectScene(){
		mMusicSelectScene.Open();
	}
	public void OpenSettingScene(){
		mSettingScene.Open ();
	}

	void Start () {
		//GameSystemManager.Instance.SetEarlyUserData ();
		//UpdateMainDisplay ();

		//Test!!!!!!!
		Invoke("SetEarlyUserData",0.1f);
	}

	/// <summary>
	/// メイン画面の表示を変更する
	/// </summary>
	public void UpdateMainDisplay(){
		var selectChara = GameSystemManager.Instance.UserData.mCurrentSelectedCharacter;
		mCharacterImageSelector.ShowCharactor (selectChara);
		mCharaNameLabel.text = CharacterData.CharacterDict[selectChara];
	}

	[ContextMenu("デバッグで画面情報を構築")]
	void SetEarlyUserData(){
		GameSystemManager.Instance.SetEarlyUserData ();
		UpdateMainDisplay ();
	}
}
