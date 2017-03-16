using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
    // load level one
    public void OnLevelOneClick ()
    {
        SceneManager.LoadScene("Main Scene");
    }

    // load level two
    public void OnLevelTwoClick()
    {
        SceneManager.LoadScene("Poof");
    }

    // load level three
    public void OnLevelThreeClick()
    {
        SceneManager.LoadScene("Alex Level");
    }
}
