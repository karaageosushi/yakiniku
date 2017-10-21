using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class FashionItem : MonoBehaviour {
	[SerializeField]
	Text mTitle;
	[SerializeField]
	Button mButton;
	CharaFashionData mData;

	public void Init(CharaFashionData data,FashionSelectDialog dialog){
		mData = data;
		mTitle.text = data.mName;
		mButton.onClick.RemoveAllListeners ();
		mButton.onClick.AddListener (()=>{
			//通常選択時の処理を記載
			var chara = GameSystemManager.Instance.UserData.mCharaSaveDataList.Where(c=>c.mCharacterType == (int)data.mChara).First();
			chara.mSelectedFashionId = data.mId;
			dialog.Close();
		});
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
