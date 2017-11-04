using UnityEngine;
using System.Runtime.InteropServices;

public class AudioSetter:MonoBehaviour {

	[DllImport("__Internal")]
	private static extern void _SetiOSBackGroundAudio ();
	[DllImport("__Internal")]
	private static extern void _GotoBackGround ();
	[DllImport("__Internal")]
	private static extern void _ReturnBackGround ();
	[DllImport("__Internal")]
	private static extern void _ReSetiOSBackGroundAudio ();
	/// <summary>
	/// iOSの音楽がバックグラウンドでも鳴るようにする
	/// </summary>

	void Awake(){
		if (Application.platform != RuntimePlatform.OSXEditor) {
			_SetiOSBackGroundAudio();
		}
	}
	private void OnApplicationFocus( bool hasFocus )
	{
		Debug.Log("OnApplicationFocus:" + hasFocus);
		if(hasFocus){
			_ReSetiOSBackGroundAudio ();
		}
	}

	void OnApplicationPause (bool pauseStatus)
	{
		if (pauseStatus) {
			Debug.Log("applicationWillResignActive or onPause");
			//_GotoBackGround ();
		} else {
			Debug.Log("applicationDidBecomeActive or onResume");
			//_ReturnBackGround ();
		}
	}
	/*
	public void StopBGM(){
		Application.Restart();
	}
*/
	private void OnApplicationQuit() {
		Debug.Log("OnApplicationQuit");
	}

	//サスペンド
	private void OnSuspend()
	{
		Debug.Log ("OnSuspend");
		//_GotoBackGround();
	}
	//レジューム
	private void OnResume()
	{
		Debug.Log ("OnResume");
		//_ReturnBackGround();
	}
}
