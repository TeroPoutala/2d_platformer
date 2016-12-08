using UnityEngine;
using System.Collections;

public class ArrowScript : MonoBehaviour {


	void Start () 
    {
	
	}
	
	void Update () 
    {
	
	}
    void OnTriggerEnter2D()
    {
        Destroy(gameObject);
    }
}
