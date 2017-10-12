using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EpisodeItem : MonoBehaviour {

	[SerializeField]
	Text mTitle;
	CharaEpisodeData mCharaEpisodeData;

	public void Init(CharaEpisodeData data){
		mCharaEpisodeData = data;
		mTitle.text = data.mTitle;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
