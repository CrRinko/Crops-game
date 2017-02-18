using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class watermelon : MonoBehaviour {
	public Camera player;
	public GameObject flower;
	public GameObject fruit;
	public int blink_frame;
	private int cur_frame=0;
	private bool isHighLight=false;
	private int status = 0;
	private Material[] stages=new Material[7];
	private Material[] highlights = new Material[2];
	// Use this for initialization
	void Start () {
		stages[0] = (Material)Resources.Load ("s0");
		stages[1] = (Material)Resources.Load ("s1");
		stages[2] = (Material)Resources.Load ("s2_0");
		stages[3] = (Material)Resources.Load ("s2_1");
		stages[4] = (Material)Resources.Load ("s3_0");
		stages[5] = (Material)Resources.Load ("s3_1");
		stages[6] = (Material)Resources.Load ("s3_2");
		highlights [0] = (Material)Resources.Load ("s3_0_h");
		highlights [1] = (Material)Resources.Load ("s3_1_h");
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.LookAt (player.transform);
		if (status == 4) {
			if (cur_frame == 0) {
				if (isHighLight) {
					gameObject.GetComponent<Renderer> ().material = stages [4];
				} else {
					gameObject.GetComponent<Renderer> ().material = highlights [0];
				}
				isHighLight = !isHighLight;
			}
			cur_frame = (cur_frame + 1) % blink_frame;
		} else if (status == 5) {
			if (cur_frame == 0) {
				if (isHighLight) {
					gameObject.GetComponent<Renderer> ().material = stages [5];
				} else {
					gameObject.GetComponent<Renderer> ().material = highlights [1];
				}
				isHighLight = !isHighLight;
			}
			cur_frame = (cur_frame + 1) % blink_frame;
		}
	}
	public int Stage{
		get{ 
			if (status == 0) {
				return 0;
			} else if (status == 1) {
				return 1;
			} else if (status >= 2 && status <= 3) {
				return 2;
			} else if (status >= 4 && status <= 6) {
				return 3;
			} else {
				return 3;
			}
		}
	}
	public void GrowUp(){
		status++;
		if (status == 1) {
			gameObject.transform.localScale += new Vector3 (1, 1, 1);
			gameObject.transform.Translate (new Vector3 (0f, 0.5f, 0f));
		}
		if (status < 7) {
			gameObject.GetComponent<Renderer> ().material = stages [status];
		} else {
			Destroy (gameObject);
		}
	}
	public GameObject GetFlower(){
		if (status == 2) {
			GameObject clone = Instantiate (flower, transform.position, flower.transform.rotation);
			clone.GetComponent<ActiveManager>().enabled=true;
			GrowUp ();
			return clone;
		} else {
			return null;
		}
	}
	public GameObject GetFruit(){
		if (status >=4&&status<=5) {
			GameObject clone = Instantiate (fruit, transform.position, fruit.transform.rotation);
			clone.GetComponent<ActiveManager> ().enabled = true;
			GrowUp ();
			return clone;
		} else {
			return null;
		}
	}
}
