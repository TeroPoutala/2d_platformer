using UnityEngine;
using System.Collections;

public class TurretEnemyScript : MonoBehaviour {

    public GameObject arrowPrefab;
    public Transform arrowSpawn;
    public float shootTimer = 2.0f;

    private float currentTime;
	void Start () 
    {
        currentTime = shootTimer;

	}
	
	void Update () 
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            Shoot();
        }
	}
    void Shoot()
    {
        // Create the Bullet from the Bullet Prefab
        var arrow = (GameObject)Instantiate(
            arrowPrefab,
            arrowSpawn.position,
            arrowSpawn.rotation);



        // Add velocity to the bullet
        arrow.GetComponent<Rigidbody2D>().velocity = -arrow.transform.right * 6;

        currentTime = shootTimer;

        // Destroy the bullet after 2 seconds
        Destroy(arrow, 2.0f);
    }
}
