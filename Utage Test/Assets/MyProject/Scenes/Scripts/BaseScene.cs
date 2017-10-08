using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class BaseScene : MonoBehaviour {

	RectTransform mRect;
	Action mOpenCallback = () => {
	}; 
	Action mCloseCallback = () => {
	}; 

	public void Open(Action openCallback = null){
		Debug.Log ("Open:"+this.gameObject.name);
		this.gameObject.SetActive(true);
		if (openCallback != null) {
			mOpenCallback = openCallback;
		}
		mRect.DOLocalMove (
			new Vector3(0,0),//
			1.0f //
		).OnComplete(()=>{
			Debug.Log ("OnCompleteOpen:"+this.gameObject.name);
			mOpenCallback();
		}).SetEase(Ease.InOutQuad);
	}

	public void Close(Action closeCallBack = null){
		if (closeCallBack != null) {
			mCloseCallback = closeCallBack;
		}
		mRect.DOLocalMove (
			new Vector3(-1000,0),//
			1.0f //
		).OnComplete(()=>{
			Debug.Log ("OnCompleteClose:"+this.gameObject.name);
			mCloseCallback();
		}).SetEase(Ease.InOutQuad);
	}

	public virtual void Close(){
		Close (null);
	}
	public virtual void Open(){
		Open (null);
	}

	protected virtual void Awake () {
		mRect = this.GetComponent<RectTransform> ();
	}
}
