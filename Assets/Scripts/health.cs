using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour {

	// Use this for initialization
	public Image Bar;
	public float maxHealth;
	public float curHealth;
	float num;
	void Start () {
		maxHealth = 1f;
		curHealth = maxHealth;
		num = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		Bar.fillAmount = curHealth;
	}
}
