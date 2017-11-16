using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterType{
	NONE=0,
	NEUN=1,
	EINE=2,
	CANNON=3,
	PRIMAVERA=4,
	LUNE=5,
	GYMNOPEDIE=6,
	HARUNOUMI=7,
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
		{CharacterType.NEUN,
			new AdvCharacterInfo(
				"ノイン",
				"作曲者名が入ります",
				"曲名が入ります",
				"時代が入ります",
				"キャラ説明が入ります¥nキャラ説明が入ります¥nキャラ説明が入ります¥n")
			},
		{CharacterType.EINE,
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
		{CharacterType.PRIMAVERA,
			new AdvCharacterInfo(
				"プリマヴェーラ",
				"作曲者名が入ります",
				"曲名が入ります",
				"時代が入ります",
				"キャラ説明が入ります¥nキャラ説明が入ります¥nキャラ説明が入ります¥n")
			},
		{CharacterType.LUNE,
			new AdvCharacterInfo(
				"リュヌ",
				"作曲者名が入ります",
				"曲名が入ります",
				"時代が入ります",
				"キャラ説明が入ります¥nキャラ説明が入ります¥nキャラ説明が入ります¥n")
			},
		{CharacterType.GYMNOPEDIE,
			new AdvCharacterInfo(
				"ジムノペディ",
				"作曲者名が入ります",
				"曲名が入ります",
				"時代が入ります",
				"キャラ説明が入ります¥nキャラ説明が入ります¥nキャラ説明が入ります¥n")
			},
		{CharacterType.HARUNOUMI,
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
		new CharaCommentData(CharacterType.NEUN,CommentType.MORNING,"ノイン:朝：コメント1"),
		new CharaCommentData(CharacterType.NEUN,CommentType.MORNING,"ノイン:朝：コメント2"),
		new CharaCommentData(CharacterType.NEUN,CommentType.MORNING,"ノイン:朝：コメント3"),
		new CharaCommentData(CharacterType.NEUN,CommentType.MORNING,"ノイン:朝：コメント4"),
		new CharaCommentData(CharacterType.NEUN,CommentType.NOON,"ノイン:昼：コメント"),
		new CharaCommentData(CharacterType.NEUN,CommentType.THE_EVENING,"ノイン:夕：コメント"),
		new CharaCommentData(CharacterType.NEUN,CommentType.NIGHT,"ノイン:夜：コメント"),
		new CharaCommentData(CharacterType.NEUN,CommentType.LATE_NIGHT,"ノイン:深夜：コメント"),
		new CharaCommentData(CharacterType.NEUN,CommentType.TIMER,"ノイン:再生中コメント"),
		new CharaCommentData(CharacterType.NEUN,CommentType.COMMON,"ノイン:汎用コメント"),
		new CharaCommentData(CharacterType.NEUN,CommentType.TIMER_SUCCESS,"ノイン:タイマー成功時コメント"),
		new CharaCommentData(CharacterType.NEUN,CommentType.TIMER_FAILURE,"ノイン:タイマー失敗時コメント"),
		new CharaCommentData(CharacterType.NEUN,CommentType.LEAVING,"ノイン:放置時コメント"),
		new CharaCommentData(CharacterType.NEUN,CommentType.TAPPED,"ノイン:タップ時コメント"),

		//----------------------------------
		new CharaCommentData(CharacterType.EINE,CommentType.MORNING,"アイネ:朝：コメント1"),
		new CharaCommentData(CharacterType.EINE,CommentType.MORNING,"アイネ:朝：コメント2"),
		new CharaCommentData(CharacterType.EINE,CommentType.MORNING,"アイネ:朝：コメント3"),
		new CharaCommentData(CharacterType.EINE,CommentType.MORNING,"アイネ:朝：コメント4"),
		new CharaCommentData(CharacterType.EINE,CommentType.NOON,"アイネ:昼：コメント"),
		new CharaCommentData(CharacterType.EINE,CommentType.THE_EVENING,"アイネ:夕：コメント"),
		new CharaCommentData(CharacterType.EINE,CommentType.NIGHT,"アイネ:夜：コメント"),
		new CharaCommentData(CharacterType.EINE,CommentType.LATE_NIGHT,"アイネ:深夜：コメント"),
		new CharaCommentData(CharacterType.EINE,CommentType.TIMER,"アイネ:再生中コメント"),
		new CharaCommentData(CharacterType.EINE,CommentType.COMMON,"アイネ:汎用コメント"),
		new CharaCommentData(CharacterType.EINE,CommentType.TIMER_SUCCESS,"アイネ:タイマー成功時コメント"),
		new CharaCommentData(CharacterType.EINE,CommentType.TIMER_FAILURE,"アイネ:タイマー失敗時コメント"),
		new CharaCommentData(CharacterType.EINE,CommentType.LEAVING,"アイネ:放置時コメント"),
		new CharaCommentData(CharacterType.EINE,CommentType.TAPPED,"アイネ:タップ時コメント"),

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
		new CharaCommentData(CharacterType.PRIMAVERA,CommentType.MORNING,"プリマヴェーラ:朝：コメント1"),
		new CharaCommentData(CharacterType.PRIMAVERA,CommentType.MORNING,"プリマヴェーラ:朝：コメント2"),
		new CharaCommentData(CharacterType.PRIMAVERA,CommentType.MORNING,"プリマヴェーラ:朝：コメント3"),
		new CharaCommentData(CharacterType.PRIMAVERA,CommentType.MORNING,"プリマヴェーラ:朝：コメント4"),
		new CharaCommentData(CharacterType.PRIMAVERA,CommentType.NOON,"プリマヴェーラ:昼：コメント"),
		new CharaCommentData(CharacterType.PRIMAVERA,CommentType.THE_EVENING,"プリマヴェーラ:夕：コメント"),
		new CharaCommentData(CharacterType.PRIMAVERA,CommentType.NIGHT,"プリマヴェーラ:夜：コメント"),
		new CharaCommentData(CharacterType.PRIMAVERA,CommentType.LATE_NIGHT,"プリマヴェーラ:深夜：コメント"),
		new CharaCommentData(CharacterType.PRIMAVERA,CommentType.TIMER,"プリマヴェーラ:再生中コメント"),
		new CharaCommentData(CharacterType.PRIMAVERA,CommentType.COMMON,"プリマヴェーラ:汎用コメント"),
		new CharaCommentData(CharacterType.PRIMAVERA,CommentType.TIMER_SUCCESS,"プリマヴェーラ:タイマー成功時コメント"),
		new CharaCommentData(CharacterType.PRIMAVERA,CommentType.TIMER_FAILURE,"プリマヴェーラ:タイマー失敗時コメント"),
		new CharaCommentData(CharacterType.PRIMAVERA,CommentType.LEAVING,"プリマヴェーラ:放置時コメント"),
		new CharaCommentData(CharacterType.PRIMAVERA,CommentType.TAPPED,"プリマヴェーラ:タップ時コメント"),

		//----------------------------------
		new CharaCommentData(CharacterType.LUNE,CommentType.MORNING,"リュヌ:朝：コメント1"),
		new CharaCommentData(CharacterType.LUNE,CommentType.MORNING,"リュヌ:朝：コメント2"),
		new CharaCommentData(CharacterType.LUNE,CommentType.MORNING,"リュヌ:朝：コメント3"),
		new CharaCommentData(CharacterType.LUNE,CommentType.MORNING,"リュヌ:朝：コメント4"),
		new CharaCommentData(CharacterType.LUNE,CommentType.NOON,"リュヌ:昼：コメント"),
		new CharaCommentData(CharacterType.LUNE,CommentType.THE_EVENING,"リュヌ:夕：コメント"),
		new CharaCommentData(CharacterType.LUNE,CommentType.NIGHT,"リュヌ:夜：コメント"),
		new CharaCommentData(CharacterType.LUNE,CommentType.LATE_NIGHT,"リュヌ:深夜：コメント"),
		new CharaCommentData(CharacterType.LUNE,CommentType.TIMER,"リュヌ:再生中コメント"),
		new CharaCommentData(CharacterType.LUNE,CommentType.COMMON,"リュヌ:汎用コメント"),
		new CharaCommentData(CharacterType.LUNE,CommentType.TIMER_SUCCESS,"リュヌ:タイマー成功時コメント"),
		new CharaCommentData(CharacterType.LUNE,CommentType.TIMER_FAILURE,"リュヌ:タイマー失敗時コメント"),
		new CharaCommentData(CharacterType.LUNE,CommentType.LEAVING,"リュヌ:放置時コメント"),
		new CharaCommentData(CharacterType.LUNE,CommentType.TAPPED,"リュヌ:タップ時コメント"),

		//----------------------------------
		new CharaCommentData(CharacterType.GYMNOPEDIE,CommentType.MORNING,"ジムノペディ:朝：コメント1"),
		new CharaCommentData(CharacterType.GYMNOPEDIE,CommentType.MORNING,"ジムノペディ:朝：コメント2"),
		new CharaCommentData(CharacterType.GYMNOPEDIE,CommentType.MORNING,"ジムノペディ:朝：コメント3"),
		new CharaCommentData(CharacterType.GYMNOPEDIE,CommentType.MORNING,"ジムノペディ:朝：コメント4"),
		new CharaCommentData(CharacterType.GYMNOPEDIE,CommentType.NOON,"ジムノペディ:昼：コメント"),
		new CharaCommentData(CharacterType.GYMNOPEDIE,CommentType.THE_EVENING,"ジムノペディ:夕：コメント"),
		new CharaCommentData(CharacterType.GYMNOPEDIE,CommentType.NIGHT,"ジムノペディ:夜：コメント"),
		new CharaCommentData(CharacterType.GYMNOPEDIE,CommentType.LATE_NIGHT,"ジムノペディ:深夜：コメント"),
		new CharaCommentData(CharacterType.GYMNOPEDIE,CommentType.TIMER,"ジムノペディ:再生中コメント"),
		new CharaCommentData(CharacterType.GYMNOPEDIE,CommentType.COMMON,"ジムノペディ:汎用コメント"),
		new CharaCommentData(CharacterType.GYMNOPEDIE,CommentType.TIMER_SUCCESS,"ジムノペディ:タイマー成功時コメント"),
		new CharaCommentData(CharacterType.GYMNOPEDIE,CommentType.TIMER_FAILURE,"ジムノペディ:タイマー失敗時コメント"),
		new CharaCommentData(CharacterType.GYMNOPEDIE,CommentType.LEAVING,"ジムノペディ:放置時コメント"),
		new CharaCommentData(CharacterType.GYMNOPEDIE,CommentType.TAPPED,"ジムノペディ:タップ時コメント"),


		//----------------------------------
		new CharaCommentData(CharacterType.HARUNOUMI,CommentType.MORNING,"ハルノウミ:朝：コメント1"),
		new CharaCommentData(CharacterType.HARUNOUMI,CommentType.MORNING,"ハルノウミ:朝：コメント2"),
		new CharaCommentData(CharacterType.HARUNOUMI,CommentType.MORNING,"ハルノウミ:朝：コメント3"),
		new CharaCommentData(CharacterType.HARUNOUMI,CommentType.MORNING,"ハルノウミ:朝：コメント4"),
		new CharaCommentData(CharacterType.HARUNOUMI,CommentType.NOON,"ハルノウミ:昼：コメント"),
		new CharaCommentData(CharacterType.HARUNOUMI,CommentType.THE_EVENING,"ハルノウミ:夕：コメント"),
		new CharaCommentData(CharacterType.HARUNOUMI,CommentType.NIGHT,"ハルノウミ:夜：コメント"),
		new CharaCommentData(CharacterType.HARUNOUMI,CommentType.LATE_NIGHT,"ハルノウミ:深夜：コメント"),
		new CharaCommentData(CharacterType.HARUNOUMI,CommentType.TIMER,"ハルノウミ:再生中コメント"),
		new CharaCommentData(CharacterType.HARUNOUMI,CommentType.COMMON,"ハルノウミ:汎用コメント"),
		new CharaCommentData(CharacterType.HARUNOUMI,CommentType.TIMER_SUCCESS,"ハルノウミ:タイマー成功時コメント"),
		new CharaCommentData(CharacterType.HARUNOUMI,CommentType.TIMER_FAILURE,"ハルノウミ:タイマー失敗時コメント"),
		new CharaCommentData(CharacterType.HARUNOUMI,CommentType.LEAVING,"ハルノウミ:放置時コメント"),
		new CharaCommentData(CharacterType.HARUNOUMI,CommentType.TAPPED,"ハルノウミ:タップ時コメント"),

		//----------------------------------
	};
	/// <summary>
	/// TOPでのキャラクターの座標指定データ
	/// </summary>
	public static List<CharaPostionData> CharaTopPostionList = new List<CharaPostionData> () {
		new CharaPostionData (CharacterType.NEUN, new Vector2(-100,-168)),
		//---------------------------------------------------
		new CharaPostionData (CharacterType.EINE, new Vector2(-100,-168)),
		//---------------------------------------------------
		new CharaPostionData (CharacterType.CANNON, new Vector2(-9.14f,-153.5f)),
		//---------------------------------------------------
		new CharaPostionData (CharacterType.PRIMAVERA, new Vector2(-100,-168)),
		//---------------------------------------------------
		new CharaPostionData (CharacterType.LUNE, new Vector2(-55,-267.4f)),
		//---------------------------------------------------
		new CharaPostionData (CharacterType.GYMNOPEDIE, new Vector2(38.1f,-254.2f)),
		//---------------------------------------------------
		new CharaPostionData (CharacterType.HARUNOUMI, new Vector2(-70,-168)),
		//---------------------------------------------------
	};
	/// <summary>
	/// キャラクターのファッションデータ
	/// </summary>
	public static List<CharaFashionData> CharaFashionDataList = new List<CharaFashionData> () {
		new CharaFashionData (CharacterType.NEUN, 0, "通常着"),
		new CharaFashionData (CharacterType.NEUN, 1, "ラフ"),
		//---------------------------------------------------
		new CharaFashionData (CharacterType.EINE, 0, "通常着"),
		new CharaFashionData (CharacterType.EINE, 1, "ラフ"),
		//---------------------------------------------------
		new CharaFashionData (CharacterType.CANNON, 0, "通常着"),
		new CharaFashionData (CharacterType.CANNON, 1, "ラフ"),
		//---------------------------------------------------
		new CharaFashionData (CharacterType.PRIMAVERA, 0, "通常着"),
		new CharaFashionData (CharacterType.PRIMAVERA, 1, "ラフ"),
		//---------------------------------------------------
		new CharaFashionData (CharacterType.LUNE, 0, "通常着"),
		new CharaFashionData (CharacterType.LUNE, 1, "ラフ"),
		//---------------------------------------------------
		new CharaFashionData (CharacterType.GYMNOPEDIE, 0, "通常着"),
		new CharaFashionData (CharacterType.GYMNOPEDIE, 1, "ラフ"),
		//---------------------------------------------------
		new CharaFashionData (CharacterType.HARUNOUMI, 0, "通常着"),
		new CharaFashionData (CharacterType.HARUNOUMI, 1, "ラフ"),
		//---------------------------------------------------
	};

	//キャラクターのエピソードデータ
	public static List<CharaEpisodeData> CharaEpsodeDataList = new List<CharaEpisodeData> (){
		new CharaEpisodeData(CharacterType.NEUN,1,"無題",10),
		new CharaEpisodeData(CharacterType.NEUN,2,"無題",10),
		new CharaEpisodeData(CharacterType.NEUN,3,"無題",10),
		new CharaEpisodeData(CharacterType.NEUN,4,"無題",10),
		new CharaEpisodeData(CharacterType.NEUN,5,"無題",10),
		new CharaEpisodeData(CharacterType.NEUN,6,"無題",10),
		new CharaEpisodeData(CharacterType.NEUN,7,"着替え",10),
		//--------------------------------------------
		new CharaEpisodeData(CharacterType.EINE,1,"無題",10),
		new CharaEpisodeData(CharacterType.EINE,2,"無題",10),
		new CharaEpisodeData(CharacterType.EINE,3,"無題",10),
		new CharaEpisodeData(CharacterType.EINE,4,"無題",10),
		new CharaEpisodeData(CharacterType.EINE,5,"無題",10),
		new CharaEpisodeData(CharacterType.EINE,6,"無題",10),
		new CharaEpisodeData(CharacterType.EINE,7,"着替え",10),
		//--------------------------------------------
		new CharaEpisodeData(CharacterType.CANNON,1,"無題",10),
		new CharaEpisodeData(CharacterType.CANNON,2,"無題",10),
		new CharaEpisodeData(CharacterType.CANNON,3,"無題",10),
		new CharaEpisodeData(CharacterType.CANNON,4,"無題",10),
		new CharaEpisodeData(CharacterType.CANNON,5,"無題",10),
		new CharaEpisodeData(CharacterType.CANNON,6,"無題",10),
		new CharaEpisodeData(CharacterType.CANNON,7,"着替え",10),
		//--------------------------------------------
		new CharaEpisodeData(CharacterType.PRIMAVERA,1,"無題",10),
		new CharaEpisodeData(CharacterType.PRIMAVERA,2,"無題",10),
		new CharaEpisodeData(CharacterType.PRIMAVERA,3,"無題",10),
		new CharaEpisodeData(CharacterType.PRIMAVERA,4,"無題",10),
		new CharaEpisodeData(CharacterType.PRIMAVERA,5,"無題",10),
		new CharaEpisodeData(CharacterType.PRIMAVERA,6,"無題",10),
		new CharaEpisodeData(CharacterType.PRIMAVERA,7,"着替え",10),
		//--------------------------------------------
		new CharaEpisodeData(CharacterType.LUNE,1,"無題",10),
		new CharaEpisodeData(CharacterType.LUNE,2,"無題",10),
		new CharaEpisodeData(CharacterType.LUNE,3,"無題",10),
		new CharaEpisodeData(CharacterType.LUNE,4,"無題",10),
		new CharaEpisodeData(CharacterType.LUNE,5,"無題",10),
		new CharaEpisodeData(CharacterType.LUNE,6,"無題",10),
		new CharaEpisodeData(CharacterType.LUNE,7,"着替え",10),
		//--------------------------------------------
		new CharaEpisodeData(CharacterType.GYMNOPEDIE,1,"無題",10),
		new CharaEpisodeData(CharacterType.GYMNOPEDIE,2,"無題",10),
		new CharaEpisodeData(CharacterType.GYMNOPEDIE,3,"無題",10),
		new CharaEpisodeData(CharacterType.GYMNOPEDIE,4,"無題",10),
		new CharaEpisodeData(CharacterType.GYMNOPEDIE,5,"無題",10),
		new CharaEpisodeData(CharacterType.GYMNOPEDIE,6,"無題",10),
		new CharaEpisodeData(CharacterType.GYMNOPEDIE,7,"着替え",10),
		//--------------------------------------------
		new CharaEpisodeData(CharacterType.HARUNOUMI,1,"無題",10),
		new CharaEpisodeData(CharacterType.HARUNOUMI,2,"無題",10),
		new CharaEpisodeData(CharacterType.HARUNOUMI,3,"無題",10),
		new CharaEpisodeData(CharacterType.HARUNOUMI,4,"無題",10),
		new CharaEpisodeData(CharacterType.HARUNOUMI,5,"無題",10),
		new CharaEpisodeData(CharacterType.HARUNOUMI,6,"無題",10),
		new CharaEpisodeData(CharacterType.HARUNOUMI,7,"着替え",10),
		//--------------------------------------------
	};



}
