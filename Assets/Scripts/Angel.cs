using UnityEngine;
using System.Collections;

public class Angel : MonoBehaviour {

    public Transform target;
    public GameObject arrowPrefab;
    public Transform arrowSpawn;
    public float shootTimer = 2.0f;

    private float currentTime;
    private float angelX;
    private float targetX;
    private float positionX;

    bool angelFacingRight = false;

    // Use this for initialization

    void Start()
    {
        positionX = 0;
        currentTime = shootTimer;
    }

    // Update is called once per frame

    void Update ()
    {

        targetX = target.transform.position.x;
        angelX = transform.position.x;

        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            Shoot();
        }

        if (angelX > targetX)
        {
            angelFacingRight = false;
            //transform.Rotate(0,-180, 0);
        }
        else if (angelX <= targetX)
        {
            angelFacingRight = true;
            //transform.Rotate(0, 0, 0);
        }

        if (angelFacingRight == true)
        {
            Vector3 scale = transform.localScale;
            scale.x = -Mathf.Abs(scale.x);
            transform.localScale = scale;

            Vector3 arrowScale = arrowPrefab.transform.localScale;
            arrowScale.x = -Mathf.Abs(arrowScale.x);
            arrowPrefab.transform.localScale = arrowScale;
        }
        else
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x);
            transform.localScale = scale;

            Vector3 arrowScale = arrowPrefab.transform.localScale;
            arrowScale.x = Mathf.Abs(arrowScale.x);
            arrowPrefab.transform.localScale = arrowScale;
        }



        Vector3 directionToPlayer = target.transform.position - transform.position;
        //directionToPlayer.Normalize();

        Quaternion rotation = Quaternion.LookRotation(directionToPlayer);
        rotation.y = 0;
        rotation.x = 0;
        transform.rotation = rotation;

    }
    void Shoot()
    {
        var arrow = (GameObject)Instantiate(
            arrowPrefab,
            arrowSpawn.position,
            arrowSpawn.rotation);

        arrow.GetComponent<Rigidbody2D>().velocity = -arrow.transform.right * 6;

        
        if (angelFacingRight == false)
        {

            arrow.GetComponent<Rigidbody2D>().velocity = -arrow.transform.right * 6;
        }
        else 
        {

            arrow.GetComponent<Rigidbody2D>().velocity = arrow.transform.right * 6;
        }

        currentTime = shootTimer;


        Destroy(arrow, 2.0f);
    }
}
