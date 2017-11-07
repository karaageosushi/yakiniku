using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;


public class DialogBase : MonoBehaviour {
	RectTransform mRect;
	protected Action mOpenCallback = () => {
	}; 
	protected Action mCloseCallback = () => {
	}; 

	public void Open(Action openCallback = null){
		Debug.Log ("Open:"+this.gameObject.name);
		mRect.transform.localPosition = new Vector3 (0,0);
		this.gameObject.SetActive(true);
		if (openCallback != null) {
			mOpenCallback = openCallback;
		}
		mRect.DOScale (
			new Vector3(1,1),//
			0.5f //
		).OnComplete(()=>{
			Debug.Log ("OnCompleteOpen:"+this.gameObject.name);
			mOpenCallback();
		}).SetEase(Ease.InOutQuad);
	}

	public void Close(Action closeCallBack = null){
		if (closeCallBack != null) {
			mCloseCallback = closeCallBack;
		}
		mRect.DOScale (
			new Vector3(0,0),//
			0.5f //
		).OnComplete(()=>{
			Debug.Log ("OnCompleteClose:"+this.gameObject.name);
			mCloseCallback();
		}).SetEase(Ease.InOutQuad);
	}

	public void Close(){
		Close (null);
	}
	public void Open(){
		Open (null);
	}



	protected virtual void Awake () {
		mRect = this.GetComponent<RectTransform> ();
		Close ();
	}


}
