﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour {

    
    private float xStart;
    private float xEnd;

    public bool startLeft;
    public bool forward;
    public float lapSize = 15f;
    public float speed = 3f;

	// Use this for initialization
	void Start () {
        xStart = transform.position.x;
        if (startLeft == true)
        {
            xEnd = transform.position.x - lapSize;
            forward = false;
        }
        else
        { 
            xEnd = transform.position.x + lapSize;
            forward = true;
        }



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

        if (forward && !startLeft)
        {
            xMove = transform.position.x + speed * Time.deltaTime;

            if (transform.position.x >= xEnd)
                forward = false;
        }
        else if (!forward && startLeft)
        {
            xMove = transform.position.x - speed * Time.deltaTime;

            if (transform.position.x <= xEnd)
                forward = true;
        }
        else if(!startLeft && !forward) 
        {
            xMove = transform.position.x - speed * Time.deltaTime;

            if (transform.position.x <= xStart)
                forward = true;
        }

        else if (startLeft && forward)
        {
            xMove = transform.position.x + speed * Time.deltaTime;

            if (transform.position.x >= xStart)
                forward = false;
        }

        transform.position = new Vector3(xMove, transform.position.y, transform.position.z);
    }

    void OnCollisionStay2D (Collision2D other)
    {
        // set player's parent to the platform
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
        }
    }

    void OnCollisionExit2D (Collision2D other)
    {
        // remove player's parent
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }
}
