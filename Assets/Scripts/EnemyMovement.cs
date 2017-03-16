using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public Vector2 velocity;
    public bool onGround;
    public bool forward;

    private bool hitwall;
    private Vector3 rbpos;
    private float endpos_xLeft;
    private float endpos_xRight;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        hitwall = false;
        onGround = false;
        velocity = new Vector2(3, 0);
        rb = GetComponent<Rigidbody2D>();
        rbpos = rb.position;
        endpos_xLeft = rbpos.x - 1f;
        endpos_xRight = rbpos.x + 1f;
        forward = true;
    }
	
    void FixedUpdate()
    {
        if (onGround && forward)
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        if (onGround && !forward)
            rb.MovePosition(rb.position - velocity * Time.fixedDeltaTime);
        if (rb.position.x <= endpos_xLeft && onGround)
            forward = true;
        if (rb.position.x >= endpos_xRight && onGround)
            forward = false;

    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().curHealth -= 2;
            this.gameObject.SetActive(false);
        }
        else if (c.gameObject.tag == "Inside Walls")
        {
            if (rb.position.x > rbpos.x)
                endpos_xRight = rb.position.x - 0.01f;
            else if(rb.position.x < rbpos.y)
                endpos_xLeft = rb.position.x + 0.01f;
        }
        else if (c.gameObject.tag != "Bullet" || c.gameObject.tag != "Gun")
            onGround = true;
    }

    void OnCollisionExit2D(Collision2D c)
    {
        if (c.gameObject.tag == "Wall")
            onGround = false;
    }
}
