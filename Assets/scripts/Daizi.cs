using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daizi : MonoBehaviour {
	public GameObject seed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
	public void topple(){
		Instantiate (seed,transform.position,transform.rotation);
	}
}
