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
	bool mIsPlayCharacterMusic = false;

	public float MusicTime{
		get{
			//ダミーで値を設定（後ほど変える）
			return 66.0f;
		}
	}

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
		Debug.Log ("PlayCurrentSelectedCharacterMusic");
		var selectChara = GameSystemManager.Instance.UserData.mCurrentSelectedCharacter;
		SoundManager.Instance.PlayBgm ((int)selectChara);
		mIsPlayCharacterMusic = true;
		UpdateMusicButtonDisPlay ();
		//mMusicDisposableUpdateTrigger = new GameObject ("mMusicDisposableUpdateTrigger");
		mMusicDisposableUpdate = this.UpdateAsObservable().Subscribe(_=>{
			if(SoundManager.Instance.mCurrentPlayBgm.clip == null)return;
			var MusicLength = SoundManager.Instance.mCurrentPlayBgm.clip.length;
			var currentMusicTime = SoundManager.Instance.mCurrentPlayBgm.time;
			var remainingTime = MusicLength-currentMusicTime;
			mTimeLabel.text = new FroatToMinUtil().FroatToMin((remainingTime));
			if(remainingTime <= 0){
				StopCurrentSelectedCharacterMusic();
			}
		});

	}

	public void StopCurrentSelectedCharacterMusic(){
		Debug.Log ("StopCurrentSelectedCharacterMusic");
		/*
		if (mMusicDisposableUpdateTrigger != null) {
			Destroy (mMusicDisposableUpdateTrigger);
		}
		*/
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
}

