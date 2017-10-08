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
		List<CharacterType> chaList = new List<CharacterType>() ;
		//バグで落ちてるので調べる！！！！

		Debug.LogError ("バグで落ちてるので調べる！！！！");
		/*
		foreach (var item in GameSystemManager.Instance.UserData.mCharaSaveDataList) {
			chaList.Add (item.CharacterType);
		}
		*/
		Debug.Log ("11"+chaList.Count);
		foreach (var chara in chaList) {
			var item = PrefabFolder.InstantiateTo<MusicItem> (CharaMusicItemPrefab,mGrid.transform);
			item.Init (chara,()=>{
				OpenEpisodeDialog();
			},()=>{
				this.Close();
				mMainScene.UpdateMainDisplay();
			}
			);
		}


	}


}
