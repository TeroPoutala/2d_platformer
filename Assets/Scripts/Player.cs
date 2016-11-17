using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public float xSpeed = 0f;
    public float ySpeed = 0f;
    private float playerX = 0f;
    private float playerY = 0f;

    private Rigidbody2D rb;
    private bool grounded = false;
    
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKey(KeyCode.A))
        {
            playerX = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            playerX = 1;
        }
        else
        {
            playerX = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            grounded = false;
            rb.AddForce(transform.up * ySpeed);
        }
        else
        {
            playerY = 0;
        }

        transform.Translate(new Vector2(playerX * xSpeed, playerY * ySpeed), Space.World);

        //if (rb.velocity.y == 0)
        //{
        //    grounded = true;
        //}

    }
    void OnCollisionEnter2D (Collision2D col)
    {
        if(col.gameObject.tag == "Ground")
        {
            grounded = true;
        }
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);
        }
    }


}
