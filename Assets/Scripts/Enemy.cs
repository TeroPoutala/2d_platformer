using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    private float enemyX = 0f;
    //private float enemyY = 0f;
    private bool facingRight;
    private bool canMove;
    private float hitTimer;
    private float jumpTimer;
    private float moveTimer;
    private float invTime;

    public int lives;
    public int personalID;
    public Transform player;
    public float movementSpeed;
    public float jumpSpeed;
    public bool hit;

    private Rigidbody2D rb;
    //private float distanceToPlayer;
    //private float cameraHeight;
    //private float cameraWidth;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        enemyX = 1;
        facingRight = true;
        hit = false;
        canMove = true;
        hitTimer = invTime;
        jumpTimer = 3;
        moveTimer = 5;
        invTime = 1;
        lives = 2;

        personalID = gameObject.GetInstanceID();

        //cameraHeight = 2 * Camera.main.orthographicSize;
        //cameraWidth = cameraHeight * Camera.main.aspect;


    }

    void Update()
    {
        

        if (hit == true)
        {
            canMove = false;
            invTime -= Time.deltaTime;
            if (invTime <= 0)
            {
                if (lives <= 0)
                {
                    Destroy(gameObject);
                }

                canMove = true;
                hit = false;
                invTime = 1;
            }
        }


        if (canMove == true)
        {
            transform.Translate(new Vector2(enemyX * movementSpeed, 0f), Space.World);

            //distanceToPlayer = transform.position.x - player.transform.position.x;

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
}
