using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharaDetaileScene : BaseScene {

	[SerializeField]
	MainScene mMainScene;
	[SerializeField]
	Transform mCharacterEmmiter;
	[SerializeField]
	Text mComposerName;
	[SerializeField]
	Text mSongName;
	[SerializeField]
	Text mHistory;
	[SerializeField]
	Text mCharacterInfo;
	[SerializeField]
	CharacterImageSelector mCharacterImageSelector;
	[SerializeField]
	Text mCharaName;
	[SerializeField]
	MusicSelectScene mMusicSelectScene;

	AdvCharacterInfo mAdvCharacterInfo;
	CharacterType mCharacterType;

	public void Init(AdvCharacterInfo info,CharacterType chara){
		mAdvCharacterInfo = info;
		mCharacterType = chara;
		mComposerName.text = info.mComposerName;
		mSongName.text = info.mSongName;
		mHistory.text = info.mHistory;
		mCharacterInfo.text = info.mCharacterInfo;
		mCharaName.text = info.mCharaName;
		mCharacterImageSelector.ShowCharactor (chara);

	}

	public override void Open ()
	{
		base.Open ();
	}

	public override void Close ()
	{
		base.Close ();
	}

	public void GotoMusicSelectScene(){
		mMusicSelectScene.Open ();
		Close ();
	}

	public void SetMainChara(){
		GameSystemManager.Instance.UserData.mCurrentSelectedCharacter = mCharacterType;
		mMainScene.UpdateMainDisplay();
		Close ();
	}

	// Use this for initialization
	void Start () {
		
	}
}
