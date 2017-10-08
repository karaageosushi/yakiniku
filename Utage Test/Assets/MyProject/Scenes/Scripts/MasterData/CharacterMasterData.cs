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

public enum TimeType{
	MORNING,
	NOON,
	THE_EVENING,
	NIGHT,
	LATE_NIGHT,
}
public class TimeUtil{
	public static TimeType GetCurrentTimeType(){
		//ここの値は、正確に取得したいならサーバー時間にする
		var currentTime = System.DateTime.Now;
		if (currentTime.Hour >= 6 && currentTime.Hour <= 9) {
			return TimeType.MORNING;
		} else if (currentTime.Hour >= 10 && currentTime.Hour <= 14) {
			return TimeType.NOON;
		} else if (currentTime.Hour >= 15 && currentTime.Hour <= 17) {
			return TimeType.THE_EVENING;
		} else if (currentTime.Hour >= 18 && currentTime.Hour <= 0) {
			return TimeType.NIGHT;
		} else if (currentTime.Hour >= 1 && currentTime.Hour <= 5) {
			return TimeType.LATE_NIGHT;
		} else {
			return TimeType.MORNING;
		}
	}
}

public struct CharaCommentData{
	public CharacterType mChara;
	public TimeType mTime;
	public string mComment;

	public CharaCommentData(
		CharacterType chara,
		TimeType time,
		string comment
	){
		mChara = chara;
		mTime = time;
		mComment = comment;
	}
}

/// <summary>
/// キャラクター情報のマスターデータ
/// </summary>
public class CharacterMasterData {
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

	/// <summary>
	/// 取り急ぎは、３人のコメントを入れときました！
	/// </summary>
	public static List<CharaCommentData> CharaCommentDataList = new List<CharaCommentData> (){
		new CharaCommentData(CharacterType.CANON,TimeType.MORNING,"カノン・バッハベル:朝：コメント1"),
		new CharaCommentData(CharacterType.CANON,TimeType.MORNING,"カノン・バッハベル:朝：コメント2"),
		new CharaCommentData(CharacterType.CANON,TimeType.MORNING,"カノン・バッハベル:朝：コメント3"),
		new CharaCommentData(CharacterType.CANON,TimeType.MORNING,"カノン・バッハベル:朝：コメント4"),
		new CharaCommentData(CharacterType.CANON,TimeType.NOON,"カノン・バッハベル:昼：コメント"),
		new CharaCommentData(CharacterType.CANON,TimeType.THE_EVENING,"カノン・バッハベル:夕：コメント"),
		new CharaCommentData(CharacterType.CANON,TimeType.NIGHT,"カノン・バッハベル:夜：コメント"),
		new CharaCommentData(CharacterType.CANON,TimeType.LATE_NIGHT,"カノン・バッハベル:深夜：コメント"),
		//----------------------------------
		new CharaCommentData(CharacterType.BEETHOVEN,TimeType.MORNING,"ベートーヴェン:朝：コメント"),
		new CharaCommentData(CharacterType.BEETHOVEN,TimeType.NOON,"ベートーヴェン:昼：コメント"),
		new CharaCommentData(CharacterType.BEETHOVEN,TimeType.THE_EVENING,"ベートーヴェン:夕：コメント"),
		new CharaCommentData(CharacterType.BEETHOVEN,TimeType.NIGHT,"ベートーヴェン:夜：コメント"),
		new CharaCommentData(CharacterType.BEETHOVEN,TimeType.LATE_NIGHT,"ベートーヴェン:深夜：コメント"),
		//----------------------------------
		new CharaCommentData(CharacterType.BRAHMS,TimeType.MORNING,"ブラームス:朝：コメント"),
		new CharaCommentData(CharacterType.BRAHMS,TimeType.NOON,"ブラームス:昼：コメント"),
		new CharaCommentData(CharacterType.BRAHMS,TimeType.THE_EVENING,"ブラームス:夕：コメント"),
		new CharaCommentData(CharacterType.BRAHMS,TimeType.NIGHT,"ブラームス:夜：コメント"),
		new CharaCommentData(CharacterType.BRAHMS,TimeType.LATE_NIGHT,"ブラームス:深夜：コメント"),
		//----------------------------------
	};

}
