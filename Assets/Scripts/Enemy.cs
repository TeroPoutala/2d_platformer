using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    private float enemyX = 0f;
    //private float enemyY = 0f;
    private bool facingRight;
    private float hitTimer;

    public float invTime;
    public Transform left;
    public Transform right;
    public float movmentSpeed;

    void Start()
    {
        enemyX = -1;
        facingRight = false;
        hitTimer = invTime;
    }

    void Update()
    {
        transform.Translate(new Vector2(enemyX * movmentSpeed, 0f), Space.World);

        
        float distance = 0;

        if (facingRight == true)
        {
            distance = Vector2.Distance(transform.position, right.position);
        }
        else
        {
            distance = Vector2.Distance(transform.position, left.position);
        }

        if (distance < 0.2f)
        {
            facingRight = !facingRight;
            enemyX *= -1;
        }
    }
}
