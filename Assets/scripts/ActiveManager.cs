using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveManager : MonoBehaviour {
	public Camera player;
	public float distance = 5f;
	void onEnable () {
		Rigidbody obj = gameObject.GetComponent<Rigidbody>();
		obj.isKinematic = true;
	}
	
	void Update () {
		gameObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0,0,distance));
		gameObject.transform.LookAt (player.transform);
	}

	void onDisable(){
		Rigidbody obj = gameObject.GetComponent<Rigidbody>();
		obj.isKinematic = false;
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
