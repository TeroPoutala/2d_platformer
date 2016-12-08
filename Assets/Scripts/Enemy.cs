using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    private float enemyX = 0f;
    //private float enemyY = 0f;
    private bool facingRight;
    private float hitTimer;
    private float jumpTimer;
    private float moveTimer;

    public float invTime;
    public Transform left;
    public Transform right;
    public float movementSpeed;
    public float jumpSpeed;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        enemyX = 1;
        facingRight = true;
        hitTimer = invTime;
        jumpTimer = 3;
        moveTimer = 5;
    }

    void Update()
    {
        transform.Translate(new Vector2(enemyX * movementSpeed, 0f), Space.World);

        jumpTimer -= Time.deltaTime;
        moveTimer -= Time.deltaTime;

        if (moveTimer <= 0)
        {
            facingRight = !facingRight;
            enemyX *= -1;
            moveTimer = 5;

            if (facingRight == true)
            {
                Vector3 scale = transform.localScale;
                scale.x = Mathf.Abs(scale.x);
                transform.localScale = scale;
            }
            else
            {
                Vector3 scale = transform.localScale;
                scale.x = -Mathf.Abs(scale.x);
                transform.localScale = scale;
            }
        }

        if (jumpTimer <= 0)
        {
            rb.AddForce(transform.up * jumpSpeed);
            jumpTimer = 3;
        }
    }
}
