using UnityEngine;
using System.Collections;

public class CarScript : MonoBehaviour {

    public float movementSpeed;
    public GameObject player;

    private float distanceToPlayer;
    private float position;
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        distanceToPlayer = player.transform.position.x;
        position = transform.transform.position.x;

        distanceToPlayer = position - distanceToPlayer;

        if (distanceToPlayer < 15)
        {
            transform.Translate(new Vector2(-movementSpeed, 0f));
        }
	}

    void OnCollisionEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
