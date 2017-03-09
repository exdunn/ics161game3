using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveCamera : MonoBehaviour {

    private GameObject player;
    public float speed = 1f;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

        float xCoord = transform.position.x + Time.deltaTime * speed;
        float yCoord = player.transform.position.y;
        transform.position = new Vector3(xCoord, yCoord, transform.position.z);
		
	}
}
