using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshBaker : MonoBehaviour {

	//public NavMeshSurface surface;
	public NavMeshSurface[] surfaces;

	// Use this for initialization
	void Start () {
		

		//surface.AddData ();
		for (int i = 0; i < surfaces.Length; i++) 
		{
			
			//surfaces [i].RemoveData ();
			surfaces [i].BuildNavMesh ();
			print (surfaces [i].agentTypeID);
		}  

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
