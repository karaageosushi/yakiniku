using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[Serializable]
public class UserData  {
	//所持キャラクター
	public CharacterType mCurrentSelectedCharacter = CharacterType.NONE;
	//選択キャラクターセーブデータ
	public CharaSaveData mSelectedCharaSaveData{
		get{
			return mCharaSaveDataList.Where (cs => cs.CharacterType == mCurrentSelectedCharacter).FirstOrDefault ();
		}
	}
	public List<CharaSaveData> mCharaSaveDataList = new List<CharaSaveData> ();

	/// <summary>
	/// Json化されたキャラクターセーブデータ
	/// </summary>
	/// <value>The json chara save data.</value>
	public List<string> JsonCharaSaveData{
		get{
			return mCharaSaveDataList.Select (cs => cs.ToJson).ToList ();
		}
	}
	public UserData(){
	}
}
