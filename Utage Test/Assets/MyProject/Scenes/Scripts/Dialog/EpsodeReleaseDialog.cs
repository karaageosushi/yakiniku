using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EpsodeReleaseDialog : DialogBase {

	[SerializeField]
	Text mBody;
	[SerializeField]
	CommonDialog mDialog;
	CharaEpisodeData mData;
	EpisodeItem mEpisodeItem;

	public void Init(CharaEpisodeData data,EpisodeItem item,Action cloaseCallBack){
		mData = data;
		mEpisodeItem = item;
		mBody.text = data.mTitle+"を"+data.mPriceNecessaryRelease+"コインで解放します。¥nよろしいですか？";
		mCloseCallback = () => {
			Destroy(this.gameObject);
			cloaseCallBack();
		};
	}

	public void OnYesButton(){
		if (GameSystemManager.Instance.UserData.mMoney >= mData.mPriceNecessaryRelease) {
			//解放処理
			GameSystemManager.Instance.UserData.mMoney -= mData.mPriceNecessaryRelease;
			GameSystemManager.Instance.UserData.GetCharacterSaveDataFromType (mData.mChara).mStoryReleaseCount = mData.mTitleNumber;
			SaveData.SaveUserData ();
			//表示を解放状態に変える
			mEpisodeItem.SetReleasedDisPlay();
		} else {
			//お金が足りませんダイアログだす
			Debug.Log("お金が足りませんダイアログだす");
			var commondialog = PrefabFolder.InstantiateTo<CommonDialog>(mDialog, GameSystemManager.Instance.DialogEmmiter);
			commondialog.Init ("コインが足りません");
		}
		Close ();
	}

	public void OnNoButton(){
		Close ();
	}

	// Use this for initialization
	void Start () {
		//Close ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
