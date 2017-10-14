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
	public CharaSaveData GetCharacterSaveDataFromType(CharacterType type){
		return mCharaSaveDataList.Where (cs => cs.CharacterType == type).FirstOrDefault ();
	}
	public List<CharaSaveData> mCharaSaveDataList = new List<CharaSaveData> ();
	public int mMoney = 0;
	public float mVolBgm = 0.5f;
	public float mVolSe = 0.5f;

	//public string mJsonCharaSaveData= "";

	/// <summary>
	/// Json化されたキャラクターセーブデータ
	/// </summary>
	/// <value>The json chara save data.</value>
	/*
	public List<string> JsonCharaSaveData{
		get{
			return mCharaSaveDataList.Select (cs => cs.ToJson).ToList ();
		}
	}
*/
	public string ToJson(){
		/*
		mJsonCharaSaveData = "";
		foreach (var item in mJsonCharaSaveData) {
			mJsonCharaSaveData += item;
			mJsonCharaSaveData += "/";
		}
		*/
		return JsonUtility.ToJson (this);
	}

	public static UserData FromJson(string json){
		UserData data = JsonUtility.FromJson<UserData> (json);
		//string[] charaDataArry = data.mJsonCharaSaveData.Split('/');
		//data.mCharaSaveDataList = charaDataArry.Select (cd => JsonUtility.FromJson<CharaSaveData> (cd)).ToList ();

		return data;
	}

	public UserData(){
	}
}
