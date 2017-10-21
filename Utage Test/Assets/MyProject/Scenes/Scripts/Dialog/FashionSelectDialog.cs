using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class FashionSelectDialog : DialogBase {

	[SerializeField]
	GridLayoutGroup mGrid;
	[SerializeField]
	Text mCharaNameText;
	[SerializeField]
	FashionItem mFashionItemPrefab;

	List<CharaFashionData> mCharaFashionDataList;
	List<FashionItem> mFashionItemList = new List<FashionItem> ();


	public void Init(List<CharaFashionData> dataList){
		mCharaFashionDataList = dataList;
		var charaType = dataList.First ().mChara;
		mCharaNameText.text = CharacterMasterData.CharacterDict.Where (c => c.Key == charaType).First ().Value.mCharaName;

		foreach (var item in mFashionItemList) {
			Destroy (item.gameObject);
		}
		mFashionItemList.Clear ();
		mFashionItemList = new List<FashionItem> ();
		foreach (var data in dataList) {
			var item = PrefabFolder.InstantiateTo<FashionItem> (mFashionItemPrefab,mGrid.transform);
			item.Init (data,this);
			mFashionItemList.Add (item);
		}
		this.Open ();
	}

	// Use this for initialization
	void Start () {
		
	}
}
