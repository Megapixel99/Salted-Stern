using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AICannonBall : MonoBehaviour {
	Vector3 shootVector;
	// Use this for initialization
	float uhh;
	void Start () {
		uhh = 0;

	}

	// Update is called once per frame
	void Update () {
		float randomAim = Random.value * 35;
		shootVector = new Vector3 ((GameObject.Find ("player").gameObject.transform.position.x+randomAim),
			(GameObject.Find ("player").gameObject.transform.position.x+randomAim-60), 0);

		transform.Translate (shootVector*Time.deltaTime);

		uhh += Time.deltaTime;
		if (uhh >= 4)
			Destroy (gameObject);

	}
}
