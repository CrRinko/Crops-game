using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOver : MonoBehaviour {
	public GameObject xigua;
	public GameObject orange;
	public GameObject fish;
	// Use this for initialization
	void Start () {
		Invoke ("HighXigua", 5f);
		Invoke ("HideXihua", 6f);
		Invoke ("HighOrange", 6.05f);
		Invoke ("HideOrange", 7f);
		Invoke ("HighFish", 8.35f);
		Invoke ("HideFish", 10.02f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void HighXigua(){
		xigua.GetComponent<MeshRenderer> ().enabled = true;
	}
	void HideXihua(){
		xigua.GetComponent<MeshRenderer> ().enabled = false;
	}
	void HighOrange(){
		orange.GetComponent<MeshRenderer> ().enabled = true;
	}
	void HideOrange(){
		orange.GetComponent<MeshRenderer> ().enabled = false;
	}
	void HighFish(){
		fish.GetComponent<MeshRenderer> ().enabled = true;
	}
	void HideFish(){
		fish.GetComponent<MeshRenderer> ().enabled = false;
	}
}
