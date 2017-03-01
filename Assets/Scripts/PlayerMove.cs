using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour {

	//Player Rigidbody
	public Rigidbody2D playerRB;

	//Movement variables
	private bool canJump;
	private float moveH;
	public float speed;
	public float jump;
	private bool facingLeft = true;

	//Sprites/Text
	public Sprite stillSprite;
	public Sprite jumpSprite;
	public Text WinLoseText;

	//Jump Raycasts
	private RaycastHit2D hit;
	private RaycastHit2D hit2;
	private RaycastHit2D hit3;
	private int layerMask = 1 << 8;

	//Game Variables
	private bool gameOver = false;

	// Use this for initialization
	void Start () {
		canJump = true;
		WinLoseText.text = "";
	}
	
	// Update is called once per frame
	void FixedUpdate () { //Left/Right Movement and calling Jumps

		if (!gameOver) { // Flip the sprite when moving
			if (playerRB.velocity.x < 0 && facingLeft == false) {
				Flip ();
			} else if (playerRB.velocity.x > 0 && facingLeft) {
				Flip ();
			} else if (playerRB.velocity.x == 0) {
			}

			hit = Physics2D.Raycast (transform.position + Vector3.down * 0.65f + Vector3.left * 0.31f, Vector2.down, (float)0.4, layerMask); //Raycast for jump (L)
			hit2 = Physics2D.Raycast (transform.position + Vector3.down * 0.65f + Vector3.right * 0.31f, Vector2.down, (float)0.4, layerMask); //Raycast for jump (R)
			hit3 = Physics2D.Raycast (transform.position + Vector3.down * 0.65f, Vector2.down, (float)0.4, layerMask); //Raycast for jump (MID)
			Debug.DrawRay (transform.position + Vector3.down * 0.65f + Vector3.left * 0.305f, Vector2.down, Color.black);

			moveH = Input.GetAxis ("Horizontal"); //Horizontal Movement
			playerRB.velocity = new Vector2 (speed * moveH, playerRB.velocity.y);

			if (hit.collider != null || hit2.collider != null || hit3.collider != null) { //See if the player can jump
				canJump = true;
				GetComponent<SpriteRenderer> ().sprite = stillSprite;
			} else {
				canJump = false;
				GetComponent<SpriteRenderer> ().sprite = jumpSprite;
			}

			if (Input.GetKeyDown ("up") && canJump) { // Jump, if the player can
				playerRB.velocity = new Vector2 (playerRB.velocity.x, jump);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) //die if hitting out of bounds or bullets or whatever. Currently, just die if hit by anything
	{
		if (other.gameObject.CompareTag ("Death")) {
			WinLoseText.text = "PLAYER 2 WINS!";
			gameOver = true;
		} else if (other.gameObject.CompareTag ("Goal")) {
			WinLoseText.text = "PLAYER 1 WINS!";
			gameOver = true;
		}
	}

	private void Flip(){ //flip the player

		facingLeft = !facingLeft;

		GetComponent<SpriteRenderer> ().flipX = !GetComponent<SpriteRenderer> ().flipX;
	}



}
