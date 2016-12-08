using UnityEngine;
using System.Collections;

public class ArrowScript : MonoBehaviour {


	void Start () 
    {
	
	}
	
	void Update () 
    {
	
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag != "ShooterEnemy")
        {
            Destroy(gameObject);
        }
    }
}
