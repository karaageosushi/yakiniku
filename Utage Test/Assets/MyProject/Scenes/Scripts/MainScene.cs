using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using SoundUtil;

public class MainScene : MonoBehaviour {
	[SerializeField]
	MusicSelectScene mMusicSelectScene;
	[SerializeField]
	SettingScene mSettingScene;
	[SerializeField]
	CharacterImageSelector mCharacterImageSelector;

	[SerializeField]
	Text mLovePointLabel;
	[SerializeField]
	Text mCharaNameLabel;
	[SerializeField]
	Text mCharaCommentLabel;
	[SerializeField]
	Text mTimeLabel;

	[SerializeField]
	Button mStartButton;
	[SerializeField]
	Button mStopButton;
	bool mIsPlayCharacterMusic = false;

	void UpdateMusicButtonDisPlay(){
		mStartButton.gameObject.SetActive (false);
		mStopButton.gameObject.SetActive (false);
		if (mIsPlayCharacterMusic) {
			mStopButton.gameObject.SetActive (true);
		} else {
			mStartButton.gameObject.SetActive (true);
		}
	}


	public void OpenMusicSelectScene(){
		mMusicSelectScene.Open();
	}

	public void OpenSettingScene(){
		mSettingScene.Open ();
	}

	void Start () {
		UpdateMainDisplay ();
	}

	/// <summary>
	/// メイン画面の表示を変更する
	/// </summary>
	public void UpdateMainDisplay(){
		var selectChara = GameSystemManager.Instance.UserData.mCurrentSelectedCharacter;
		mCharacterImageSelector.ShowCharactor (selectChara);
		mCharaNameLabel.text = CharacterMasterData.CharacterDict[selectChara];
		mLovePointLabel.text = "×"+GameSystemManager.Instance.UserData.mSelectedCharaSaveData.mLovePoint;
		//現在のキャラクターのコメントを取得
		var currentCharaCommentList = CharacterMasterData.CharaCommentDataList.Where(cd=>cd.mChara == selectChara).Where(cd=>cd.mTime == TimeUtil.GetCurrentTimeType()).ToList();
		int rand = UnityEngine.Random.Range (0,currentCharaCommentList.Count);
		string comment = currentCharaCommentList[rand].mComment;
		mCharaCommentLabel.text = comment;
	}
	/// <summary>
	/// 現在選択中のキャラクターのミュージックを流す
	/// </summary>
	public void PlayCurrentSelectedCharacterMusic(){
		var selectChara = GameSystemManager.Instance.UserData.mCurrentSelectedCharacter;
		SoundManager.Instance.PlayBgm ((int)selectChara);
		mIsPlayCharacterMusic = true;
		UpdateMusicButtonDisPlay ();
	}
	public void StopCurrentSelectedCharacterMusic(){
		SoundManager.Instance.StopBgm ();
		mIsPlayCharacterMusic = false;
		UpdateMusicButtonDisPlay ();
	}
}
