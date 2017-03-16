using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyGameManager : MonoBehaviour {

    public GameObject menu;
    private int mapNumber;

	// Use this for initialization
	void Start () {
        // find which map is being played
        mapNumber = GameObject.
            FindGameObjectWithTag("MainCamera").
            GetComponent<MoveCamera>().
            mapNumber;
	}
	
	// Update is called once per frame
	void Update () {
        MenuOpenClose();
	}

    // open in game menu
    void MenuOpenClose ()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (!menu.activeSelf)
                menu.SetActive(true);
            else
                menu.SetActive(false);
        }
    }

    // restart level
    public void RestartClick ()
    {
        if (mapNumber == 1)
            SceneManager.LoadScene("Main Scene");
        else if (mapNumber == 2)
            SceneManager.LoadScene("Poof");
        else if (mapNumber == 3)
            SceneManager.LoadScene("Alex Level");
    }


    // go to main menu
    public void ExitClick()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
