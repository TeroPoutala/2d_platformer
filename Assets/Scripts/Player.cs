using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public float xSpeed = 0f;
    public float ySpeed = 0f;
    private float playerX = 0f;
    private float playerY = 0f;
    public Rigidbody2D rb;
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * ySpeed);
        }
        else
        {
            playerY = 0;
        }

        transform.Translate(new Vector2(playerX * xSpeed, playerY * ySpeed), Space.World);

    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Enemy")
        {
            Destroy(col.gameObject);
        }
    }
}
