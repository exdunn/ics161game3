using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickJet : MonoBehaviour {

	public Material active;
	public Material inactive;

	private bool canFire;
	private GameObject flame;


	void Start()
	{
		canFire = true;
		flame = transform.GetChild (0).gameObject;
		flame.SetActive (false);
	}

	void OnMouseDown(){
		if (canFire) {
			flame.SetActive (true);
			canFire = false;
			StartCoroutine (Flame ());
			StartCoroutine (Cooldown ());
		}
	}

	IEnumerator Flame()
	{
		yield return new WaitForSeconds (3);
		flame.SetActive (false);
		GetComponent<Renderer> ().material = inactive;
	}

	IEnumerator Cooldown() //Cooldown for gun.
	{
		yield return new WaitForSeconds (6);
		canFire = true;
		GetComponent<Renderer> ().material = active;
	}
}
