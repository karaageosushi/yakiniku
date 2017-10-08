using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

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
}
