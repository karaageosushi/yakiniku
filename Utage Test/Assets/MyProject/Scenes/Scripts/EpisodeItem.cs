using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
	EpisodeSelectDialog mParentDialog;

	public void Init(CharaEpisodeData data,EpisodeSelectDialog parentDialog){
		mParentDialog = parentDialog;
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
			var userData = GameSystemManager.Instance.UserData;
			userData.mCurrentSelectedADVCharacter = mCharaEpisodeData.mChara;
			userData.mSelectedADVStoryNumber = mCharaEpisodeData.mTitleNumber;
			userData.mSelectedADVScenarioName = mCharaEpisodeData.mChara.ToString().ToLower()+mCharaEpisodeData.mTitleNumber;
			//データのセーブ
			SaveData.SaveUserData ();
			//シーン遷移を行う
			SceneManager.LoadScene(GameMasterData.ADV_SCENE_NAME);

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
			//dialog.mRejectAwakeClose = true;
			dialog.Init(mCharaEpisodeData,this,()=>{
				mParentDialog.UpdateList();
			});
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
