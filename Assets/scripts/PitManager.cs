using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitManager : MonoBehaviour {
	public TerrainData terrainData;
	public GameObject flower;
	public class Pit{
		public float xBase;
		public float yBase;
		public float radius;
		public float[,] backup;
		private TerrainData terrainData;
		private GameObject flower;
		private bool hasSeed = false;
		private ArrayList seeds=new ArrayList();
		public Pit(TerrainData terrain,GameObject flower){
			terrainData=terrain;
			this.flower=flower;
		}
		public bool InIt(Vector3 pos){
			if (Mathf.Pow (pos.x - xBase, 2) + Mathf.Pow (pos.z - yBase, 2) <= Mathf.Pow (radius, 2)) {
				return true;
			} else {
				return false;
			}
		}
		private void fill(){
			Vector3 scale = terrainData.heightmapScale;
			int xPos = (int)(xBase / scale.x);
			int yPos = (int)(yBase / scale.z);
			int radius_x = (int)(radius / scale.x);
			int radius_y = (int)(radius / scale.z);
			terrainData.SetHeights (xPos-radius_x,yPos-radius_y,backup);
		}
		public void GrowFlower(){
			for (int i = 0; i < seeds.Count; i++) {
				Destroy ((GameObject)seeds [i]);
			}
			fill ();
			Vector3 scale = terrainData.heightmapScale;
			int radius_x = (int)(radius / scale.x);
			int radius_y = (int)(radius / scale.z);
			print (backup [radius_y, radius_x]+" sy:"+scale.y);
			float height = backup [radius_y, radius_x] * scale.y;
			Instantiate (flower,new Vector3(xBase,height+0.2f,yBase),Quaternion.identity);
		}
		public void AddSeed(GameObject seed){
			seeds.Add (seed);
			hasSeed = true;
		}
		public bool HasSeed{
			get{ 
				return hasSeed;
			}
		}
	}
	public static ArrayList pits = new ArrayList ();
	public void AddPit(float xBase,float yBase,float radius, float[,] backup){
		Pit pit=new Pit(terrainData,flower);
		pit.xBase = xBase;
		pit.yBase = yBase;
		pit.radius = radius;
		pit.backup = backup;
		pits.Add (pit);
	}
}
