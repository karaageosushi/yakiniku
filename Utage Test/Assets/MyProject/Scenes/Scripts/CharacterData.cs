using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterType{
	NONE=0,
	CANON=1,
	CHOPIN=2,
	MOZART =3,
	BEETHOVEN=4,
	TCHAIKOVSKY=5,
	RACHMANINOFF=6,
	LIST=7,
	RAVEL=8,
	DEBUSSY=9,
	BRAHMS=10,

}
/// <summary>
/// キャラクター情報のマスターデータ
/// </summary>
public class CharacterData {
	public static Dictionary<CharacterType,string> CharacterDict = new Dictionary<CharacterType, string>() {
		{CharacterType.NONE,""},
		{CharacterType.CANON,"カノン・バッハベル"},
		{CharacterType.CHOPIN,"ショパン"},
		{CharacterType.MOZART,"モーツァルト"},
		{CharacterType.BEETHOVEN,"ベートーヴェン"},
		{CharacterType.TCHAIKOVSKY,"チャイコフスキー"},
		{CharacterType.RACHMANINOFF,"ラフマニノフ"},
		{CharacterType.LIST,"リスト"},
		{CharacterType.RAVEL,"ラヴェル"},
		{CharacterType.DEBUSSY,"ドビュッシー"},
		{CharacterType.BRAHMS,"ブラームス"},
	};

}
