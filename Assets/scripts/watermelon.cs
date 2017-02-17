using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class watermelon : MonoBehaviour {
	public Camera player;
	public GameObject flower;
	public GameObject fruit;
	private int stage = 1;
	private Material stage1;
	private Material stage2;
	private Material stage3;
	// Use this for initialization
	void Start () {
		stage1 = (Material)Resources.Load ("stage 1");
		stage2 = (Material)Resources.Load ("stage 2");
		stage3 = (Material)Resources.Load ("stage 3");
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.LookAt (player.transform);
	}
	public int Stage{
		get{ 
			return stage;
		}
	}
	public void GrowUp(){
		stage++;
		if (stage <= 3) {
			switch (stage) {
			case 1:
				gameObject.GetComponent<Renderer> ().material = stage1;
				break;
			case 2:
				gameObject.GetComponent<Renderer> ().material = stage2;
				break;
			case 3:
				gameObject.GetComponent<Renderer> ().material = stage3;
				break;
			default:
				break;
			}
		} else {
			Destroy (gameObject);
		}
	}
	public GameObject GetFlower(){
		if (stage == 2) {
			GameObject clone = Instantiate (flower, transform.position, flower.transform.rotation);
			//clone.transform.localScale += new Vector3 (10, 10, 10);
			//clone.AddComponent<ActiveManager> ();
			//clone.GetComponent<ActiveManager> ().Player = player;
			clone.GetComponent<ActiveManager>().enabled=true;
			return clone;
		} else {
			return null;
		}
	}
	public GameObject GetFruit(){
		if (stage == 3) {
			GameObject clone = Instantiate (fruit, transform.position, fruit.transform.rotation);
			clone.GetComponent<ActiveManager> ().enabled = true;
			return clone;
		} else {
			return null;
		}
	}
}
