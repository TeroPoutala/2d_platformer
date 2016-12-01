using UnityEngine;
using System.Collections;

public class SwingHitbox : MonoBehaviour {

    public float power = 0;
    public static bool hit;

    private bool enemyCheck;

    GameObject target;
    public Enemy targetEnemy;

	void Start ()
    {
        enemyCheck = false;
        hit = false;

	}
	

	void Update ()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0) && enemyCheck == true)
        {
            hit = true;

            Debug.Log("hit enemy");

            target.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * power);
            target.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * power);
        }
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            enemyCheck = true;
            target = other.gameObject;
            Debug.Log("check enemy");

        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemyCheck = false;
            Debug.Log("uncheck enemy");
        }
    }
}
