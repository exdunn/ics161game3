using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int maxHealth = 5;
    public int curHealth = 5;
    public Sprite heart;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // display current health as hearts on screen
    // size of hearts is very large in game window but normal sized in the actual game
    void OnGUI ()
    {
        // resize heart
        float heartScalar = Screen.width / 5000f;
        Debug.Log("wdith: " + Screen.width + "\nheartScalar: " + heartScalar);

        Vector2 size = heart.rect.size * heartScalar;

        for (int i = 0; i < curHealth; i++)
        {
            GUI.DrawTexture(
                new Rect(50 + (i * (size.x * heartScalar + 5)), 60, size.x * heartScalar, size.y * heartScalar), 
                heart.texture
                );
        }
    }

    // add to players current health
    public void AdjustCurHealth(int adj)
    {
        curHealth += adj;
        if (curHealth < 0)
        {
            curHealth = 0;
        }
        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        if (maxHealth < 1)
        {
            maxHealth = 1;
        }
    }
}
