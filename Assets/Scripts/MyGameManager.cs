using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyGameManager : MonoBehaviour {

    public GameObject menu;
    private int mapNumber;

	// Use this for initialization
	void Start () {
        mapNumber = SceneManager.GetActiveScene().buildIndex;
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
        SceneManager.LoadScene(mapNumber);
    }


    // go to main menu
    public void ExitClick()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
