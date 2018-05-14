using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class playerScript : MonoBehaviour {
    public Image Bar;
	health h;
	public float curHealth;
	public Transform fire;

    Vector3 velocity = Vector3.zero;
	float speed = 4;
	public Transform cannonBall;
	// Use this for initialization
	void Start () {
		curHealth = h.curHealth;
        transform.position.Set (transform.position.x,36.5f,transform.position.z);
	}

	// Update is called once per frame
	void Update () {
        Bar.fillAmount = curHealth;
        //this.GetComponent<NavMeshObstacle>.carving = false;

        CharacterController controller = GetComponent<CharacterController>();
		velocity = new Vector3(0,0,-Input.GetAxis("Vertical")*speed);
	
		transform.Translate(velocity * Time.deltaTime);
		transform.Rotate(new Vector3 (0,-Input.GetAxis("Horizontal")*13,0) * Time.deltaTime);

		if (Input.GetMouseButtonDown (0)) {
			if (Input.mousePosition.x < Screen.width / 2)
				Instantiate (cannonBall, transform.position, transform.rotation);
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
        if (curHealth <= 0) {

			if (curHealth <= 0) {
				Instantiate (fire.gameObject);
				Destroy (fire.gameObject, 1);
			} else {

				Debug.Log ("H");
			}

            Destroy(this.gameObject, 5);
        }
    }
}
