using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using SoundUtil;

public class MusicItem : MonoBehaviour {

	CharacterType mCharacterType;
	public CharacterType CharacterType{
		get{
			return mCharacterType;
		}
	}
	Action mOnClickEpisodeButtonCallBack;
	Action mOnCharaSelectButtonCallBack;
	[SerializeField]
	Text mCharaNameLabel;
	[SerializeField]
	Text mMusicTimeLabel;
	[SerializeField]
	Button mCharaSelectButton;


	public void Init(CharacterType chara,Action onClickEpisodeButtonCallBack,Action onCharaSelectButtonCallBack){
		mCharacterType = chara;
		mOnClickEpisodeButtonCallBack = onClickEpisodeButtonCallBack;
		mOnCharaSelectButtonCallBack = onCharaSelectButtonCallBack;
		mCharaNameLabel.text = CharacterMasterData.CharacterDict[chara].mCharaName;
		var charaPrefab = PrefabFolder.ResourcesLoadInstantiateTo<CharaSettingData>("Prefabs/CharacterCutIns/"+chara.ToString(),mCharaSelectButton.transform);
		charaPrefab.SetCutInPos ();
		var MusicLength = SoundManager.Instance.BgmClips[(int)chara].length;
		mMusicTimeLabel.text = new FroatToMinUtil().FroatToMin((MusicLength));
	}

	/// <summary>
	/// キャラクターのエピソードボタンを押した場合
	/// </summary>
	public void OnClickEpisodeButton(){
		mOnClickEpisodeButtonCallBack ();
	}
	/// <summary>
	/// キャラ選択を押した場合
	/// </summary>
	public void OnCharaSelectButton(){
		GameSystemManager.Instance.UserData.mCurrentSelectedCharacter = mCharacterType;
		//画面を戻る処理
		mOnCharaSelectButtonCallBack();
	}

	// Use this for initialization
	void Start () {
		
	}
}
