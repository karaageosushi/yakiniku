﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utage;


public class GameManager : MonoBehaviour {

	AdvEngine Engine { get { return engine ?? (engine = FindObjectOfType<AdvEngine>()); } }
	public AdvEngine engine;
	public string scenarioLabel;



    public void PushButtonToUtage(){
        Debug.Log("ボタンがおされました");

        StartCoroutine(CoTalk());

    }


	IEnumerator CoTalk()
	{
		//「宴」のシナリオを呼び出す
		Engine.JumpScenario(scenarioLabel);

		//「宴」のシナリオ終了待ち
		while (!Engine.IsEndScenario)
		{
			yield return 0;
		}
	}

}
