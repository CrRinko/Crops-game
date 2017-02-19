using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveManager : MonoBehaviour {
	public Camera player;
	public float distance = 5f;
	void OnEnable () {
		print ("OnEnable");
		Rigidbody obj = gameObject.GetComponent<Rigidbody>();
		if (obj != null) {
			obj.isKinematic = true;
		}
	}
	
	void Update () {
		gameObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0,0,distance));
		gameObject.transform.LookAt (player.transform);
	}

	void OnDisable(){
		print ("OnDisable");
		Rigidbody obj = gameObject.GetComponent<Rigidbody>();
		if (obj != null) {
			obj.isKinematic = false;
		}
	}
	public Camera Player{
		set{ 
			player = value;
		}
	}
	public float Distance{
		set{ 
			distance = value;
		}
	}
}
