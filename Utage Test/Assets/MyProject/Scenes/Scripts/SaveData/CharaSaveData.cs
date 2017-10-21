using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class CharaSaveData  {
	/// <summary>
	/// 親密度
	/// </summary>
	public int mLovePoint=0;
	/// <summary>
	/// キャラクタータイプ
	/// CharacterType型にキャストして使う
	/// </summary>
	public int mCharacterType=0;

	public int mStoryReleaseCount = 1;

	public int mFashionReleaseCount = 1;

	public int mSelectedFashionId = 0;

	public CharaSaveData(){
	}

	public CharacterType CharacterType{
		get{
			return (CharacterType)mCharacterType;
		}
	}

	public string ToJson{
		get{
			return JsonUtility.ToJson(this);
		}
	}
}
