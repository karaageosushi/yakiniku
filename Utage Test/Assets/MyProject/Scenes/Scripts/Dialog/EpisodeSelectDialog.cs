using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class EpisodeSelectDialog : DialogBase {

	[SerializeField]
	GridLayoutGroup mGrid;
	[SerializeField]
	EpisodeItem mEpisodeItemPrefab;
	[SerializeField]
	Text mCharaNameText;
	List<CharaEpisodeData> mCharaEpisodeDataList;
	List<EpisodeItem> mEpisodeItemList = new List<EpisodeItem> ();

	public void Init(List<CharaEpisodeData> dataList){
		
		var charaType = dataList.First ().mChara;
		var charaSaveData = GameSystemManager.Instance.UserData.mCharaSaveDataList.Where (csd => csd.CharacterType == charaType).FirstOrDefault ();
		mCharaNameText.text = CharacterMasterData.CharacterDict[charaType] + "エピソード";
		foreach (var item in mEpisodeItemList) {
			Destroy (item.gameObject);
		}
		mEpisodeItemList.Clear ();
		mEpisodeItemList = new List<EpisodeItem> ();
		//----------
		mCharaEpisodeDataList = dataList;
		//全ては解放しない処理
		for (int i = 0; i < dataList.Count; i++) {
			var item = PrefabFolder.InstantiateTo<EpisodeItem> (mEpisodeItemPrefab,mGrid.transform);
			item.Init (dataList[i],this);
			mEpisodeItemList.Add (item);
			if (i+1 == charaSaveData.mStoryReleaseCount+1) {
				//未解放状態だけれどコインを払えば解放可能表示
				item.SetReleasePossibleIndicationDisplay ();
			} else if (charaSaveData.mStoryReleaseCount < i) {
				//未解放状態を表示
				item.SetNonReleaseIndicationDisplay ();
			}
		}
	}

	public void UpdateList(){
		Init (mCharaEpisodeDataList);
	}

	// Use this for initialization
	void Start () {
		Close ();
	}

}
