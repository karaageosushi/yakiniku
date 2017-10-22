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

public enum CommentType{
	MORNING,//朝
	NOON,//昼
	THE_EVENING,//夕方
	NIGHT,//夜
	LATE_NIGHT,//深夜
	TIMER,//タイマー時
	COMMON,//汎用
	TIMER_SUCCESS,//タイマー成功
	TIMER_FAILURE,//タイマー失敗
	TAPPED,//タップ時
	LEAVING,//放置時
}
public class TimeUtil{
	public static CommentType GetCurrentTimeType(){
		//ここの値は、正確に取得したいならサーバー時間にする
		var currentTime = System.DateTime.Now;
		//Debug.Log ("currentTime.Hour="+currentTime.Hour);
		if (currentTime.Hour >= 6 && currentTime.Hour <= 9) {
			return CommentType.MORNING;
		} else if (currentTime.Hour >= 10 && currentTime.Hour <= 14) {
			return CommentType.NOON;
		} else if (currentTime.Hour >= 15 && currentTime.Hour <= 17) {
			return CommentType.THE_EVENING;
		} else if (currentTime.Hour >= 18 && currentTime.Hour <= 23) {
			return CommentType.NIGHT;
		} else if (currentTime.Hour >= 0 && currentTime.Hour <= 5) {
			return CommentType.LATE_NIGHT;
		} else {
			Debug.LogError ("規定外の時間です");
			return CommentType.MORNING;
		}
	}
}

public struct CharaCommentData{
	public CharacterType mChara;
	public CommentType mCommentType;
	public string mComment;

	public CharaCommentData(
		CharacterType chara,
		CommentType time,
		string comment
	){
		mChara = chara;
		mCommentType = time;
		mComment = comment;
	}
}
public struct CharaFashionData{
	public CharacterType mChara;
	public int mId;
	public string mName;

