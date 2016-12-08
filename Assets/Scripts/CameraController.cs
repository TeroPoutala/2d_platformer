using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;

    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;

    private Vector3 offset;

	void Start ()
    {
        offset = transform.position - player.transform.position;
        transform.position = player.transform.position + offset;

        startTime = Time.time;
        journeyLength = Vector3.Distance(transform.position, player.transform.position);
	}
	
	void LateUpdate () 
    {

        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(transform.position, player.transform.position, fracJourney);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
	}
}
