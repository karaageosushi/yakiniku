using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EpsodeReleaseDialog : DialogBase {

	[SerializeField]
	Text mBody;
	CharaEpisodeData mData;
	EpisodeItem mEpisodeItem;

	public void Init(CharaEpisodeData data,EpisodeItem item){
		mData = data;
		mEpisodeItem = item;
		mBody.text = data.mTitle+"を"+data.mPriceNecessaryRelease+"コインで解放します。¥nよろしいですか？";
		mCloseCallback = () => {
			Destroy(this.gameObject);
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
		}
		Close ();
	}

	public void OnNoButton(){
		Close ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
