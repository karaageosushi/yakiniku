using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusItem : MonoBehaviour {
	[SerializeField]
	Image mRewordIcon;
	[SerializeField]
	Image mDecorationIcon;
	[SerializeField]
	Text mTitle;
	[SerializeField]
	Text mInfoText;

	public void Init(BonusData data){
		mRewordIcon.gameObject.SetActive (false);
		mDecorationIcon.gameObject.SetActive (false);
		if (!data.mWithRewards)
			mRewordIcon.gameObject.SetActive (false);
		mTitle.text = data.mTitle;
		mInfoText.text = data.mConditionText;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
