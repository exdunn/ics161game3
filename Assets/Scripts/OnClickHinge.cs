using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickHinge : MonoBehaviour {


	void OnMouseDown(){
		GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;
		GetComponent<HingeJoint2D> ().enabled = true;
	}
}
