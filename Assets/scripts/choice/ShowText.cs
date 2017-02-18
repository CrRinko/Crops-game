using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowText : MonoBehaviour {
	public Text intro;
	public Color highlight;
	private Color origin;
	// Use this for initialization
	void Start () {
		origin = gameObject.GetComponent<TextMesh> ().color;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseEnter(){
		print ("Enter!");
		intro.enabled = true;
		gameObject.GetComponent<TextMesh> ().color = highlight;
	}
	void OnMouseExit(){
		print("Exit!");
		intro.enabled = false;
		gameObject.GetComponent<TextMesh> ().color = origin;
	}
	void OnMouseDown(){
		switch (gameObject.name) {
		case "xigua":
			SceneManager.LoadScene ("main");
			break;
		default:
			break;
		}
	}
}
