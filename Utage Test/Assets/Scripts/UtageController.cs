using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utage;
using UnityEngine.SceneManagement;

public class UtageController : MonoBehaviour {

	AdvEngine Engine { get { return engine ?? (engine = FindObjectOfType<AdvEngine>()); } }
	public AdvEngine engine;
	[SerializeField]
	string mDebugStartScenario="";
	//UserData mUserData = SaveData.LoadUserData();
	//public string scenarioLabel;

	// Use this for initialization
	void Start () {
		StartCoroutine(CoTalk());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator CoTalk()
	{

		string scenario = mDebugStartScenario == "" ? SaveData.LoadUserData ().mSelectedADVScenarioName : mDebugStartScenario;
		//「宴」のシナリオを呼び出す
		Engine.JumpScenario(scenario);

		//「宴」のシナリオ終了待ち
		while (!Engine.IsEndScenario)
		{
			yield return 0;
		}

        //シナリオが終わったらメイン画面に戻る
        SceneManager.LoadScene("MainScene");

	}
}
