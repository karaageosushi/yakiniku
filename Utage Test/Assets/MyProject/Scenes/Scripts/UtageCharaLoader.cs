using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utage;

public class UtageCharaLoader : MonoBehaviour {

	//[SerializeField]
	//AdvUguiLoadGraphicFile mAdvUguiLoadGraphicFile;
	//[SerializeField]
	//AdvGraphicLoader mAdvGraphicLoader;
	[SerializeField]
	DicingTextures mDicingTextures;
	[SerializeField]
	DicingImage mDicingImage;

	// Use this for initialization
	void Start () {

		mDicingImage.DicingData = mDicingTextures;
		string pattern = "CANNON_0_4";
		mDicingImage.ChangePattern(pattern);
		/*
		var data = new AdvGraphicInfo(AdvGraphicInfo.TypeCapture, name, AdvGraphicInfo.FileType2D);
		//data.FileType = AdvGraphicInfo.FileTypeDicing;
		//data.SubFileName = "CANNON_0_0";
		mAdvUguiLoadGraphicFile.LoadFile (data);
		mAdvGraphicLoader.LoadGraphic(data, () =>
			{

				//DicingImage dicingImage = ChangeGraphicComponent<DicingImage>();
				//dicingImage.DicingData = mDicingTextures;
				//string pattern = data.SubFileName;
				//dicingImage.ChangePattern(pattern);
				//InitSize(new Vector2(dicingImage.PatternData.Width, dicingImage.PatternData.Height));
			});
		*/
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
