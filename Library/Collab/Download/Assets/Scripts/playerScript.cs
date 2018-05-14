using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class playerScript : MonoBehaviour {
    public Image Bar;
    public int score = 0;

    Vector3 velocity = Vector3.zero;
	float speed = 4;
	public Transform cannonBall;
	// Use this for initialization
	void Start () {

        transform.position.Set (transform.position.x,36.5f,transform.position.z);
	}

	// Update is called once per frame
	void Update () {
        //this.GetComponent<NavMeshObstacle>.carving = false;
		if (Bar.gameObject.GetComponentInChildren<health> ().curHealth > 0f) {
			CharacterController controller = GetComponent<CharacterController> ();
			velocity = new Vector3 (0, 0, -Input.GetAxis ("Vertical") * speed);
	
			transform.Translate (velocity * Time.deltaTime);
			transform.Rotate (new Vector3 (0, -Input.GetAxis ("Horizontal") * 13, 0) * Time.deltaTime);

			if (Input.GetMouseButtonDown (0)) {
				if (Input.mousePosition.x < Screen.width / 2)
					Instantiate (cannonBall, transform.position, transform.rotation);
			}
		}

        checkDeath();


	}

	void OnTriggerEnter (Collider other) {
		if (other.tag.Equals ("PirateCannonball")) {
			Destroy (other.transform.parent.gameObject);
			Bar.gameObject.GetComponentInChildren<health> ().curHealth -= 0.05f;
		}
	}

    void checkDeath() {
        if (Bar.gameObject.GetComponentInChildren<health>().curHealth <= 0) {
            for (int i = 0; i < this.gameObject.transform.GetChildCount(); i++) {
                GameObject shipPart = this.gameObject.transform.GetChild(i).gameObject;
                print(shipPart.gameObject.name);
                if (shipPart.gameObject.name != "Main Camera")
                {
                    if (!shipPart.GetComponent<Collider>().attachedRigidbody)
                    {
                        shipPart.AddComponent<Rigidbody>();
                    }
                    shipPart.GetComponent<Collider>().attachedRigidbody.useGravity = true;
                }
            }

            Destroy(this.gameObject, 5);
        }
    }

    void OnGUI() {
        int t = 0;
        string strDisp = "Ships Destroyed: " + score.ToString();
        GUI.Label(new Rect(10, 10, 150, 20), strDisp);
    }
}
