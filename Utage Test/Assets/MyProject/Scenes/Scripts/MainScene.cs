using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using SoundUtil;
using UniRx;
using UniRx.Triggers;
using System;

public class CharaCommentFlags{
	public bool mIsSuccessedTimer = false;
	public bool mIsFailuredTimer = false;
	public bool mIsTaped = false;
	public bool mIsLeaved = false;

	public void ResetFlags(){
		mIsSuccessedTimer = false;
		mIsFailuredTimer = false;
		mIsTaped = false;
		mIsLeaved = false;
	}

}

public class MainScene : BaseScene {
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
	[SerializeField]
	GameObject mTransferOtherScreens;

	CharaCommentFlags mCharaCommentFlags =new CharaCommentFlags();

	const int MIN_TO_MONEY = 2;
	const float BACKGROUND_WAITING_TIME = 5;
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

	float mLeavingTimer=0;
	void Start () {
		GameSystemManager.Instance.SceneHistory.Push (this);
		UpdateMainDisplay ();
		//スライドのイベント登録
		mMusicSlider.onValueChanged.AddListener((value) => {
			mMusciValFillImage.fillAmount = value;
			//mTimeLabel.text = new FroatToMinUtil().FroatToMin((MAX_MUSIC_TIME*value));
			mTimeLabel.text = new FroatToMinUtil().FroatToMin((SetiingTime));
		});
		//放置時の処理を行う
		GameSystemManager.Instance.IsMainScene.Subscribe(isMain=>{
			

			if(isMain){
				//メインシーンに入ったタイミングで起動
				UpdateMainDisplay();
				this.UpdateAsObservable().Subscribe(_=>{
					//Debug.Log(mLeavingTimer+":"+GameSystemManager.Instance.IsMainScene.Value);
					if(GameSystemManager.Instance.IsMainScene.Value&&!mIsPlayCharacterMusic){
						mLeavingTimer += Time.deltaTime;
					}else{
						mLeavingTimer=0;
					}
					if(mLeavingTimer >= 30){
						if(!mIsPlayCharacterMusic){
							mCharaCommentFlags.mIsLeaved = true;
							UpdateMainDisplay();
						}
						mLeavingTimer = 0;
					}
				}).AddTo(this.gameObject);
			}else{
				//メインシーンを離れたタイミングで起動
				mLeavingTimer=0;
			}
		}).AddTo(this.gameObject);
		GameSystemManager.Instance.IsMainScene.Value = true;
		mCharacterImageSelector.SetCharaTapEvent ((chara)=>{
			mCharaCommentFlags.mIsTaped = true;
			UpdateMainDisplay();
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
		mTimeLabel.text = new FroatToMinUtil().FroatToMin((SetiingTime));
		mCharacterImageSelector.ShowCharactor (selectChara);
		mCharaNameLabel.text = CharacterMasterData.CharacterDict[selectChara].mCharaName;
		UpDateLovePointLabel();
		//コメント更新
		UpdateCharaComment ();
	}

	/// <summary>
	/// キャラのコメントをアップデート
	/// </summary>
	void UpdateCharaComment(){
		var selectChara = GameSystemManager.Instance.UserData.mCurrentSelectedCharacter;
		//通常時
		{
			//現在のキャラクターのコメントを取得
			var currentCharaCommentList = CharacterMasterData.CharaCommentDataList.Where (cd => cd.mChara == selectChara).Where (cd => cd.mCommentType == TimeUtil.GetCurrentTimeType () || cd.mCommentType == CommentType.COMMON).ToList ();
			int rand = UnityEngine.Random.Range (0, currentCharaCommentList.Count);
			string comment = currentCharaCommentList [rand].mComment;
			mCharaCommentLabel.text = comment;
		}

		//放置時
		if (mCharaCommentFlags.mIsLeaved) {
			var targetCommentList = CharacterMasterData.CharaCommentDataList.Where(cd=>cd.mChara == selectChara).Where(cd=>cd.mCommentType == CommentType.LEAVING).ToList();
			int rand = UnityEngine.Random.Range (0,targetCommentList.Count);
			string comment = targetCommentList[rand].mComment;
			mCharaCommentLabel.text = comment;
		}

		//音楽再生時
		if (mIsPlayCharacterMusic) {
			//音楽再生時のコメントを取得
			var currentCharaMusicTimeCommentList = CharacterMasterData.CharaCommentDataList.Where(cd=>cd.mChara == selectChara).Where(cd=>cd.mCommentType == CommentType.TIMER).ToList();
			int musicRand = UnityEngine.Random.Range (0,currentCharaMusicTimeCommentList.Count);
			string musicComment = currentCharaMusicTimeCommentList[musicRand].mComment;
			mCharaCommentLabel.text = musicComment;
		}
		//キャラタップ時
		if (mCharaCommentFlags.mIsTaped) {
			var targetCommentList = CharacterMasterData.CharaCommentDataList.Where(cd=>cd.mChara == selectChara).Where(cd=>cd.mCommentType == CommentType.TAPPED).ToList();
			int rand = UnityEngine.Random.Range (0,targetCommentList.Count);
			string comment = targetCommentList[rand].mComment;
			mCharaCommentLabel.text = comment;
		}
		//音楽再生失敗時
		if (mCharaCommentFlags.mIsFailuredTimer) {
			var targetCommentList = CharacterMasterData.CharaCommentDataList.Where(cd=>cd.mChara == selectChara).Where(cd=>cd.mCommentType == CommentType.TIMER_FAILURE).ToList();
			int rand = UnityEngine.Random.Range (0,targetCommentList.Count);
			string comment = targetCommentList[rand].mComment;
			mCharaCommentLabel.text = comment;
		}
		//音楽再生成功時
		if (mCharaCommentFlags.mIsSuccessedTimer) {
			var targetCommentList = CharacterMasterData.CharaCommentDataList.Where(cd=>cd.mChara == selectChara).Where(cd=>cd.mCommentType == CommentType.TIMER_SUCCESS).ToList();
			int rand = UnityEngine.Random.Range (0,targetCommentList.Count);
			string comment = targetCommentList[rand].mComment;
			mCharaCommentLabel.text = comment;
		}

		//フラグをリセット
		mCharaCommentFlags.ResetFlags ();
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
		UpdateMainDisplay ();
		mSetiingTimeSnapShot = SetiingTime;
		float currentMusicTime = 0;
		mTransferOtherScreens.gameObject.SetActive (false);
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
				if(rewordVal != 0){
					mGetRewordDialog.Init(rewordVal);
				}
				GameSystemManager.Instance.UserData.mMoney += rewordVal;
				//表示を更新
				//UpDateLovePointLabel();
				//データをSave
				SaveData.SaveUserData ();
				mCharaCommentFlags.mIsSuccessedTimer = true;
				StopCurrentSelectedCharacterMusic();
			}
		});

	}

	public void UpDateLovePointLabel(){
		mLovePointLabel.text = ""+GameSystemManager.Instance.UserData.mMoney;
	}

	//音楽の再生に失敗した場合
	public void MakeFailedMusic(){
		//失敗フラグを入れる
		mCharaCommentFlags.mIsFailuredTimer = true;
		StopCurrentSelectedCharacterMusic ();
	}

	public void StopCurrentSelectedCharacterMusic(){
		mMusicSlider.enabled = true;
		mMusicDisposableUpdate.Dispose ();
		SoundManager.Instance.StopBgm ();
		mIsPlayCharacterMusic = false;
		UpdateMusicButtonDisPlay ();

		mTransferOtherScreens.gameObject.SetActive (true);
		//メイン画面の表示を行う
		UpdateMainDisplay ();
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

