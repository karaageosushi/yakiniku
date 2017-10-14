using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EpisodeItem : MonoBehaviour {

	[SerializeField]
	Text mTitle;
	CharaEpisodeData mCharaEpisodeData;
	[SerializeField]
	Button mButton;
	[SerializeField]
	GameObject mReleasePossibleIndicationDisplay;
	[SerializeField]
	GameObject mNonReleaseIndicationDisplay;
	[SerializeField]
	EpsodeReleaseDialog mEpsodeReleaseDialogPrefab;

	public void Init(CharaEpisodeData data){

		mCharaEpisodeData = data;
		mTitle.text = data.mTitle;
		SetReleasedDisPlay ();

	}

	public void SetReleasedDisPlay(){
		mReleasePossibleIndicationDisplay.SetActive (false);
		mNonReleaseIndicationDisplay.SetActive (false);
		mButton.onClick.RemoveAllListeners ();
		mButton.onClick.AddListener (()=>{
			//通常選択時の処理を記載
			Debug.Log("シナリオ購読画面へ繊維します！");
		});
	}

	/// <summary>
	/// 解放されていないが解放可能な状態でタップした場合
	/// </summary>
	public void SetReleasePossibleIndicationDisplay(){
		mButton.onClick.RemoveAllListeners ();
		mReleasePossibleIndicationDisplay.SetActive (true);
		mButton.onClick.AddListener (()=>{
			//解放されていないが解放可能な状態でタップした場合の処理を記載
			var dialog = PrefabFolder.InstantiateTo<EpsodeReleaseDialog>(mEpsodeReleaseDialogPrefab,GameSystemManager.Instance.DialogEmmiter);
			dialog.Init(mCharaEpisodeData,this);
		});
	}

	/// <summary>
	/// 解放されていない状態でタップした場合
	/// </summary>
	public void SetNonReleaseIndicationDisplay(){
		mButton.onClick.RemoveAllListeners ();
		mNonReleaseIndicationDisplay.SetActive (true);
		mButton.onClick.AddListener (()=>{
			//解放されていない状態でタップした場合の処理を記載
		});
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
