using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public float xSpeed = 0f;
    public float ySpeed = 0f;
    public float knockBack = 0f;
    public float invTime = 0f;

    private float playerX = 0f;
    private float playerY = 0f;
    private float hitTimer = 0f;
    private bool facingRight = true;
    private bool hit = false;
    private bool grounded = false;

    private Rigidbody2D rb;
    
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hitTimer = invTime;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (hit == true)
        {
            hitTimer -= Time.deltaTime;
            if (hitTimer <= 0f)
            {
                hit = false;
                hitTimer = invTime;
            }
        }
        if (facingRight == false)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.A) && hit == false)
        {
            playerX = -1;
            facingRight = false;
            
        }
        else if (Input.GetKey(KeyCode.D) && hit == false)
        {
            playerX = 1;
            facingRight = true;
        }
        else
        {
            playerX = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded == true && hit == false)
        {
            grounded = false;
            rb.AddForce(transform.up * ySpeed);
        }
        else
        {
            playerY = 0;
        }

        

        transform.Translate(new Vector2(playerX * xSpeed, playerY * ySpeed), Space.World);


    }
    void OnCollisionEnter2D (Collision2D col)
    {
        if(col.gameObject.tag == "Ground")
        {
            grounded = true;
        }
        if (col.gameObject.tag == "Enemy" && invTime == hitTimer)
        {
            rb.AddForce(transform.right * -knockBack);
            hit = true;

        }
    }


}
