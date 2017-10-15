using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MusicSelectScene : BaseScene {

	[SerializeField]
	EpisodeSelectDialog mEpisodeDialog;
	[SerializeField]
	MusicItem CharaMusicItemPrefab;
	[SerializeField]
	MainScene mMainScene;
	[SerializeField]
	CharaDetaileScene mCharaDetaileScene;
	[SerializeField]
	GridLayoutGroup mGrid;
	List<MusicItem> mItemLsit = new List<MusicItem>();

	public void OpenEpisodeDialog(CharacterType chara ){
		mEpisodeDialog.Init (CharacterMasterData.CharaEpsodeDataList.Where(c => c.mChara == chara).ToList());
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
				OpenEpisodeDialog(item.CharacterType);
			},()=>{
				this.Close();
				//ここにキャラ詳細画面を開く処理を入れる
				mCharaDetaileScene.Open();
				mCharaDetaileScene.Init(CharacterMasterData.CharacterDict[item.CharacterType],item.CharacterType);
				mMainScene.UpdateMainDisplay();
			}
			);
			mItemLsit.Add (item);
		}


	}


}
