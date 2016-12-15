using UnityEngine;
using System.Collections;

public class SwingHitbox : MonoBehaviour {

    public float power = 0;

    private bool enemyCheck;
    private Enemy[] enemys;
    private CarScript[] carEnemys;
    private int targetEnemyID;
    private int targetHitID;
    private GameObject target;

    public Enemy targetEnemy;

	void Start ()
    {
        enemyCheck = false;

        enemys = FindObjectsOfType<Enemy>();
        carEnemys = FindObjectsOfType<CarScript>();
	}
	

	void Update ()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0) && enemyCheck == true)
        {

            target.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * power);
            target.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * power);

            
            foreach (Enemy enemy in enemys)
            {
                if (enemy != null)
                {
                    targetEnemyID = enemy.personalID;
                    Debug.Log("enemy" + targetEnemyID);

                    if (targetEnemyID == targetHitID)
                    {
                        enemy.hit = true;
                        enemy.lives--;
                        Debug.Log("hit enemy" + targetHitID);
                    }
                }
            }
            foreach (CarScript carEnemy in carEnemys)
            {
                if (carEnemy != null)
                {
                    targetEnemyID = carEnemy.personalID;
                    Debug.Log("enemy" + targetEnemyID);

                    if (targetEnemyID == targetHitID)
                    {
                        carEnemy.hit = true;
                        carEnemy.lives--;
                        Debug.Log("hit enemy" + targetHitID);
                    }
                }
            }
            //GameObject obj = GameObject.Find("Player");
            //Player Pscript = obj.GetComponent<Player>();

            
            //enemyScript.hit = true;
        }
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            enemyCheck = true;
            target = other.gameObject;
            targetHitID = other.gameObject.GetInstanceID();
            Debug.Log("check enemy" + targetHitID);

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
