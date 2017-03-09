using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour {

    
    private bool forward;
    private float xStart;
    private float xEnd;

    public float lapSize = 15;
    public float speed = 20f;

	// Use this for initialization
	void Start () {
        xStart = transform.position.x;
        xEnd = transform.position.x + lapSize;
        forward = true;


        Debug.Log("start: " + xStart);
        Debug.Log("end: " + xEnd);
    }
	
	// Update is called once per frame
	void Update () {
        MoveHorizontal();
	} 

    // move the platform
    private void MoveHorizontal ()
    {
        float xMove = 0f;

        if (forward)
        {
            xMove = transform.position.x + speed * Time.deltaTime;

            if (transform.position.x >= xEnd)
                forward = false;
        }
        else
        {
            xMove = transform.position.x - speed * Time.deltaTime;

            if (transform.position.x <= xStart)
                forward = true;
        }
        transform.position = new Vector3(xMove, transform.position.y, transform.position.z);
    }
}
