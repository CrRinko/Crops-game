using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowText : MonoBehaviour {
	public Text intro;
	public Color highlight;
	public GameObject MsgWindows;
	public string details;
	private Color origin;
	// Use this for initialization
	void Start () {
		origin = gameObject.GetComponent<TextMesh> ().color;
	}
	
	void OnMouseEnter(){
		intro.enabled = true;
		gameObject.GetComponent<TextMesh> ().color = highlight;
	}
	void OnMouseExit(){
		intro.enabled = false;
		gameObject.GetComponent<TextMesh> ().color = origin;
	}
	void OnMouseDown(){
		MsgWindows.GetComponent<Msg> ().SetIntro (details);
		MsgWindows.GetComponent<Msg> ().Sign = gameObject.name;
		MsgWindows.SetActive (true);
		/*
		switch (gameObject.name) {
		case "xigua":
			SceneManager.LoadScene ("game");
			break;
		default:
			break;
		}
		*/
	}
}
