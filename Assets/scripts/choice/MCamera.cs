using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCamera : MonoBehaviour {
	public float speed;
	private bool isCollision=false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float hor = Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
		float ver = Input.GetAxis ("Vertical") * speed * Time.deltaTime;

		float eulerY = 0;
		if (Input.GetKey (KeyCode.Q)) {
			eulerY = -speed * Time.deltaTime;
		} else if (Input.GetKey (KeyCode.E)) {
			eulerY = speed * Time.deltaTime;
		}
		gameObject.transform.Rotate (new Vector3 (0, eulerY, 0));
		float hight = 0;
		if (Input.GetKey (KeyCode.F)) {
			hight = -speed * Time.deltaTime;
		} else if (Input.GetKey (KeyCode.R)) {
			hight = speed * Time.deltaTime;
		}
		gameObject.transform.Translate (new Vector3 (hor, hight, ver));
	}
	void OnCollisionEnter(Collision collisionInfo){
		isCollision = true;
	}
	void OnCollisionExit(Collision collisionInfo){
		isCollision = false;
	}

}
