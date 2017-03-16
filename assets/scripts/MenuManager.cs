using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public GameObject instrPnl;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartClick ()
    {
        SceneManager.LoadScene("Level Selection");
    }

    public void InstrClick ()
    {
        instrPnl.SetActive(true);
    }

    public void ExitClick ()
    {
        Application.Quit();
    }

    public void CloseClick ()
    {
        instrPnl.SetActive(false);
    }
}
