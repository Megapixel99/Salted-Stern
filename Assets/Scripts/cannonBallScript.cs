using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonBallScript : MonoBehaviour {
	// Use this for initialization
	float timer;
	float xspeed;
	public float modifier = 1;
	void Start () {
		timer = 0;
		xspeed = 20;
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Translate (new Vector3(xspeed*modifier, 5, 0)*Time.deltaTime);

		timer += Time.deltaTime;
		if (timer >= 4)
			Destroy (gameObject);

	}
}
