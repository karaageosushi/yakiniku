using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

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
	[SerializeField]
	FashionSelectDialog mFashionSelectDialog;

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
		SaveData.SaveUserData ();
		Close ();
	}

	public void OpenmFashionSelectDialog(){
		mFashionSelectDialog.Init (
			CharacterMasterData.CharaFashionDataList.Where(cf=>cf.mChara == mCharacterType).ToList(),
			()=>{mCharacterImageSelector.ShowCharactor(mCharacterType);}
		);
	}

	// Use this for initialization
	void Start () {
		
	}
}
