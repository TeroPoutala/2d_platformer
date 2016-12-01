using UnityEngine;
using System.Collections;

public class Angel : MonoBehaviour {

    public Transform target;

    private int angelX;
    private int targetX = 0;

    bool angleFacingRight = false;

    // Use this for initialization

    void Start ()
    {
	
	}

    // Update is called once per frame

    void Update ()
    {
	    
        if (targetX < angelX)
        {
            angleFacingRight = false;
        }
        else
        {
            angleFacingRight = true;
        }

	}
}
