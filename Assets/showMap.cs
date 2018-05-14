using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class showMap : MonoBehaviour {
	public bool isImgOn;
	public RawImage img;

	void Start () {

		img = this.GetComponent<RawImage> ();
		img.enabled = true;
		isImgOn = true;
	}

	void Update () {

		if (Input.GetKey ("m")) {



			img.enabled = true;
			isImgOn = true;
		}

			else {

				img.enabled = false;
				isImgOn = false;
			}
		
	}
}
