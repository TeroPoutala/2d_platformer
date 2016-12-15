using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour
{

    public float xSpeed = 0f;
    public float ySpeed = 0f;
    public float knockBack = 0f;
    public float invTime = 0f;
    public static float score;
    public static int lives;
    public Text ScoreText;
    public Text GameOverText;
    public Image life1;
    public Image life2;
    public Image life3;

    private float invincibility;
    private float playerX = 0f;
    private float playerY = 0f;
    private float hitTimer = 0f;
    private bool facingRight = true;
    private bool hit = false;
    private bool grounded;
    private bool canMove;

    private Rigidbody2D rb;

    private Animator animator;
    
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hitTimer = invTime;
        invincibility = 1.5f;

        grounded = false;
        canMove = true;
        lives = 3;
        score = 0;
        SetScoreText();
        SetLivesUI();

        GameOverText.gameObject.SetActive(false);

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(grounded);

        SetScoreText();
        
        if (lives <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }


        if (hit == true)
        {
            hitTimer -= Time.deltaTime;
            invincibility -= Time.deltaTime;

            if (hitTimer <= 0f)
            {
                canMove = true;
                hitTimer = invTime;
            }
            if (invincibility <= 0)
            {
                invincibility = 1.5f;
                hit = false;
            }
        }
        if (lives <= 0)
        {
            GameOverText.gameObject.SetActive(true);
        }

        if (facingRight == false)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger("playerAttack");

        }

        if (Input.GetKey(KeyCode.A) && canMove == true)
        {
            playerX = -1;
            facingRight = false;

            if (Input.GetKey(KeyCode.A))
            {
                animator.SetBool("playerRun 0", true);
            }
        }
        else if (Input.GetKey(KeyCode.D) && canMove == true)
        {
            playerX = 1;
            facingRight = true;

            if (Input.GetKey(KeyCode.D))
            { 
                animator.SetBool("playerRun 0", true);
            }       
        }
        else
        {
            playerX = 0;
            animator.SetBool("playerRun 0", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded == true && canMove == true)
        {
            grounded = false;
            rb.AddForce(transform.up * ySpeed);

        }
        else
        {
            playerY = 0;
        }

        if (grounded == false)
        {
            animator.SetBool("playerJump 0", true);
        }
        else
        {
            animator.SetBool("playerJump 0", false);
        }



        transform.Translate(new Vector2(playerX * xSpeed, playerY * ySpeed), Space.World);

        SetLivesUI();
    }
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground" || col.gameObject.tag == "ShooterEnemy" || col.gameObject.tag == "Spikes")
        {
            grounded = true;
        }
        if (col.gameObject.tag == "Enemy" && invincibility == 1.5f || col.gameObject.tag == "Spikes" && invincibility == 1.5f)
        {
            rb.AddForce(transform.right * -knockBack);
            rb.AddForce(transform.up * knockBack);
            hit = true;
            canMove = false;
            lives--;
        }

    }

    void SetScoreText()
    {
        ScoreText.text = "Score : " + score;
    }
    void SetLivesUI()
    {
        if (lives == 3)
        {
            life1.gameObject.SetActive(true);
            life2.gameObject.SetActive(true);
            life3.gameObject.SetActive(true);
        }
        else if (lives == 2)
        {
            life1.gameObject.SetActive(true);
            life2.gameObject.SetActive(true);
            life3.gameObject.SetActive(false);
        }
        else if (lives == 1)
        {
            life1.gameObject.SetActive(true);
            life2.gameObject.SetActive(false);
            life3.gameObject.SetActive(false);
        }
        else if (lives <= 0)
        {
            life1.gameObject.SetActive(false);
            life2.gameObject.SetActive(false);
            life3.gameObject.SetActive(false);
        }

    }
}
