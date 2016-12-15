using UnityEngine;
using System.Collections;

public class CoinCollectable : MonoBehaviour {


    public float scoreAmount;
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
            Player.score += scoreAmount;
            Destroy(gameObject);
        }
    }
}
