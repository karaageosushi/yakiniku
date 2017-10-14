using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetRewordDialog : DialogBase {

	[SerializeField]
	Text mRewordNum;

	public void Init(int num){
		mRewordNum.text = "+" + num;
		this.Open ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
