using UnityEngine;
using System.Collections;

public class Angel : MonoBehaviour {

    public Transform target;

    private float angelX;
    private float targetX;
    private float positionX;

    bool angelFacingRight = false;

    // Use this for initialization

    void Start()
    {
        positionX = 0;
    }

    // Update is called once per frame

    void Update ()
    {

        targetX = target.transform.position.x;
        angelX = transform.position.x;

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
        }
        else
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x);
            transform.localScale = scale;
        }

        Vector3 directionToPlayer = target.transform.position - transform.position;
        //directionToPlayer.Normalize();

        Quaternion rotation = Quaternion.LookRotation(directionToPlayer);
        rotation.y = 0;
        rotation.x = 0;
        transform.rotation = rotation;

    }
}
