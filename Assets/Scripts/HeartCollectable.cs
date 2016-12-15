using UnityEngine;
using System.Collections;

public class HeartCollectable : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Player.lives < 3)
            {
                Player.lives++;
                Destroy(gameObject);
            }
        }
    }
}
