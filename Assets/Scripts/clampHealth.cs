using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clampHealth : MonoBehaviour {

	// Use this for initialization
	public Image pirateHealthBar;
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		Vector3 healthPos = Camera.main.WorldToScreenPoint (this.transform.position);
		pirateHealthBar.transform.position = healthPos;
	}
}
