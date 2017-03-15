using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickSpin : MonoBehaviour {

    public Material active;
    public Material inactive;

    private bool canClick;
    private bool rotating;
    private float myRotation;
    private float speed = 100.0f;


	// Use this for initialization
	void Start () {

        rotating = false;
        canClick = true;
        myRotation = 0.0f;
	}

    void Update ()
    {
        if (rotating)
        {
            
            transform.Rotate(0, speed * Time.deltaTime, 0);
            myRotation += speed * Time.deltaTime;
            Debug.Log(myRotation);

            if (myRotation >= 360)
            {
                myRotation = 0;
                rotating = false;
            }
        }
    }

    void OnMouseDown ()
    {
        if (canClick)
        {
            canClick = false;
            rotating = true;
            GetComponent<Renderer>().material = inactive;
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown ()
    {
        yield return new WaitForSeconds(5);
        canClick = true;
        GetComponent<Renderer>().material = active;
    }
}
