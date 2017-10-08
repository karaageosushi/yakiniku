using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MusicSelectScene : BaseScene {

	[SerializeField]
	DialogBase mEpisodeDialog;
	[SerializeField]
	MusicItem CharaMusicItemPrefab;
	[SerializeField]
	MainScene mMainScene;
	[SerializeField]
	GridLayoutGroup mGrid;
	List<MusicItem> mItemLsit = new List<MusicItem>();

	public void OpenEpisodeDialog(){
		mEpisodeDialog.Open ();
	}

	// Use this for initialization
	void Start () {
		//リストのアップデートを行う
		//UpdateItemList ();
	}

	public override void Open ()
	{
		base.Open ();
		UpdateItemList ();
	}

	void UpdateItemList(){
		
		mItemLsit.ForEach (i => Destroy (i.gameObject));
		mItemLsit.Clear();
		var charaList = GameSystemManager.Instance.UserData.mCharaSaveDataList.Select(cs=>cs.CharacterType).ToList();
		foreach (var chara in charaList) {
			var item = PrefabFolder.InstantiateTo<MusicItem> (CharaMusicItemPrefab,mGrid.transform);
			item.Init (chara,()=>{
				OpenEpisodeDialog();
			},()=>{
				this.Close();
				mMainScene.UpdateMainDisplay();
			}
			);
			mItemLsit.Add (item);
		}


	}


}
