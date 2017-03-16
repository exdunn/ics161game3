using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGrav : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () { 

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D c)
    {
        if (this.gameObject.tag == "ChangeGravPlat" && c.gameObject.tag == "Player")
        {
            c.gameObject.GetComponent<Rigidbody2D>().drag = 2f;
            c.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.3f;
        }
        else
        {
           c.gameObject.GetComponent<Rigidbody2D>().drag = 0f;
           c.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1f;
        }

    }
}
