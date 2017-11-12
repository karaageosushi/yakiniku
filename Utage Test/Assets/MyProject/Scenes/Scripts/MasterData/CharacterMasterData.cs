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
public struct CharaPostionData{
	public CharacterType mChara;
	public Vector2 mPostion;

	public CharaPostionData(
		CharacterType chara,
		Vector2 postion
	){
		mChara = chara;
		mPostion = postion;
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

		new CharaCommentData(CharacterType.CANNON,CommentType.COMMON,"おかえり、指揮者\nさあ、第一楽章をはじめようか"),
		new CharaCommentData(CharacterType.CANNON,CommentType.COMMON,"君の声が聞こえたよ\nまた素敵な音を聞かせてくれるかい"),
		new CharaCommentData(CharacterType.CANNON,CommentType.COMMON,"また会えたね\n君と過ごせる時間が楽しみだよ"),
		new CharaCommentData(CharacterType.CANNON,CommentType.COMMON,"ふふっ…ちょうど\n君のマネをしていたところさ"),
		new CharaCommentData(CharacterType.CANNON,CommentType.COMMON,"その指先でまた奏でてほしい\n指揮してくれるかい？"),
		new CharaCommentData(CharacterType.CANNON,CommentType.COMMON,"僕は君が来るのを待っている\nそして今日、夢がかなったのかな"),
		new CharaCommentData(CharacterType.CANNON,CommentType.COMMON,"忙しくても来てくれる\nそんな指揮者が好きだよ"),
		new CharaCommentData(CharacterType.CANNON,CommentType.COMMON,"今日も指揮者の話を聞かせて\n君の世界を知りたいんだ"),
		new CharaCommentData(CharacterType.CANNON,CommentType.COMMON,"そろそろ世界に旋律を\n届けてみないかい？"),
		new CharaCommentData(CharacterType.CANNON,CommentType.COMMON,"曲は満ちている\nあとは君だけが必要さ"),
		new CharaCommentData(CharacterType.CANNON,CommentType.MORNING,"おはよう\nよく眠れたって顔だね？"),
		new CharaCommentData(CharacterType.CANNON,CommentType.MORNING,"僕の朝は早いんだ\n朝の音がいつも聞きたくて"),
		new CharaCommentData(CharacterType.CANNON,CommentType.MORNING,"ちょうど僕も起きたところさ\n君とは生活のテンポが合うね"),
		new CharaCommentData(CharacterType.CANNON,CommentType.MORNING,"ふわぁ～あ...あれ、マネしてた\nつもりが本当にうつったみたいだね"),
		new CharaCommentData(CharacterType.CANNON,CommentType.MORNING,"今朝は素敵な朝だね\nこんな世界でも明るく見えるよ"),
		new CharaCommentData(CharacterType.CANNON,CommentType.NOON,"こんにちは、来てくれたのかい？\n話したいことがあったんだ"),
		new CharaCommentData(CharacterType.CANNON,CommentType.NOON,"指揮者の旋律を感じたから\n会いに来たよ。迷惑だったかな？"),
		new CharaCommentData(CharacterType.CANNON,CommentType.NOON,"この時間帯は音の力を\nおおく感じるんだ"),
		new CharaCommentData(CharacterType.CANNON,CommentType.NOON,"太陽が出ているね、指揮者\n一緒に外へでかけないかい？"),
		new CharaCommentData(CharacterType.CANNON,CommentType.NOON,"安らぎの時間だね\n心に余裕が生まれていくよ"),
		new CharaCommentData(CharacterType.CANNON,CommentType.THE_EVENING,"夕方だね\n切なさが満ちる楽章だ"),
		new CharaCommentData(CharacterType.CANNON,CommentType.THE_EVENING,"もうこんな時間なんだね\n君と過ごす時間はあっという間さ"),
		new CharaCommentData(CharacterType.CANNON,CommentType.THE_EVENING,"１日で最も繊細な時間\n今あう曲はなんだろうね"),
		new CharaCommentData(CharacterType.CANNON,CommentType.THE_EVENING,"ふふっ、これは驚いた君のマネさ\nしばらく時を忘れてたみたいだから"),
		new CharaCommentData(CharacterType.CANNON,CommentType.THE_EVENING,"指揮者の曲を聞かせてくれるかい\n君の影響を受けたいんだ"),
		new CharaCommentData(CharacterType.CANNON,CommentType.NIGHT,"もう暗いね\n今夜は静かな曲が合うよ"),
		new CharaCommentData(CharacterType.CANNON,CommentType.NIGHT,"今夜の星にあう曲を探してる\n君の意見を聞かせてほしいな"),
		new CharaCommentData(CharacterType.CANNON,CommentType.NIGHT,"こんばんは、指揮者\n今日も僕を指揮してくれるかい？"),
		new CharaCommentData(CharacterType.CANNON,CommentType.NIGHT,"今夜は良い夜だね\n優しい曲が似合うね"),
		new CharaCommentData(CharacterType.CANNON,CommentType.NIGHT,"暗い空を見ていると\n君の瞳を思い出すよ、指揮者"),
		new CharaCommentData(CharacterType.CANNON,CommentType.LATE_NIGHT,"おやすみ\n明日の曲が楽しみだよ"),
		new CharaCommentData(CharacterType.CANNON,CommentType.LATE_NIGHT,"まだ起きているのかい？\n君は本当に頑張り屋さんだね"),
		new CharaCommentData(CharacterType.CANNON,CommentType.LATE_NIGHT,"眠れないのかい？\n僕も指揮者の旋律を感じてね"),
		new CharaCommentData(CharacterType.CANNON,CommentType.LATE_NIGHT,"世界が静寂に包まれてるね\n君とふたりきりみたいだ"),
		new CharaCommentData(CharacterType.CANNON,CommentType.LATE_NIGHT,"眠る前に君の声が聞けてよかった\n素敵な夢が奏でられそうだよ"),
		new CharaCommentData(CharacterType.CANNON,CommentType.TIMER,"耳をすまして\n僕が指揮者の疲れを癒してあげる"),
		new CharaCommentData(CharacterType.CANNON,CommentType.TIMER,"さみしくなったのかい？\n頑張ろう、もうちょっとの辛抱さ"),
		new CharaCommentData(CharacterType.CANNON,CommentType.TIMER,"頑張ってる？...うん\nその様子なら心配ないみたいだね"),
		new CharaCommentData(CharacterType.CANNON,CommentType.TIMER,"熱心な指揮者のために\n僕を奏でよう"),
		new CharaCommentData(CharacterType.CANNON,CommentType.TIMER,"美しい曲だね\n曲の変化に心が動かされる"),
		new CharaCommentData(CharacterType.CANNON,CommentType.TIMER,"第一楽章ははじまっているよ\n指揮者、頑張ってね"),
		new CharaCommentData(CharacterType.CANNON,CommentType.TIMER,"僕と一緒に頑張ろう？"),
		new CharaCommentData(CharacterType.CANNON,CommentType.TIMER,"大丈夫、君ならできるさ\n僕にそれを見せて"),
		new CharaCommentData(CharacterType.CANNON,CommentType.TIMER,"指揮者が成長すれば成長するほど\n音楽は完成されていくんだよ"),
		new CharaCommentData(CharacterType.CANNON,CommentType.TIMER,"..ふふ、これは指揮者のマネさ\n頑張る君はこんな顔をしているよ"),

		new CharaCommentData(CharacterType.CANNON,CommentType.TIMER_SUCCESS,"お疲れ様、指揮者。\n僕は君の力になれたかい？"),
		new CharaCommentData(CharacterType.CANNON,CommentType.TIMER_SUCCESS,"すごいね、指揮者\nもう時間だよ、ふふっ"),
		new CharaCommentData(CharacterType.CANNON,CommentType.TIMER_SUCCESS,"お疲れさま、楽しかったかい？\n僕は君の笑顔が見れて幸せさ"),
		new CharaCommentData(CharacterType.CANNON,CommentType.TIMER_SUCCESS,"素敵な時間だったね\nなによりも繊細で尊い瞬間だ"),
		new CharaCommentData(CharacterType.CANNON,CommentType.TIMER_SUCCESS,"ありがとう、最高だったよ\n君はどうだったかな？"),

		new CharaCommentData(CharacterType.CANNON,CommentType.TIMER_FAILURE,"ふふ、せっかちだね\nでもこういう曲もいいと思うよ"),
		new CharaCommentData(CharacterType.CANNON,CommentType.TIMER_FAILURE,"次はもっといい曲になるはずさ\nだから落ち込まないで。ね？"),
		new CharaCommentData(CharacterType.CANNON,CommentType.TIMER_FAILURE,"今日は此の旋律じゃ\nなかったみたいだね"),
		new CharaCommentData(CharacterType.CANNON,CommentType.TIMER_FAILURE,"お疲れさま\n気にしなくていいよ、次はあるから"),
		new CharaCommentData(CharacterType.CANNON,CommentType.TIMER_FAILURE,"気にすることはない。\n僕は君のために奏でられればいい"),

		new CharaCommentData(CharacterType.CANNON,CommentType.LEAVING,"静寂もひとつの音楽\n僕はこの曲も嫌いじゃないよ"),
		new CharaCommentData(CharacterType.CANNON,CommentType.LEAVING,"どうしたのかな？\n忘れちゃったのかい？"),
		new CharaCommentData(CharacterType.CANNON,CommentType.LEAVING,"君の旋律が聞こえない\nちょっと寂しいね"),
		new CharaCommentData(CharacterType.CANNON,CommentType.LEAVING,"君という鍵を失った世界は\nどんな音楽よりも味気ないよ..."),
		new CharaCommentData(CharacterType.CANNON,CommentType.LEAVING,"灰色で単調な音階\nあまり好きではないね"),

		new CharaCommentData(CharacterType.CANNON,CommentType.TAPPED,"なにかな？"),
		new CharaCommentData(CharacterType.CANNON,CommentType.TAPPED,"指先から君の気持ちがわかるよ"),
		new CharaCommentData(CharacterType.CANNON,CommentType.TAPPED,"僕はカノン。なにか用かな？"),
		new CharaCommentData(CharacterType.CANNON,CommentType.TAPPED,"くすぐったいね、ふふ"),
		new CharaCommentData(CharacterType.CANNON,CommentType.TAPPED,"君が楽しそうだと僕も楽しいよ"),
		new CharaCommentData(CharacterType.CANNON,CommentType.TAPPED,"ん？甘えたいの？"),
		new CharaCommentData(CharacterType.CANNON,CommentType.TAPPED,"曲が満ちていく..."),
		new CharaCommentData(CharacterType.CANNON,CommentType.TAPPED,"君の旋律が聞きたいな"),
		new CharaCommentData(CharacterType.CANNON,CommentType.TAPPED,"はい、タッチ。君のマネさ"),
		new CharaCommentData(CharacterType.CANNON,CommentType.TAPPED,"大丈夫、僕はここにいるよ"),

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
	/// TOPでのキャラクターの座標指定データ
	/// </summary>
	public static List<CharaPostionData> CharaTopPostionList = new List<CharaPostionData> () {
		new CharaPostionData (CharacterType.MNOINE, new Vector2(-100,-168)),
		//---------------------------------------------------
		new CharaPostionData (CharacterType.AINE, new Vector2(-100,-168)),
		//---------------------------------------------------
		new CharaPostionData (CharacterType.CANNON, new Vector2(-9.14f,-153.5f)),
		//---------------------------------------------------
		new CharaPostionData (CharacterType.PLIMMAVAERHA, new Vector2(-100,-168)),
		//---------------------------------------------------
		new CharaPostionData (CharacterType.LIEUNNE, new Vector2(-55,-267.4f)),
		//---------------------------------------------------
		new CharaPostionData (CharacterType.JEMENOPPEEDY, new Vector2(38.1f,-254.2f)),
		//---------------------------------------------------
		new CharaPostionData (CharacterType.HALNAUMY, new Vector2(-70,-168)),
		//---------------------------------------------------
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
