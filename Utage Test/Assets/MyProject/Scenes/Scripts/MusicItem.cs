using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class MusicItem : MonoBehaviour {

	CharacterType mCharacterType;
	Action mOnClickEpisodeButtonCallBack;
	Action mOnCharaSelectButtonCallBack;
	[SerializeField]
	Text mCharaNameLabel;
	[SerializeField]
	Text mMusicTimeLabel;


	public void Init(CharacterType chara,Action onClickEpisodeButtonCallBack,Action onCharaSelectButtonCallBack){
		mCharacterType = chara;
		mOnClickEpisodeButtonCallBack = onClickEpisodeButtonCallBack;
		mOnCharaSelectButtonCallBack = onCharaSelectButtonCallBack;
		mCharaNameLabel.text = CharacterData.CharacterDict[chara];
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
