using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickGun : MonoBehaviour {

	public GameObject bullet;
	public int directionNum; //0 = right, 1 = down, etc
	private bool canFire;

	void Start()
	{
		canFire = true;
	}

	void OnMouseDown(){
		if (canFire) {
			GameObject bulletObj = Instantiate (bullet, transform.position, Quaternion.identity);
			bulletObj.GetComponent<Bullet> ().setDirection (directionNum);
			canFire = false;
			StartCoroutine (Cooldown ());
		}
	}

	IEnumerator Cooldown() //Cooldown for gun.
	{
		yield return new WaitForSeconds (1);
		canFire = true;
	}
}
