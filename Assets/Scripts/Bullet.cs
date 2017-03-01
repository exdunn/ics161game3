using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public int direction; // 0 For right, 1 for down, etc
	private float moveH;
	private float moveV;

	// Use this for initialization
	void Start () {
		Debug.Log ("START");
		moveH = 0;
		moveV = 0;
	}



	void FixedUpdate()
	{
		if (direction == 0) {
			moveH = 1;
		} else if (direction == 1) {
			moveV = -1;
		} else if (direction == 2) {
			moveH = -1;
		} else if (direction == 3) {
			moveV = 1;
		}

		GetComponent<Rigidbody2D>().velocity = new Vector2 (7 * moveH, 7 * moveV);
	}

	void OnTriggerEnter2D(Collider2D other) //destroy bullet
	{
		if (other.gameObject.CompareTag("Wall"))
		{
			Destroy (this.gameObject);
		}
	}

	public void setDirection(int directionNum) //Set bullet direction
	{
		direction = directionNum;
	}

}
