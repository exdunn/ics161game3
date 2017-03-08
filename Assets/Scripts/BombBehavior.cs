using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehavior : MonoBehaviour {

    private float bombTimer;
    private bool on = false;

	// Use this for initialization
	void Start () {
        bombTimer = Time.time;
        this.GetComponent<Renderer>().material.color = Color.red;
        on = true;
        StartCoroutine("ChangeColor");
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time > bombTimer + 3.0f)
        {
            on = false;
            this.gameObject.SetActive(false);
        }

    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.tag == "Player")
        {
            Debug.Log("bomb");
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().curHealth -= 2;
            this.gameObject.SetActive(false);
        }
    }

    IEnumerator ChangeColor()
    {
        while (on == true)
        {
            if (this.GetComponent<Renderer>().material.color == Color.red)
                this.GetComponent<Renderer>().material.color = Color.white;
            else
                this.GetComponent<Renderer>().material.color = Color.red;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
