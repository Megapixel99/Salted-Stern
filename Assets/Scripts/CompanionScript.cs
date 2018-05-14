using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;




/// <summary>
///  determining if something is on the left or right of an object higherscriptingauthority
/// </summary>






public class CompanionScript : MonoBehaviour {
	public float reloadTime = 1f;
	NavMeshAgent agent;
	public Transform cannonBall;
	private GameObject[] enemy;
	public Transform target;
	public float dirNum;
	void Start() {
		transform.position.Set (transform.position.x,36.5f,transform.position.z);
		agent = GetComponent<NavMeshAgent>();
		enemy = GameObject.FindGameObjectsWithTag("Enemy");
	}

	void Update() {





		if (Input.GetMouseButtonDown(1)) {
			RaycastHit hit;

			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
				agent.destination = hit.point;
			}
		}

		for (int i = 0; i < enemy.Length; i++) {
			if(target==null)
			target = enemy [i].gameObject.transform;
		
			//DirStuff
			Vector3 heading = target.position - transform.position;
			dirNum = AngleDir(transform.forward, heading, transform.up);

			//

			float distance = Vector3.Distance (enemy[i].gameObject.transform.position, agent.gameObject.transform.position);
			if (distance < 25.0f) {
				Attack (i);
			} 
		}
	}
	//OTHER 90 DEGREE FOR OTHER SIDE STILL NEEDED
	void Attack(int i){

	// pretty good strafe, issue with mult enemies	transform.RotateAround (enemy [i].gameObject.transform.position, Vector3.up, .1f);
		if (dirNum == 1) {
			GameObject.Find("AICannonBall").GetComponent<cannonBallScript> ().modifier = 1;
			transform.Rotate (Vector3.up);
		}
		//transform.Rotate (Vector3.up);
		if (dirNum == -1 ) {
			GameObject.Find("AICannonBall").GetComponent<cannonBallScript> ().modifier = -1;
			transform.Rotate (-Vector3.up);
		}
		//transform.Rotate (-Vector3.up);

		reloadTime -= Time.deltaTime;
		if (reloadTime <= 0) {
			Instantiate (cannonBall, transform.position, transform.rotation);
			reloadTime = 1f;
		}

}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag.Equals ("PirateCannonball") || other.tag.Equals ("Cannonball") ) {
			print ("we hit");
		}
	}

	float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up) {
		Vector3 perp = Vector3.Cross(fwd, targetDir);
		float dir = Vector3.Dot(perp, up);

		if (dir > 0f) {
			return 1f;
		} else if (dir < 0f) {
			return -1f;
		} else {
			return 0f;
		}
	}


}