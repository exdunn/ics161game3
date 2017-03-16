using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEffect : MonoBehaviour {

    private float speed = 100.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        rotate();
	}

    // rotate the transform
    private void rotate ()
    {
        transform.Rotate(0, speed * Time.deltaTime,0);
    }
}
