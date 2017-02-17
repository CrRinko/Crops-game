using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chanzi : MonoBehaviour
{
	public TerrainData terrainData;
	public float dig_radius;
	public float dig_deep;

	public void Start(){
		dig_deep = dig_deep / 100;
		dig_radius = dig_radius / 10;
	}
	public void dig (float xBase, float yBase){
		float alpha = dig_deep / Mathf.Pow (dig_radius,2);
		Vector3 scale=terrainData.heightmapScale;
		int xPos = (int)(xBase / scale.x);
		int yPos = (int)(yBase / scale.z);
		int radius_x = (int)(dig_radius / scale.x);
		int radius_y = (int)(dig_radius / scale.z);
		if (xBase > dig_radius && yBase > dig_radius) {
			float[,] height=terrainData.GetHeights(xPos-radius_x,yPos-radius_y,2*radius_x,2*radius_y);
			float[,] new_height=new float[2*radius_y,2*radius_x];
			for (int i = 0; i < 2 * radius_y; i++) {
				for (int j = 0; j < 2 * radius_x; j++) {
					if (Mathf.Pow ((i - radius_y)*scale.z, 2) + Mathf.Pow ((j - radius_x)*scale.x, 2) <= Mathf.Pow (dig_radius, 2)) { //挖个圆的
						new_height [i, j] = height [i, j] - dig_deep + alpha * (Mathf.Pow ((i - radius_y)*scale.z, 2) + Mathf.Pow ((j - radius_x)*scale.x, 2));
					} else {
						new_height [i, j] = height [i, j];
					}
					//new_height [i, j] = height [i, j] - dig_deep; //挖个方的
				}
			}
			GetComponent<PitManager> ().AddPit (xBase,yBase,dig_radius,height);
			terrainData.SetHeights (xPos-radius_x,yPos-radius_y,new_height);
		}
	}
	/*
	public void Update(){
		//print (gameObject.transform.position);
	}
	*/
}
