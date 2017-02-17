using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour {
	public Camera _player;
	private Ray _ray;
	private RaycastHit _rayhit;
	public float _fDistance = 20f;
	private GameObject target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		_ray = _player.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (_ray, out _rayhit, _fDistance)) {
			target = _rayhit.collider.gameObject;
			if (target.CompareTag ("Text")) {
				print (target.name);
			}
		}
	}
}
