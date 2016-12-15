using UnityEngine;
using System.Collections;

public class CarScript : MonoBehaviour {

    public float movementSpeed;
    public GameObject player;
    public int personalID;
    public int lives;
    public bool hit;

    private float distanceToPlayer;
    private float position;
    private float invTime;
    private float lifeTime;
    private bool activated;
	// Use this for initialization
	void Start () 
    {
        personalID = gameObject.GetInstanceID();

        invTime = 1;
        lifeTime = 5;
        lives = 1;
        hit = false;
        activated = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        distanceToPlayer = player.transform.position.x;
        position = transform.transform.position.x;


        distanceToPlayer = position - distanceToPlayer;

        if (distanceToPlayer < 15)
        {
            activated = true;
            if (hit == false)
            {
                transform.Translate(new Vector2(-movementSpeed, 0f));
            }
        }

        if (hit == true)
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
            movementSpeed = 0;

            invTime -= Time.deltaTime;
            if (invTime <= 0)
            {
                if (lives <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
        if (activated == true)
        {
            lifeTime -= Time.deltaTime;
            if (lifeTime <= 0)
            {
                Destroy(gameObject);
            }
        }
	}
}
