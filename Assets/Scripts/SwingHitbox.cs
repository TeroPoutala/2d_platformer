using UnityEngine;
using System.Collections;

public class SwingHitbox : MonoBehaviour {

    private bool enemyCheck;

	void Start ()
    {
        enemyCheck = false;
	}
	

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && enemyCheck == true)
        {
            Debug.Log("hit enemy");
        }
        
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            enemyCheck = true;
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
