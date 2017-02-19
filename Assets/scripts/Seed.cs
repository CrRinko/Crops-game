using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour {
	private bool invalidated = true;
	public bool isClone = false;
	
	// Update is called once per frame
	void Update () {
		if (invalidated) {
			ArrayList list = PitManager.pits;
			for (int i = 0; i < list.Count; i++) {
				PitManager.Pit pit = (PitManager.Pit)list [i];
				if (pit.InIt (gameObject.transform.position)) {
					pit.AddSeed (gameObject);
					invalidated = false;
					break;
				}
			}
		}
	}
		
	void OnCollisionStay(Collision collisionInfo) {
		if (invalidated&&isClone) {
			Destroy (gameObject, 5);
		}
	}
}
