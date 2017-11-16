using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
using Utage;

public class CharacterImageSelector : MonoBehaviour {

	[SerializeField]
	List<CharaSettingData>CharacterImagePrefabs;
	[SerializeField]
	List<DicingTextures> mDicingTexturesList;
	[SerializeField]
	DicingImage mDicingImage;

	CharaSettingData mCurrentChara=null;
	[SerializeField]
	float mCharaScale = 1.8f;

	public void ShowCharactor(CharacterType type){

		var TargetData = mDicingTexturesList.Where (d => d.name == type.ToString ()).FirstOrDefault ();
		var posData = CharacterMasterData.CharaTopPostionList.Where (pd => pd.mChara == type).FirstOrDefault ().mPostion;
		var charaSaveData = GameSystemManager.Instance.UserData.mCharaSaveDataList.Where (cs => cs.mCharacterType == (int)type).First ();

		mDicingImage.DicingData = TargetData;
		string pattern = type.ToString()+"_"+charaSaveData.mSelectedFashionId+"_"+0;//取り急ぎ、表情番号は0を入れる
		mDicingImage.ChangePattern(pattern);
		mDicingImage.transform.localPosition = new Vector3(posData.x,posData.y);
		//ボタンを一旦封印
		/*

		var button = mDicingImage.gameObject.AddComponent<Button> ();
		button.onClick.AddListener (()=>{
			OnClickCharacter(mCurrentChara.Charatype);
		});
		var newblock = button.colors;
		newblock.disabledColor = new Color(1f, 1f, 1f, 1f);
		newblock.highlightedColor = new Color(1f, 1f, 1f, 1f);
		newblock.pressedColor = new Color(1f, 1f, 1f, 1f);
		button.colors = newblock;

		*/

		//------------------------------------------------

		/*
		if (mCurrentChara != null) {
			Destroy (mCurrentChara.gameObject);
			mCurrentChara = null;
		}

		var target = CharacterImagePrefabs.Where (c => c.gameObject.name == type.ToString () + "_" + charaSaveData.mSelectedFashionId).FirstOrDefault ();

		if (target != null) {
			mCurrentChara = PrefabFolder.InstantiateTo<CharaSettingData> (target,this.transform);
			mCurrentChara.transform.localPosition = new Vector3(posData.x,posData.y);
			mCurrentChara.transform.localScale = new Vector3 (mCharaScale,mCharaScale,1);
			var button = mCurrentChara.gameObject.AddComponent<Button> ();
			button.onClick.AddListener (()=>{
				OnClickCharacter(mCurrentChara.Charatype);
			});
			var newblock = button.colors;
			newblock.disabledColor = new Color(1f, 1f, 1f, 1f);
			newblock.highlightedColor = new Color(1f, 1f, 1f, 1f);
			newblock.pressedColor = new Color(1f, 1f, 1f, 1f);
			button.colors = newblock;

		}
		*/
	}
	Action<CharacterType> mCharaTapCallBack;
	public void SetCharaTapEvent(Action<CharacterType> callback){
		mCharaTapCallBack = callback;
	}

	void OnClickCharacter(CharacterType chara){
		if (mCharaTapCallBack != null) {
			mCharaTapCallBack (chara);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
