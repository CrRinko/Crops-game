using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Msg : MonoBehaviour {
	// Use this for initialization
	public Text Intro;
	private string sign="";
	void Start () {
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetIntro(string intro){
		Intro.text = intro;
	}
	public string Sign{
		set{ 
			sign = value;
		}
	}
	public void OnBackBtnClick(){
		gameObject.SetActive (false);
	}
	public void OnEnterBtnClick(){
		switch (sign) {
		case "watermelon":
			SceneManager.LoadScene ("game");
			break;
		case "orange":
			break;
		case "fish":
			break;
		default:
			gameObject.SetActive (false);
			break;
		}
	}
}
