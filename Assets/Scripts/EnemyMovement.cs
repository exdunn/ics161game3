using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float speed = 5f;

    private float mypos_x;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        mypos_x = gameObject.transform.position.x;
        Debug.Log(mypos_x);
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(gameObject.transform.position.x, 0) * speed);
    }
	
    void FixedUpdate()
    {
        Debug.Log(gameObject.transform.position.x);
        if (gameObject.transform.position.x > 0)
        {
            if (gameObject.transform.position.x >= mypos_x + 1)
                rb.AddForce(new Vector2(gameObject.transform.position.x, 0) * -speed);
            if (gameObject.transform.position.x <= mypos_x - 1)
                rb.AddForce(new Vector2(gameObject.transform.position.x, 0) * speed);
        }
        else
        {
            if (gameObject.transform.position.x <= mypos_x - 1)
                rb.AddForce(new Vector2(gameObject.transform.position.x, 0) * -speed);
            if (gameObject.transform.position.x >= mypos_x + 1)
                rb.AddForce(new Vector2(gameObject.transform.position.x, 0) * speed);
        }
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().curHealth -= 2;
            this.gameObject.SetActive(false);
        }
        //if (c.gameObject.tag == "Wall")
        //{
        //    speed *= -1.0f;
        //}

    }
}
