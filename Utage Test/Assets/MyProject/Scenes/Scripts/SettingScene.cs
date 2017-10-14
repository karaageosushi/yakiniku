using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SoundUtil;

public class SettingScene : BaseScene {

	[SerializeField]
	Slider mBGMSlider;
	[SerializeField]
	Slider mSESlider;

	public override void Open ()
	{
		base.Open ();
		mBGMSlider.value = SoundManager.Instance.volume.bgm;
		mSESlider.value = SoundManager.Instance.volume.se;
	}

	public override void Close ()
	{
		base.Close ();
		SoundManager.Instance.volume.bgm = mBGMSlider.value;
		SoundManager.Instance.volume.se = mSESlider.value;
		GameSystemManager.Instance.UserData.mVolBgm = mBGMSlider.value;
		GameSystemManager.Instance.UserData.mVolSe = mSESlider.value;
		SaveData.SaveUserData ();
	}

	// Use this for initialization
	void Start () {
		
	}
}
