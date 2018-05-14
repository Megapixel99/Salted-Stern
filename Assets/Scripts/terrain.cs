using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrain : MonoBehaviour {
	public Terrain splatmapData;
	public int seed;

	// Use this for initialization
	void Start () {
		seed = Random.Range(0,10000);
		GenerateHeights (this.GetComponent<Terrain> (), 7f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void GenerateHeights(Terrain terrain, float tileSize) {
		float[,] heights = new float[terrain.terrainData.heightmapWidth, terrain.terrainData.heightmapHeight];

		for (int i = 0; i < terrain.terrainData.heightmapWidth; i++) {
			for (int k = 0; k < terrain.terrainData.heightmapHeight; k++) {
				heights[i, k] = Mathf.PerlinNoise((((float)i / (float)terrain.terrainData.heightmapWidth) * tileSize)+seed, (((float)k / (float)terrain.terrainData.heightmapHeight) * tileSize)+seed)/10.0f;
				//terrain.terrainData.SetAlphamaps(0, 0, splatmapData);
			}
		}

		terrain.terrainData.SetHeights(0, 0, heights);
	}
}
