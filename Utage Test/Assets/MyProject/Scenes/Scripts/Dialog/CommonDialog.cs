using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CommonDialog : DialogBase {
	[SerializeField]
	Text mBody;

	public void Init(string message,Action closeCallBack = null){
		mBody.text = message;
		mCloseCallback = () => {
			Destroy(this.gameObject);
			if(closeCallBack != null){
				closeCallBack();
			}
		};
	}

	public void OnNoButton(){
		Close ();
	}
}
