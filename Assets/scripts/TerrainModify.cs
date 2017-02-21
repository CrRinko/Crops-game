using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainModify : MonoBehaviour {
	public TerrainData terrainData;
	// Use this for initialization
	void Start () {
		ModifyTerrainDataHeight ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void ModifyTerrainDataHeight()
	{
		int width = terrainData.heightmapWidth;
		int height = terrainData.heightmapHeight;
		float[,] array = new float[width, height];
		print("width:" + width + " height:" + height);
		for (int i = 0; i < width; i++)
			for (int j = 0; j < height; j++)
			{
				float f1 = i;
				float f2 = width;
				float f3 = j;
				float f4 = height;
				float baseV = (f1 / f2 + f3 / f4) / 2 * 1;
				array[i, j] = 1;
			}
		// 设置高度图
		terrainData.SetHeights(0, 0, array);
	}
}
