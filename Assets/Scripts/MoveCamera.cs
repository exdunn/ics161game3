using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveCamera : MonoBehaviour {

    private GameObject player;
    public float speed = 1f;

    // set this in the scene
    // chooses which path the camera follows
    public int mapNumber;

	//For Map1
	private bool map1first;
	private bool map1second;
	private bool map1third;
	private bool map1fourth;
	private bool map1fifth;
	private bool map1sixth;
	private bool map1seventh;
	private bool map1eight;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        
        switch(mapNumber)
        {
            case 1:
                MapOneStart();
                break;
            default:
                Debug.Log("Error: No map selected");
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {

        //float xCoord = transform.position.x + Time.deltaTime * speed;
        //float yCoord = player.transform.position.y;
        //transform.position = new Vector3(xCoord, yCoord, transform.position.z);
        
        // different camera movement for each map
        switch (mapNumber)
        {
            // map one (dingzhu)
            case 1:
                MapOnePath();
                break;
            // map two (poof)
            case 2:
                break;
            // map three (exdunn)
            case 3:
                break;
            default:       
                break;
        }
	}

    // start for map one
    private void MapOneStart()
    {
        map1first = true;
        map1second = false;
        map1third = false;
        map1fourth = false;
        map1fifth = false;
        map1sixth = false;
        map1seventh = false;
        map1eight = false;
    }

    // follow path for map one
    private void MapOnePath ()
    {
        if (transform.position.y < 5.5 && map1first == true)
        {
            map1first = false;
            map1second = true;
        }
        else if (transform.position.x > 18 && map1second == true)
        {
            map1second = false;
            map1third = true;
        }
        else if (transform.position.y > 10 && map1third == true)
        {
            map1third = false;
            map1fourth = true;
        }
        else if (transform.position.x > 39 && map1fourth == true)
        {
            map1fourth = false;
            map1fifth = true;
        }
        else if (transform.position.y < 5.5 && map1fifth == true)
        {
            map1fifth = false;
            map1sixth = true;
        }
        else if (transform.position.x > 50 && map1sixth == true)
        {
            map1sixth = false;
            map1seventh = true;
        }
        else if (transform.position.y > 10 && map1seventh == true)
        {
            map1seventh = false;
            map1eight = true;
        }
        else if (transform.position.x > 85.5)
        {
            map1eight = false;
        }



        if (map1first || map1fifth)
        {
            Down();
        }
        else if (map1second || map1fourth || map1sixth || map1eight)
        {
            Right();
        }
        else if (map1third || map1seventh)
        {
            Up();
        }
    }

	void Right(){
		float xCoord = transform.position.x + Time.deltaTime * speed;
		transform.position = new Vector3(xCoord, transform.position.y, transform.position.z);
	}

	void Down(){
		float yCoord = transform.position.y - Time.deltaTime * speed;
		transform.position = new Vector3(transform.position.x, yCoord, transform.position.z);
	}

	void Up(){
		float yCoord = transform.position.y + Time.deltaTime * speed;
		transform.position = new Vector3(transform.position.x, yCoord, transform.position.z);
	}
}
