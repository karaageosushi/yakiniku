using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    //宴シーンに渡すシナリオのラベル。初期カノン１話。
    public static string LABEL = "cannon1";

    string chara = "cannon";
    string number = "1";

    public GameObject textInfo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        textInfo.GetComponent<Text>().text = chara + "  の  " + number + "話";
	}


    public void PushToUtage(){

        LABEL = chara + number;

        SceneManager.LoadScene("Utage");
    }

    public void PushCannon(){
        chara = "cannon";
    }
	public void PushNeun()
	{
		chara = "neun";
	}
	public void PushEine()
	{
		chara = "eine";
	}
	public void PushPrimavera()
	{
		chara = "primavera";
	}
	public void PushGymnopedie()
	{
		chara = "gymnopedie";
	}
	public void PushLune()
	{
		chara = "lune";
	}
	public void PushHarunoumi()
	{
		chara = "harunoumi";
	}


    public void PushButton1(){
        number = "1";
    }
	public void PushButton2()
	{
        number = "2";
	}
	public void PushButton3()
	{
		number = "3";
	}
	public void PushButton4()
	{
		number = "4";
	}
	public void PushButton5()
	{
		number = "5";
	}
	public void PushButton6()
	{
		number = "6";
	}
	public void PushButtonEx1()
	{
		number = "Ex1";
	}
}
