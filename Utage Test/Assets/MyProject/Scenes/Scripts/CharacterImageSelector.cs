using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterImageSelector : MonoBehaviour {

	[SerializeField]
	List<Image>CharacterImages;

	public void ShowCharactor(CharacterType type){
		CharacterImages.ForEach (c=>c.gameObject.SetActive(false));
		CharacterImages [(int)type].gameObject.SetActive (true);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
