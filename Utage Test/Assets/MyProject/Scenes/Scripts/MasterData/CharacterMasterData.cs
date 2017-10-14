using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterType{
	NONE=0,
	MNOINE=1,
	AINE=2,
	CANNON=3,
	PLIMMAVAERHA=4,
	LIEUNNE=5,
	JEMENOPPEEDY=6,
	HALNAUMY=7,
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
public struct CharaEpisodeData{
	public CharacterType mChara;
	public int mTitleNumber;
	public string mTitle;
	public int mPriceNecessaryRelease;

	public CharaEpisodeData(
		CharacterType chara,
		int number,
		string title,
		int priceNecessaryRelease
	){
		mChara = chara;
		mTitleNumber = number;
		mTitle = title;
		mPriceNecessaryRelease = priceNecessaryRelease;
	}
}



/// <summary>
/// キャラクター情報のマスターデータ
/// </summary>
public class CharacterMasterData {
	public static Dictionary<CharacterType,string> CharacterDict = new Dictionary<CharacterType, string>() {
		{CharacterType.NONE,""},
		{CharacterType.MNOINE,"ノイン"},
		{CharacterType.AINE,"アイネ"},
		{CharacterType.CANNON,"カノン"},
		{CharacterType.PLIMMAVAERHA,"プリマヴェーラ"},
		{CharacterType.LIEUNNE,"リュヌ"},
		{CharacterType.JEMENOPPEEDY,"ジムノペディ"},
		{CharacterType.HALNAUMY,"ハルノウミ"},
	};

	/// <summary>
	/// キャラクターのデータ　newばっかりで重いのであとでキャッシュするようにする・・・あとで・・・
	/// </summary>
	public static List<CharaCommentData> CharaCommentDataList = new List<CharaCommentData> (){
		new CharaCommentData(CharacterType.MNOINE,TimeType.MORNING,"ノイン:朝：コメント1"),
		new CharaCommentData(CharacterType.MNOINE,TimeType.MORNING,"ノイン:朝：コメント2"),
		new CharaCommentData(CharacterType.MNOINE,TimeType.MORNING,"ノイン:朝：コメント3"),
		new CharaCommentData(CharacterType.MNOINE,TimeType.MORNING,"ノイン:朝：コメント4"),
		new CharaCommentData(CharacterType.MNOINE,TimeType.NOON,"ノイン:昼：コメント"),
		new CharaCommentData(CharacterType.MNOINE,TimeType.THE_EVENING,"ノイン:夕：コメント"),
		new CharaCommentData(CharacterType.MNOINE,TimeType.NIGHT,"ノイン:夜：コメント"),
		new CharaCommentData(CharacterType.MNOINE,TimeType.LATE_NIGHT,"ノイン:深夜：コメント"),
		//----------------------------------
		new CharaCommentData(CharacterType.AINE,TimeType.MORNING,"アイネ:朝：コメント1"),
		new CharaCommentData(CharacterType.AINE,TimeType.MORNING,"アイネ:朝：コメント2"),
		new CharaCommentData(CharacterType.AINE,TimeType.MORNING,"アイネ:朝：コメント3"),
		new CharaCommentData(CharacterType.AINE,TimeType.MORNING,"アイネ:朝：コメント4"),
		new CharaCommentData(CharacterType.AINE,TimeType.NOON,"アイネ:昼：コメント"),
		new CharaCommentData(CharacterType.AINE,TimeType.THE_EVENING,"アイネ:夕：コメント"),
		new CharaCommentData(CharacterType.AINE,TimeType.NIGHT,"アイネ:夜：コメント"),
		new CharaCommentData(CharacterType.AINE,TimeType.LATE_NIGHT,"アイネ:深夜：コメント"),
		//----------------------------------
		new CharaCommentData(CharacterType.CANNON,TimeType.MORNING,"カノン:朝：コメント1"),
		new CharaCommentData(CharacterType.CANNON,TimeType.MORNING,"カノン:朝：コメント2"),
		new CharaCommentData(CharacterType.CANNON,TimeType.MORNING,"カノン:朝：コメント3"),
		new CharaCommentData(CharacterType.CANNON,TimeType.MORNING,"カノン:朝：コメント4"),
		new CharaCommentData(CharacterType.CANNON,TimeType.NOON,"カノン:昼：コメント"),
		new CharaCommentData(CharacterType.CANNON,TimeType.THE_EVENING,"カノン:夕：コメント"),
		new CharaCommentData(CharacterType.CANNON,TimeType.NIGHT,"カノン:夜：コメント"),
		new CharaCommentData(CharacterType.CANNON,TimeType.LATE_NIGHT,"カノン:深夜：コメント"),
		//----------------------------------
		new CharaCommentData(CharacterType.PLIMMAVAERHA,TimeType.MORNING,"プリマヴェーラ:朝：コメント1"),
		new CharaCommentData(CharacterType.PLIMMAVAERHA,TimeType.MORNING,"プリマヴェーラ:朝：コメント2"),
		new CharaCommentData(CharacterType.PLIMMAVAERHA,TimeType.MORNING,"プリマヴェーラ:朝：コメント3"),
		new CharaCommentData(CharacterType.PLIMMAVAERHA,TimeType.MORNING,"プリマヴェーラ:朝：コメント4"),
		new CharaCommentData(CharacterType.PLIMMAVAERHA,TimeType.NOON,"プリマヴェーラ:昼：コメント"),
		new CharaCommentData(CharacterType.PLIMMAVAERHA,TimeType.THE_EVENING,"プリマヴェーラ:夕：コメント"),
		new CharaCommentData(CharacterType.PLIMMAVAERHA,TimeType.NIGHT,"プリマヴェーラ:夜：コメント"),
		new CharaCommentData(CharacterType.PLIMMAVAERHA,TimeType.LATE_NIGHT,"プリマヴェーラ:深夜：コメント"),
		//----------------------------------
		new CharaCommentData(CharacterType.LIEUNNE,TimeType.MORNING,"リュヌ:朝：コメント1"),
		new CharaCommentData(CharacterType.LIEUNNE,TimeType.MORNING,"リュヌ:朝：コメント2"),
		new CharaCommentData(CharacterType.LIEUNNE,TimeType.MORNING,"リュヌ:朝：コメント3"),
		new CharaCommentData(CharacterType.LIEUNNE,TimeType.MORNING,"リュヌ:朝：コメント4"),
		new CharaCommentData(CharacterType.LIEUNNE,TimeType.NOON,"リュヌ:昼：コメント"),
		new CharaCommentData(CharacterType.LIEUNNE,TimeType.THE_EVENING,"リュヌ:夕：コメント"),
		new CharaCommentData(CharacterType.LIEUNNE,TimeType.NIGHT,"リュヌ:夜：コメント"),
		new CharaCommentData(CharacterType.LIEUNNE,TimeType.LATE_NIGHT,"リュヌ:深夜：コメント"),
		//----------------------------------
		new CharaCommentData(CharacterType.JEMENOPPEEDY,TimeType.MORNING,"ジムノペディ:朝：コメント1"),
		new CharaCommentData(CharacterType.JEMENOPPEEDY,TimeType.MORNING,"ジムノペディ:朝：コメント2"),
		new CharaCommentData(CharacterType.JEMENOPPEEDY,TimeType.MORNING,"ジムノペディ:朝：コメント3"),
		new CharaCommentData(CharacterType.JEMENOPPEEDY,TimeType.MORNING,"ジムノペディ:朝：コメント4"),
		new CharaCommentData(CharacterType.JEMENOPPEEDY,TimeType.NOON,"ジムノペディ:昼：コメント"),
		new CharaCommentData(CharacterType.JEMENOPPEEDY,TimeType.THE_EVENING,"ジムノペディ:夕：コメント"),
		new CharaCommentData(CharacterType.JEMENOPPEEDY,TimeType.NIGHT,"ジムノペディ:夜：コメント"),
		new CharaCommentData(CharacterType.JEMENOPPEEDY,TimeType.LATE_NIGHT,"ジムノペディ:深夜：コメント"),
		//----------------------------------
		new CharaCommentData(CharacterType.HALNAUMY,TimeType.MORNING,"ハルノウミ:朝：コメント1"),
		new CharaCommentData(CharacterType.HALNAUMY,TimeType.MORNING,"ハルノウミ:朝：コメント2"),
		new CharaCommentData(CharacterType.HALNAUMY,TimeType.MORNING,"ハルノウミ:朝：コメント3"),
		new CharaCommentData(CharacterType.HALNAUMY,TimeType.MORNING,"ハルノウミ:朝：コメント4"),
		new CharaCommentData(CharacterType.HALNAUMY,TimeType.NOON,"ハルノウミ:昼：コメント"),
		new CharaCommentData(CharacterType.HALNAUMY,TimeType.THE_EVENING,"ハルノウミ:夕：コメント"),
		new CharaCommentData(CharacterType.HALNAUMY,TimeType.NIGHT,"ハルノウミ:夜：コメント"),
		new CharaCommentData(CharacterType.HALNAUMY,TimeType.LATE_NIGHT,"ハルノウミ:深夜：コメント"),
		//----------------------------------
	};

	//キャラクターのエピソードデータ
	public static List<CharaEpisodeData> CharaEpsodeDataList = new List<CharaEpisodeData> (){
		new CharaEpisodeData(CharacterType.MNOINE,1,"無題",10),
		new CharaEpisodeData(CharacterType.MNOINE,2,"無題",10),
		new CharaEpisodeData(CharacterType.MNOINE,3,"無題",10),
		new CharaEpisodeData(CharacterType.MNOINE,4,"無題",10),
		new CharaEpisodeData(CharacterType.MNOINE,5,"無題",10),
		new CharaEpisodeData(CharacterType.MNOINE,6,"無題",10),
		new CharaEpisodeData(CharacterType.MNOINE,7,"着替え",10),
		//--------------------------------------------
		new CharaEpisodeData(CharacterType.AINE,1,"無題",10),
		new CharaEpisodeData(CharacterType.AINE,2,"無題",10),
		new CharaEpisodeData(CharacterType.AINE,3,"無題",10),
		new CharaEpisodeData(CharacterType.AINE,4,"無題",10),
		new CharaEpisodeData(CharacterType.AINE,5,"無題",10),
		new CharaEpisodeData(CharacterType.AINE,6,"無題",10),
		new CharaEpisodeData(CharacterType.AINE,7,"着替え",10),
		//--------------------------------------------
		new CharaEpisodeData(CharacterType.CANNON,1,"無題",10),
		new CharaEpisodeData(CharacterType.CANNON,2,"無題",10),
		new CharaEpisodeData(CharacterType.CANNON,3,"無題",10),
		new CharaEpisodeData(CharacterType.CANNON,4,"無題",10),
		new CharaEpisodeData(CharacterType.CANNON,5,"無題",10),
		new CharaEpisodeData(CharacterType.CANNON,6,"無題",10),
		new CharaEpisodeData(CharacterType.CANNON,7,"着替え",10),
		//--------------------------------------------
		new CharaEpisodeData(CharacterType.PLIMMAVAERHA,1,"無題",10),
		new CharaEpisodeData(CharacterType.PLIMMAVAERHA,2,"無題",10),
		new CharaEpisodeData(CharacterType.PLIMMAVAERHA,3,"無題",10),
		new CharaEpisodeData(CharacterType.PLIMMAVAERHA,4,"無題",10),
		new CharaEpisodeData(CharacterType.PLIMMAVAERHA,5,"無題",10),
		new CharaEpisodeData(CharacterType.PLIMMAVAERHA,6,"無題",10),
		new CharaEpisodeData(CharacterType.PLIMMAVAERHA,7,"着替え",10),
		//--------------------------------------------
		new CharaEpisodeData(CharacterType.LIEUNNE,1,"無題",10),
		new CharaEpisodeData(CharacterType.LIEUNNE,2,"無題",10),
		new CharaEpisodeData(CharacterType.LIEUNNE,3,"無題",10),
		new CharaEpisodeData(CharacterType.LIEUNNE,4,"無題",10),
		new CharaEpisodeData(CharacterType.LIEUNNE,5,"無題",10),
		new CharaEpisodeData(CharacterType.LIEUNNE,6,"無題",10),
		new CharaEpisodeData(CharacterType.LIEUNNE,7,"着替え",10),
		//--------------------------------------------
		new CharaEpisodeData(CharacterType.JEMENOPPEEDY,1,"無題",10),
		new CharaEpisodeData(CharacterType.JEMENOPPEEDY,2,"無題",10),
		new CharaEpisodeData(CharacterType.JEMENOPPEEDY,3,"無題",10),
		new CharaEpisodeData(CharacterType.JEMENOPPEEDY,4,"無題",10),
		new CharaEpisodeData(CharacterType.JEMENOPPEEDY,5,"無題",10),
		new CharaEpisodeData(CharacterType.JEMENOPPEEDY,6,"無題",10),
		new CharaEpisodeData(CharacterType.JEMENOPPEEDY,7,"着替え",10),
		//--------------------------------------------
		new CharaEpisodeData(CharacterType.HALNAUMY,1,"無題",10),
		new CharaEpisodeData(CharacterType.HALNAUMY,2,"無題",10),
		new CharaEpisodeData(CharacterType.HALNAUMY,3,"無題",10),
		new CharaEpisodeData(CharacterType.HALNAUMY,4,"無題",10),
		new CharaEpisodeData(CharacterType.HALNAUMY,5,"無題",10),
		new CharaEpisodeData(CharacterType.HALNAUMY,6,"無題",10),
		new CharaEpisodeData(CharacterType.HALNAUMY,7,"着替え",10),
		//--------------------------------------------
	};



}
