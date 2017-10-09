using UnityEngine;
using System.Runtime.InteropServices;

public class AudioSetter:MonoBehaviour {

	[DllImport("__Internal")]
	private static extern void _SetiOSBackGroundAudio ();
	/// <summary>
	/// iOSの音楽がバックグラウンドでも鳴るようにする
	/// </summary>

	void Awake(){
		if (Application.platform != RuntimePlatform.OSXEditor) {
			_SetiOSBackGroundAudio();
		}
	}
}
