using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class board : MonoBehaviour {
	public int pixWidth = 100;
	public int pixHeight = 100;
	public float xOrg;
	public float yOrg;
	public float scale = 1.0F;
	private Texture2D noiseTex;
	private Color[] pix;
	private Renderer rend;
	private int seed;
	// Use this for initialization
	void Start () {
		seed = Random.Range(0,10000);

		rend = GetComponent<Renderer>();
		noiseTex = new Texture2D(pixWidth, pixHeight);
		pix = new Color[noiseTex.width * noiseTex.height];
		rend.material.mainTexture = noiseTex;

		GenerateBoard();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void GenerateBoard() {
		float y = 0.0F;
		print (noiseTex.height);
		while (y < noiseTex.height) {
			float x = 0.0F;
			while (x < noiseTex.width) {
				float xCoord = xOrg + x / noiseTex.width * scale;
				float yCoord = yOrg + y / noiseTex.height * scale;
				float sample = Mathf.PerlinNoise(xCoord + seed, yCoord + seed);
				//Define colours
				float r = 0;
				float g = 0;
				float b = 0;
				if (sample > 0.7) {
					r = 0.7f;
					g = sample+0.3f;
					b = 0.2f;
				} else {
					b = sample+0.2f;
				}
				//End define colours
				pix[(int)(y * noiseTex.width) + (int)x] = new Color(r, g, b);
				x++;
			}
			y++;
		}
		noiseTex.SetPixels(pix);
		noiseTex.Apply();
	}
}
