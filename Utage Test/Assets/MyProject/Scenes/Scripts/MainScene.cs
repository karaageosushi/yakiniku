using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using SoundUtil;
using UniRx;
using UniRx.Triggers;
using System;

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
	[SerializeField]
	Slider mMusicSlider;
	[SerializeField]
	Image mMusciValFillImage;
	[SerializeField]
	GetRewordDialog mGetRewordDialog;
	[SerializeField]
	DebugScene mDebugScene;

	const int MIN_TO_MONEY = 2;

	bool mIsPlayCharacterMusic = false;
	//最大再生時間
	const float MAX_MUSIC_TIME = 7200.0f;
	float SetiingTime{
		get{
			return MAX_MUSIC_TIME * mMusicSlider.value;
		}
	}
	float mSetiingTimeSnapShot = 0;

	void UpdateMusicButtonDisPlay(){
		mStartButton.gameObject.SetActive (false);
		mStopButton.gameObject.SetActive (false);
		if (mIsPlayCharacterMusic) {
			mStopButton.gameObject.SetActive (true);
		} else {
			mStartButton.gameObject.SetActive (true);
		}
	}
	public void OpenDebugScene(){
		mDebugScene.Open ();
	}

	public void OpenMusicSelectScene(){
		mMusicSelectScene.Open();
	}

	public void OpenSettingScene(){
		mSettingScene.Open ();
	}

	void Start () {
		UpdateMainDisplay ();
		//スライドのイベント登録
		mMusicSlider.onValueChanged.AddListener((value) => {
			mMusciValFillImage.fillAmount = value;
			mTimeLabel.text = new FroatToMinUtil().FroatToMin((MAX_MUSIC_TIME*value));
		});
	}

	/// <summary>
	/// 音楽の再生時間表示更新用のトリガーオブジェクト
	/// </summary>
	GameObject mMusicDisposableUpdateTrigger = null;
	IDisposable mMusicDisposableUpdate;
	/// <summary>
	/// メイン画面の表示を変更する
	/// </summary>
	public void UpdateMainDisplay(){
		var selectChara = GameSystemManager.Instance.UserData.mCurrentSelectedCharacter;
		AudioClip selectCharaAudio = SoundManager.Instance.GetAudioClipFromIndex ((int)selectChara);
		mTimeLabel.text = new FroatToMinUtil().FroatToMin(selectCharaAudio.length);
		mCharacterImageSelector.ShowCharactor (selectChara);
		mCharaNameLabel.text = CharacterMasterData.CharacterDict[selectChara].mCharaName;
		UpDateLovePointLabel();
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
		mMusicSlider.enabled = false;
		var selectChara = GameSystemManager.Instance.UserData.mCurrentSelectedCharacter;
		SoundManager.Instance.PlayBgm ((int)selectChara);
		mIsPlayCharacterMusic = true;
		UpdateMusicButtonDisPlay ();
		mSetiingTimeSnapShot = SetiingTime;
		float currentMusicTime = 0;
		//mMusicDisposableUpdateTrigger = new GameObject ("mMusicDisposableUpdateTrigger");
		mMusicDisposableUpdate = this.UpdateAsObservable().Subscribe(_=>{
			if(SoundManager.Instance.mCurrentPlayBgm.clip == null)return;
			currentMusicTime += Time.deltaTime;
			var remainingTime = mSetiingTimeSnapShot-currentMusicTime;
			mTimeLabel.text = new FroatToMinUtil().FroatToMin((remainingTime));
			//緑色のながさを変える処理を入れる
			var fillVal = remainingTime/MAX_MUSIC_TIME;
			mMusciValFillImage.fillAmount = fillVal;
			if(remainingTime <= 0){
				//ここに報酬獲得の処理を入れる
				var rewordVal = new FroatToMinUtil().FromToMinVal(mSetiingTimeSnapShot)*MIN_TO_MONEY;
				mGetRewordDialog.Init(rewordVal);
				GameSystemManager.Instance.UserData.mMoney += rewordVal;
				//表示を更新
				UpDateLovePointLabel();
				//データをSave
				SaveData.SaveUserData ();
				StopCurrentSelectedCharacterMusic();
			}
		});

	}

	public void UpDateLovePointLabel(){
		mLovePointLabel.text = ""+GameSystemManager.Instance.UserData.mMoney;
	}

	public void StopCurrentSelectedCharacterMusic(){
		mMusicSlider.enabled = true;
		mMusicDisposableUpdate.Dispose ();
		SoundManager.Instance.StopBgm ();
		mIsPlayCharacterMusic = false;
		UpdateMusicButtonDisPlay ();
	}
}

public class FroatToMinUtil{
	public string FroatToMin(float time){
		int min = (int)(time / 60);
		int second = (int)(time%60);
		return min.ToString ("00") + ":" + second.ToString ("00");
	}
	public int FromToMinVal(float time){
		return (int)(time / 60);
	}
}

