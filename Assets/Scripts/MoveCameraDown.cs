using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveCameraDown : MonoBehaviour {

    public float speed = 1.0f;
    public GameObject player;
    public Text winlostText;

    private float xpos;
    private float zpos;
    private bool gameover = false;
    private Vector3 camerapos;

	// Use this for initialization
	void Start () {
        xpos = transform.position.x;
        zpos = transform.position.z;
        camerapos = Camera.main.WorldToViewportPoint(transform.position);
	}
	
	// Update is called once per frame
    void Update()
    {
        if(gameover == false)
            Down();
        if(winlostText.text == "GAME OVER")
        {
            gameover = true;
        }

    }

    void Down()
    {
        float yCoord = transform.position.y - Time.deltaTime * speed;
        transform.position = new Vector3(xpos, yCoord, zpos);
    }
}
