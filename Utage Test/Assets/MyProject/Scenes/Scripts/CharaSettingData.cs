using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaSettingData : MonoBehaviour {
	public float mCharaCutinPosX = 0;
	public float mCharaCutinPosY = 0;
	[SerializeField]
	CharacterType mCharatype;
	public CharacterType Charatype{
		get{
			return mCharatype;
		}
	}
	/// <summary>
	/// カットインで設定した座標に配置
	/// </summary>
	public void SetCutInPos(){
		this.transform.localPosition = new Vector3 (mCharaCutinPosX,mCharaCutinPosY);
	}
}
