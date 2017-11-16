using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BackGroundCategory{
	SKY =0,
	CHURCH=1,
	ROOM = 2,
}
public enum BackGroundTimeCategory{
	MORNING =0,
	EVENING=1,
	NIGHT = 2,
}

public struct BonusData{
	public int mId;
	public string mTitle;
	public string mConditionText;
	public bool mWithRewards;

	public BonusData(int id,string title,string conditiontext,bool withRewards){
		mId = id;
		mTitle = title;
		mConditionText = conditiontext;
		mWithRewards = withRewards;
	}
}

public class GameMasterData  {

	public static List<BonusData> BonusDataList = new List<BonusData> () {
		new BonusData(1,"ボーナスタイトル１","ボーナス獲得条件",false),
		new BonusData(2,"ボーナスタイトル１","ボーナス獲得条件",false),
		new BonusData(3,"ボーナスタイトル１","ボーナス獲得条件",true),
		new BonusData(4,"ボーナスタイトル１","ボーナス獲得条件",false),
		new BonusData(5,"ボーナスタイトル１","ボーナス獲得条件",false),
	};
}
