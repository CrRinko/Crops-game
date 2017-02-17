using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainS : MonoBehaviour {
	public TerrainData terrainData;
	private float[,] backup;
	public ArrayList pits = new ArrayList ();
	// Use this for, initialization
	void Start () {
		int height = terrainData.heightmapHeight;
		int width = terrainData.heightmapWidth;
		backup = terrainData.GetHeights (0, 0, width, height);
	}
	
	void OnApplicationQuit(){
		terrainData.SetHeights (0, 0, backup);
		PitManager.pits.Clear ();
	}
}
