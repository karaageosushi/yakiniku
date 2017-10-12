using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EpisodeSelectDialog : DialogBase {

	[SerializeField]
	GridLayoutGroup mGrid;
	[SerializeField]
	EpisodeItem mEpisodeItemPrefab;
	List<CharaEpisodeData> mCharaEpisodeDataList;
	List<EpisodeItem> mEpisodeItemList = new List<EpisodeItem> ();

	public void Init(List<CharaEpisodeData> dataList){
		foreach (var item in mEpisodeItemList) {
			Destroy (item.gameObject);
		}
		mEpisodeItemList.Clear ();
		mEpisodeItemList = new List<EpisodeItem> ();
		//----------

		mCharaEpisodeDataList = dataList;
		foreach (var data in dataList) {
			var item = PrefabFolder.InstantiateTo<EpisodeItem> (mEpisodeItemPrefab,mGrid.transform);
			item.Init (data);
			mEpisodeItemList.Add (item);
		}
	}

	// Use this for initialization
	void Start () {
		
	}

}
