using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class PirateScript : MonoBehaviour
{
    public Image Bar;
    public float maxHealth;
    public float curHealth;

    public float reloadTime = 1f;
    private NavMeshAgent _nav;
    private Transform _player;
    public Transform cannonBall;
    private GameObject[] companion;
    public Transform target;
    public float dirNum;
    void Start()
    {

        maxHealth = 1f;
        curHealth = maxHealth;

        transform.position.Set(transform.position.x, 36.5f, transform.position.z);
        _nav = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        companion = GameObject.FindGameObjectsWithTag("Friendly");
        target = _player;

    }

    void Update()
    {
        //Bar.fillAmount = curHealth;


        //DirStuff
        Vector3 heading = target.position - transform.position;
        dirNum = AngleDir(transform.forward, heading, transform.up);

        //

        float distance = Vector3.Distance(_player.position, _nav.gameObject.transform.position);

        if (distance < 25.0f)
        {
            Attack();
        }
        else if (distance < 50.0f)
        {
            _nav.SetDestination(_player.position);
        }
        //print (distance);

        for (int i = 0; i < companion.Length; i++)
        {
            float distance2 = Vector3.Distance(companion[i].gameObject.transform.position, _nav.gameObject.transform.position);
            if (distance2 < 25.0f && distance2 < distance)
            {
                AttackCompanion(i);
            }
        }

        CheckDeath();
    }
    void Attack()
    {
        reloadTime -= Time.deltaTime;
        if (reloadTime <= 0)
        {
            GameObject cannonBallObj = Instantiate(cannonBall, transform.position, transform.rotation).gameObject;
            reloadTime = 1f;



            if (dirNum == 1)
            {
                cannonBallObj.GetComponent<cannonBallScript>().modifier = 1;
                transform.RotateAround(_player.position, Vector3.up, .1f);
                //transform.Rotate(-Vector3.up);
            }
            //transform.Rotate (Vector3.up);
            if (dirNum == -1)
            {
                cannonBallObj.GetComponent<cannonBallScript>().modifier = -1;
                transform.RotateAround(_player.position, Vector3.up, .1f);

            }
        }
        //transform.Rotate (-Vector3.up);
    }
    //OTHER 90 DEGREE FOR OTHER SIDE STILL NEEDED
    void AttackCompanion(int i)
    {

        //transform.RotateAround (companion [i].gameObject.transform.position, Vector3.up, 2f);
        if (transform.rotation.eulerAngles.y < 90)
            transform.Rotate(Vector3.up);
        reloadTime -= Time.deltaTime;
        if (reloadTime <= 0)
        {
            Instantiate(cannonBall, transform.position, transform.rotation);
            reloadTime = 3f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("FriendlyCannonball"))
        {
            Destroy(other.transform.parent.gameObject);
            Bar.gameObject.GetComponentInChildren<health>().curHealth -= 0.05f;
        }
    }

    float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up)
    {
        Vector3 perp = Vector3.Cross(fwd, targetDir);
        float dir = Vector3.Dot(perp, up);

        if (dir > 0f)
        {
            return 1f;
        }
        else if (dir < 0f)
        {
            return -1f;
        }
        else
        {
            return 0f;
        }
    }

    void CheckDeath() {
        if (Bar.gameObject.GetComponentInChildren<health>().curHealth <= 0) {
            GameObject.FindGameObjectWithTag("Player").GetComponent<playerScript>().score++;
            Destroy(Bar.gameObject.transform.parent.gameObject);
            Destroy(this.gameObject);
        }
    }

}
