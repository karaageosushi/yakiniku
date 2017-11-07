using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class CharacterImageSelector : MonoBehaviour {

	[SerializeField]
	List<CharaSettingData>CharacterImagePrefabs;
	CharaSettingData mCurrentChara=null;
	[SerializeField]
	float mCharaScale = 1.8f;

	public void ShowCharactor(CharacterType type){

		if (mCurrentChara != null) {
			Destroy (mCurrentChara.gameObject);
			mCurrentChara = null;
		}

		var posData = CharacterMasterData.CharaTopPostionList.Where (pd => pd.mChara == type).FirstOrDefault ().mPostion;

		var charaSaveData = GameSystemManager.Instance.UserData.mCharaSaveDataList.Where (cs => cs.mCharacterType == (int)type).First ();
		var target = CharacterImagePrefabs.Where (c => c.gameObject.name == type.ToString () + "_" + charaSaveData.mSelectedFashionId).FirstOrDefault ();

		if (target != null) {
			mCurrentChara = PrefabFolder.InstantiateTo<CharaSettingData> (target,this.transform);
			mCurrentChara.transform.localPosition = new Vector3(posData.x,posData.y);
			mCurrentChara.transform.localScale = new Vector3 (mCharaScale,mCharaScale,1);
			var button = mCurrentChara.gameObject.AddComponent<Button> ();
			button.onClick.AddListener (()=>{
				OnClickCharacter(mCurrentChara.Charatype);
			});
			//ColorBlock colors = new ColorBlock ();

			var newblock = button.colors;
			newblock.disabledColor = new Color(1f, 1f, 1f, 1f);
			newblock.highlightedColor = new Color(1f, 1f, 1f, 1f);
			newblock.pressedColor = new Color(1f, 1f, 1f, 1f);
			button.colors = newblock;

			//button.colors.disabledColor = new Color(255.0f, 255.0f, 255.0f);
			//button.colors.highlightedColor = Color.white;
			//button.colors.pressedColor = Color.white;

		}


		//CharacterImages.ForEach (c=>c.gameObject.SetActive(false));
		//CharacterImages [(int)type].gameObject.SetActive (true);
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
