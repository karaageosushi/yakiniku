using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[Serializable]
public class UserData  {
	//所持キャラクター
	public CharacterType mCurrentSelectedCharacter = CharacterType.NONE;
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
