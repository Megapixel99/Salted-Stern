﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class basicAI : MonoBehaviour {

	public Transform goal;
	NavMeshAgent agent;
	void Start () {
		
		agent = GetComponent<NavMeshAgent>();
	}

	void Update ()
	{
	}
}
		//if(Vector3.Distance(goal.position, agent.transform.position)<5)
		//agent.destination = goal.position; 


		//moving agent to a mouseclick
	/*	if (Input.GetMouseButtonDown (0)) {
		RaycastHit hit;

			if (Physics.Raycast
				(Camera.main.ScreenPointToRay (Input.mousePosition),
				    out hit, 100)) {
				agent.destination = hit.point; 
			}

		} */
	

	 

	
