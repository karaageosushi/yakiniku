using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class BGLoader : MonoBehaviour {

	[SerializeField]
	List<Texture> mBgTex;
	[SerializeField]
	RawImage image;

	public void SetBgTexture(string bgName){
		image.texture = mBgTex.Where (t => t.name == bgName).FirstOrDefault ();
	}

	// Use this for initialization
	void Start () {
		
	}
}
