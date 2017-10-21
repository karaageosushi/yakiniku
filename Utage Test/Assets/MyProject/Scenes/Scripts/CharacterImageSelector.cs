using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CharacterImageSelector : MonoBehaviour {

	[SerializeField]
	List<CharaSettingData>CharacterImagePrefabs;
	CharaSettingData mCurrentChara=null;
	[SerializeField]
	float mCharaPostionX;
	[SerializeField]
	float mCharaPostionY;
	[SerializeField]
	float mCharaScale = 1.8f;

	public void ShowCharactor(CharacterType type){

		if (mCurrentChara != null) {
			Destroy (mCurrentChara.gameObject);
			mCurrentChara = null;
		}

		var charaSaveData = GameSystemManager.Instance.UserData.mCharaSaveDataList.Where (cs => cs.mCharacterType == (int)type).First ();
		var target = CharacterImagePrefabs.Where (c => c.gameObject.name == type.ToString () + "_" + charaSaveData.mSelectedFashionId).FirstOrDefault ();

		if (target != null) {
			mCurrentChara = PrefabFolder.InstantiateTo<CharaSettingData> (target,this.transform);
			mCurrentChara.transform.localPosition = new Vector3(mCharaPostionX,mCharaPostionY);
			mCurrentChara.transform.localScale = new Vector3 (mCharaScale,mCharaScale,1);
		}


		//CharacterImages.ForEach (c=>c.gameObject.SetActive(false));
		//CharacterImages [(int)type].gameObject.SetActive (true);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
