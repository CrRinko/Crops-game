using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour {
	public void Grow(GameObject watermelon){
		watermelon script = watermelon.GetComponent<watermelon> ();
		if (script.Stage == 2) {
			script.GrowUp ();
		}
	}
}
