using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public float movmentSpeed;
    private float enemyX = 1;
    //private float enemyY;

    void Start()
    {

    }

    void Update()
    {

        transform.Translate(new Vector2(enemyX * movmentSpeed, 0f), Space.World);
        
        
    }
}
