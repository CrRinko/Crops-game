using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutUS : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnBackBtnClick(){
		gameObject.SetActive (false);
	}
	public void OnShowBtnClick(){
		gameObject.SetActive (true);
	}
}