	public CharaFashionData(
		CharacterType chara,
		int id,
		string name
	){
		mChara = chara;
		mId = id;
		mName = name;
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

public struct AdvCharacterInfo{
	public string mCharaName;
	public string mComposerName;
	public string mSongName;
	public string mHistory;
	public string mCharacterInfo;

	public AdvCharacterInfo(
		string charaName,
		string composerName,
		string songName,
		string history,
		string characterInfo
	){
		mCharaName = charaName;
		mComposerName = composerName;
		mSongName = songName;
		mHistory = history;
		mCharacterInfo = characterInfo;
	}

}

/// <summary>
/// キャラクター情報のマスターデータ
/// </summary>
public class CharacterMasterData {
	public static Dictionary<CharacterType,AdvCharacterInfo> CharacterDict = new Dictionary<CharacterType, AdvCharacterInfo>() {
		{CharacterType.NONE,
			new AdvCharacterInfo(
				"",
				"",
				"",
				"",
				"")
		},
		{CharacterType.MNOINE,
			new AdvCharacterInfo(
				"ノイン",
				"作曲者名が入ります",
				"曲名が入ります",
				"時代が入ります",
				"キャラ説明が入ります¥nキャラ説明が入ります¥nキャラ説明が入ります¥n")
			},
		{CharacterType.AINE,
			new AdvCharacterInfo(
				"アイネ",
				"作曲者名が入ります",
				"曲名が入ります",
				"時代が入ります",
				"キャラ説明が入ります¥nキャラ説明が入ります¥nキャラ説明が入ります¥n")
			},
		{CharacterType.CANNON,
			new AdvCharacterInfo(
				"カノン",
				"作曲者名が入ります",
				"曲名が入ります",
				"時代が入ります",
				"キャラ説明が入ります¥nキャラ説明が入ります¥nキャラ説明が入ります¥n")
			},
		{CharacterType.PLIMMAVAERHA,
			new AdvCharacterInfo(
				"プリマヴェーラ",
				"作曲者名が入ります",
				"曲名が入ります",
				"時代が入ります",
				"キャラ説明が入ります¥nキャラ説明が入ります¥nキャラ説明が入ります¥n")
			},
		{CharacterType.LIEUNNE,
			new AdvCharacterInfo(
				"リュヌ",
				"作曲者名が入ります",
				"曲名が入ります",
				"時代が入ります",
				"キャラ説明が入ります¥nキャラ説明が入ります¥nキャラ説明が入ります¥n")
			},
		{CharacterType.JEMENOPPEEDY,
			new AdvCharacterInfo(
				"ジムノペディ",
				"作曲者名が入ります",
				"曲名が入ります",
				"時代が入ります",
				"キャラ説明が入ります¥nキャラ説明が入ります¥nキャラ説明が入ります¥n")
			},
		{CharacterType.HALNAUMY,
			new AdvCharacterInfo(
				"ハルノウミ",
				"作曲者名が入ります",
				"曲名が入ります",
				"時代が入ります",
				"キャラ説明が入ります¥nキャラ説明が入ります¥nキャラ説明が入ります¥n")
			},
	};

	/// <summary>
	/// キャラクターのデータ　newばっかりで重いのであとでキャッシュするようにする・・・あとで・・・
	/// </summary>
	public static List<CharaCommentData> CharaCommentDataList = new List<CharaCommentData> (){
		new CharaCommentData(CharacterType.MNOINE,CommentType.MORNING,"ノイン:朝：コメント1"),
		new CharaCommentData(CharacterType.MNOINE,CommentType.MORNING,"ノイン:朝：コメント2"),
		new CharaCommentData(CharacterType.MNOINE,CommentType.MORNING,"ノイン:朝：コメント3"),
		new CharaCommentData(CharacterType.MNOINE,CommentType.MORNING,"ノイン:朝：コメント4"),
		new CharaCommentData(CharacterType.MNOINE,CommentType.NOON,"ノイン:昼：コメント"),
		new CharaCommentData(CharacterType.MNOINE,CommentType.THE_EVENING,"ノイン:夕：コメント"),
		new CharaCommentData(CharacterType.MNOINE,CommentType.NIGHT,"ノイン:夜：コメント"),
		new CharaCommentData(CharacterType.MNOINE,CommentType.LATE_NIGHT,"ノイン:深夜：コメント"),
		new CharaCommentData(CharacterType.MNOINE,CommentType.TIMER,"ノイン:再生中コメント"),
		new CharaCommentData(CharacterType.MNOINE,CommentType.COMMON,"ノイン:汎用コメント"),
		new CharaCommentData(CharacterType.MNOINE,CommentType.TIMER_SUCCESS,"ノイン:タイマー成功時コメント"),
		new CharaCommentData(CharacterType.MNOINE,CommentType.TIMER_FAILURE,"ノイン:タイマー失敗時コメント"),
		new CharaCommentData(CharacterType.MNOINE,CommentType.LEAVING,"ノイン:放置時コメント"),
		new CharaCommentData(CharacterType.MNOINE,CommentType.TAPPED,"ノイン:タップ時コメント"),

		//----------------------------------
		new CharaCommentData(CharacterType.AINE,CommentType.MORNING,"アイネ:朝：コメント1"),
		new CharaCommentData(CharacterType.AINE,CommentType.MORNING,"アイネ:朝：コメント2"),
		new CharaCommentData(CharacterType.AINE,CommentType.MORNING,"アイネ:朝：コメント3"),
		new CharaCommentData(CharacterType.AINE,CommentType.MORNING,"アイネ:朝：コメント4"),
		new CharaCommentData(CharacterType.AINE,CommentType.NOON,"アイネ:昼：コメント"),
		new CharaCommentData(CharacterType.AINE,CommentType.THE_EVENING,"アイネ:夕：コメント"),
		new CharaCommentData(CharacterType.AINE,CommentType.NIGHT,"アイネ:夜：コメント"),
		new CharaCommentData(CharacterType.AINE,CommentType.LATE_NIGHT,"アイネ:深夜：コメント"),
		new CharaCommentData(CharacterType.AINE,CommentType.TIMER,"アイネ:再生中コメント"),
		new CharaCommentData(CharacterType.AINE,CommentType.COMMON,"アイネ:汎用コメント"),
		new CharaCommentData(CharacterType.AINE,CommentType.TIMER_SUCCESS,"アイネ:タイマー成功時コメント"),
		new CharaCommentData(CharacterType.AINE,CommentType.TIMER_FAILURE,"アイネ:タイマー失敗時コメント"),
		new CharaCommentData(CharacterType.AINE,CommentType.LEAVING,"アイネ:放置時コメント"),
		new CharaCommentData(CharacterType.AINE,CommentType.TAPPED,"アイネ:タップ時コメント"),

		//----------------------------------
		new CharaCommentData(CharacterType.CANNON,CommentType.MORNING,"カノン:朝：コメント1"),
		new CharaCommentData(CharacterType.CANNON,CommentType.MORNING,"カノン:朝：コメント2"),
		new CharaCommentData(CharacterType.CANNON,CommentType.MORNING,"カノン:朝：コメント3"),
		new CharaCommentData(CharacterType.CANNON,CommentType.MORNING,"カノン:朝：コメント4"),
		new CharaCommentData(CharacterType.CANNON,CommentType.NOON,"カノン:昼：コメント"),
		new CharaCommentData(CharacterType.CANNON,CommentType.THE_EVENING,"カノン:夕：コメント"),
		new CharaCommentData(CharacterType.CANNON,CommentType.NIGHT,"カノン:夜：コメント"),
		new CharaCommentData(CharacterType.CANNON,CommentType.LATE_NIGHT,"カノン:深夜：コメント"),
		new CharaCommentData(CharacterType.CANNON,CommentType.TIMER,"カノン:再生中コメント"),
		new CharaCommentData(CharacterType.CANNON,CommentType.COMMON,"カノン:汎用コメント"),
		new CharaCommentData(CharacterType.CANNON,CommentType.TIMER_SUCCESS,"カノン:タイマー成功時コメント"),
		new CharaCommentData(CharacterType.CANNON,CommentType.TIMER_FAILURE,"カノン:タイマー失敗時コメント"),
		new CharaCommentData(CharacterType.CANNON,CommentType.LEAVING,"カノン:放置時コメント"),
		new CharaCommentData(CharacterType.CANNON,CommentType.TAPPED,"カノン:タップ時コメント"),

		//----------------------------------
		new CharaCommentData(CharacterType.PLIMMAVAERHA,CommentType.MORNING,"プリマヴェーラ:朝：コメント1"),
		new CharaCommentData(CharacterType.PLIMMAVAERHA,CommentType.MORNING,"プリマヴェーラ:朝：コメント2"),
		new CharaCommentData(CharacterType.PLIMMAVAERHA,CommentType.MORNING,"プリマヴェーラ:朝：コメント3"),
		new CharaCommentData(CharacterType.PLIMMAVAERHA,CommentType.MORNING,"プリマヴェーラ:朝：コメント4"),
		new CharaCommentData(CharacterType.PLIMMAVAERHA,CommentType.NOON,"プリマヴェーラ:昼：コメント"),
		new CharaCommentData(CharacterType.PLIMMAVAERHA,CommentType.THE_EVENING,"プリマヴェーラ:夕：コメント"),
		new CharaCommentData(CharacterType.PLIMMAVAERHA,CommentType.NIGHT,"プリマヴェーラ:夜：コメント"),
		new CharaCommentData(CharacterType.PLIMMAVAERHA,CommentType.LATE_NIGHT,"プリマヴェーラ:深夜：コメント"),
		new CharaCommentData(CharacterType.PLIMMAVAERHA,CommentType.TIMER,"プリマヴェーラ:再生中コメント"),
		new CharaCommentData(CharacterType.PLIMMAVAERHA,CommentType.COMMON,"プリマヴェーラ:汎用コメント"),
		new CharaCommentData(CharacterType.PLIMMAVAERHA,CommentType.TIMER_SUCCESS,"プリマヴェーラ:タイマー成功時コメント"),
		new CharaCommentData(CharacterType.PLIMMAVAERHA,CommentType.TIMER_FAILURE,"プリマヴェーラ:タイマー失敗時コメント"),
		new CharaCommentData(CharacterType.PLIMMAVAERHA,CommentType.LEAVING,"プリマヴェーラ:放置時コメント"),
		new CharaCommentData(CharacterType.PLIMMAVAERHA,CommentType.TAPPED,"プリマヴェーラ:タップ時コメント"),

		//----------------------------------
		new CharaCommentData(CharacterType.LIEUNNE,CommentType.MORNING,"リュヌ:朝：コメント1"),
		new CharaCommentData(CharacterType.LIEUNNE,CommentType.MORNING,"リュヌ:朝：コメント2"),
		new CharaCommentData(CharacterType.LIEUNNE,CommentType.MORNING,"リュヌ:朝：コメント3"),
		new CharaCommentData(CharacterType.LIEUNNE,CommentType.MORNING,"リュヌ:朝：コメント4"),
		new CharaCommentData(CharacterType.LIEUNNE,CommentType.NOON,"リュヌ:昼：コメント"),
		new CharaCommentData(CharacterType.LIEUNNE,CommentType.THE_EVENING,"リュヌ:夕：コメント"),
		new CharaCommentData(CharacterType.LIEUNNE,CommentType.NIGHT,"リュヌ:夜：コメント"),
		new CharaCommentData(CharacterType.LIEUNNE,CommentType.LATE_NIGHT,"リュヌ:深夜：コメント"),
		new CharaCommentData(CharacterType.LIEUNNE,CommentType.TIMER,"リュヌ:再生中コメント"),
		new CharaCommentData(CharacterType.LIEUNNE,CommentType.COMMON,"リュヌ:汎用コメント"),
		new CharaCommentData(CharacterType.LIEUNNE,CommentType.TIMER_SUCCESS,"リュヌ:タイマー成功時コメント"),
		new CharaCommentData(CharacterType.LIEUNNE,CommentType.TIMER_FAILURE,"リュヌ:タイマー失敗時コメント"),
		new CharaCommentData(CharacterType.LIEUNNE,CommentType.LEAVING,"リュヌ:放置時コメント"),
		new CharaCommentData(CharacterType.LIEUNNE,CommentType.TAPPED,"リュヌ:タップ時コメント"),

		//----------------------------------
		new CharaCommentData(CharacterType.JEMENOPPEEDY,CommentType.MORNING,"ジムノペディ:朝：コメント1"),
		new CharaCommentData(CharacterType.JEMENOPPEEDY,CommentType.MORNING,"ジムノペディ:朝：コメント2"),
		new CharaCommentData(CharacterType.JEMENOPPEEDY,CommentType.MORNING,"ジムノペディ:朝：コメント3"),
		new CharaCommentData(CharacterType.JEMENOPPEEDY,CommentType.MORNING,"ジムノペディ:朝：コメント4"),
		new CharaCommentData(CharacterType.JEMENOPPEEDY,CommentType.NOON,"ジムノペディ:昼：コメント"),
		new CharaCommentData(CharacterType.JEMENOPPEEDY,CommentType.THE_EVENING,"ジムノペディ:夕：コメント"),
		new CharaCommentData(CharacterType.JEMENOPPEEDY,CommentType.NIGHT,"ジムノペディ:夜：コメント"),
		new CharaCommentData(CharacterType.JEMENOPPEEDY,CommentType.LATE_NIGHT,"ジムノペディ:深夜：コメント"),
		new CharaCommentData(CharacterType.JEMENOPPEEDY,CommentType.TIMER,"ジムノペディ:再生中コメント"),
		new CharaCommentData(CharacterType.JEMENOPPEEDY,CommentType.COMMON,"ジムノペディ:汎用コメント"),
		new CharaCommentData(CharacterType.JEMENOPPEEDY,CommentType.TIMER_SUCCESS,"ジムノペディ:タイマー成功時コメント"),
		new CharaCommentData(CharacterType.JEMENOPPEEDY,CommentType.TIMER_FAILURE,"ジムノペディ:タイマー失敗時コメント"),
		new CharaCommentData(CharacterType.JEMENOPPEEDY,CommentType.LEAVING,"ジムノペディ:放置時コメント"),
		new CharaCommentData(CharacterType.JEMENOPPEEDY,CommentType.TAPPED,"ジムノペディ:タップ時コメント"),


		//----------------------------------
		new CharaCommentData(CharacterType.HALNAUMY,CommentType.MORNING,"ハルノウミ:朝：コメント1"),
		new CharaCommentData(CharacterType.HALNAUMY,CommentType.MORNING,"ハルノウミ:朝：コメント2"),
		new CharaCommentData(CharacterType.HALNAUMY,CommentType.MORNING,"ハルノウミ:朝：コメント3"),
		new CharaCommentData(CharacterType.HALNAUMY,CommentType.MORNING,"ハルノウミ:朝：コメント4"),
		new CharaCommentData(CharacterType.HALNAUMY,CommentType.NOON,"ハルノウミ:昼：コメント"),
		new CharaCommentData(CharacterType.HALNAUMY,CommentType.THE_EVENING,"ハルノウミ:夕：コメント"),
		new CharaCommentData(CharacterType.HALNAUMY,CommentType.NIGHT,"ハルノウミ:夜：コメント"),
		new CharaCommentData(CharacterType.HALNAUMY,CommentType.LATE_NIGHT,"ハルノウミ:深夜：コメント"),
		new CharaCommentData(CharacterType.HALNAUMY,CommentType.TIMER,"ハルノウミ:再生中コメント"),
		new CharaCommentData(CharacterType.HALNAUMY,CommentType.COMMON,"ハルノウミ:汎用コメント"),
		new CharaCommentData(CharacterType.HALNAUMY,CommentType.TIMER_SUCCESS,"ハルノウミ:タイマー成功時コメント"),
		new CharaCommentData(CharacterType.HALNAUMY,CommentType.TIMER_FAILURE,"ハルノウミ:タイマー失敗時コメント"),
		new CharaCommentData(CharacterType.HALNAUMY,CommentType.LEAVING,"ハルノウミ:放置時コメント"),
		new CharaCommentData(CharacterType.HALNAUMY,CommentType.TAPPED,"ハルノウミ:タップ時コメント"),

		//----------------------------------
	};
	/// <summary>
	/// キャラクターのファッションデータ
	/// </summary>
	public static List<CharaFashionData> CharaFashionDataList = new List<CharaFashionData> () {
		new CharaFashionData (CharacterType.MNOINE, 0, "通常着"),
		new CharaFashionData (CharacterType.MNOINE, 1, "ラフ"),
		//---------------------------------------------------
		new CharaFashionData (CharacterType.AINE, 0, "通常着"),
		new CharaFashionData (CharacterType.AINE, 1, "ラフ"),
		//---------------------------------------------------
		new CharaFashionData (CharacterType.CANNON, 0, "通常着"),
		new CharaFashionData (CharacterType.CANNON, 1, "ラフ"),
		//---------------------------------------------------
		new CharaFashionData (CharacterType.PLIMMAVAERHA, 0, "通常着"),
		new CharaFashionData (CharacterType.PLIMMAVAERHA, 1, "ラフ"),
		//---------------------------------------------------
		new CharaFashionData (CharacterType.LIEUNNE, 0, "通常着"),
		new CharaFashionData (CharacterType.LIEUNNE, 1, "ラフ"),
		//---------------------------------------------------
		new CharaFashionData (CharacterType.JEMENOPPEEDY, 0, "通常着"),
		new CharaFashionData (CharacterType.JEMENOPPEEDY, 1, "ラフ"),
		//---------------------------------------------------
		new CharaFashionData (CharacterType.HALNAUMY, 0, "通常着"),
		new CharaFashionData (CharacterType.HALNAUMY, 1, "ラフ"),
		//---------------------------------------------------
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
