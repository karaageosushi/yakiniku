using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusScene : BaseScene {

	[SerializeField]
	GridLayoutGroup mGrid;
	[SerializeField]
	BonusItem mBonusItemPrefab;
	List<BonusItem> mBonusItemList = new List<BonusItem>();

	public override void Open ()
	{
		base.Open ();
		foreach (var item in mBonusItemList) {
			Destroy (item.gameObject);

		}
		mBonusItemList.Clear ();
		mBonusItemList = new List<BonusItem> ();
		foreach (var data in GameMasterData.BonusDataList) {
			var item = PrefabFolder.InstantiateTo<BonusItem> (mBonusItemPrefab, mGrid.transform);
			item.Init (data);
		}

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
