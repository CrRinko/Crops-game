using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCamera : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float hor = Input.GetAxis ("Horizontal") * speed*Time.deltaTime;
		float ver = Input.GetAxis ("Vertical") * speed * Time.deltaTime;
		gameObject.transform.Translate (new Vector3 (hor, 0, ver));
		float eulerY = 0;
		if (Input.GetKey (KeyCode.Q)) {
			eulerY = -speed * Time.deltaTime;
		} else if (Input.GetKey (KeyCode.E)) {
			eulerY = speed * Time.deltaTime;
		}
		float eulerX = 0;
		if (Input.GetKey (KeyCode.R)) {
			eulerX = -speed * Time.deltaTime;
		} else if (Input.GetKey (KeyCode.F)) {
			eulerX = speed * Time.deltaTime;
		}
		gameObject.transform.Rotate (new Vector3 (eulerX, eulerY, 0));
	}
}
