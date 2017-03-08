using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SpawnObjects : MonoBehaviour {

    private float bombCd = 0;
    private string[] modes;
    private int index = 0;
    private float enemyCd = 0;

    public GameObject bomb;
    public GameObject enemy;
    public Text bombCdText;
    public Text enemyCdText;
    public Text modeText;

	// Use this for initialization
	void Start () {
        modes = new string[2];
        modes[0] = "Bomb";
        modes[1] = "Enemy";
        bombCdText.text = "BombCd: " + bombCd.ToString();
        enemyCdText.text = "EnemyCd: " + enemyCd.ToString();
        modeText.text = "Mode: " + modes[index];
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (index == 0)
                index = 1;
            else
                index -= 1;
            modeText.text = "Mode: " + modes[index];
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (index == 1)
                index = 0;
            else
                index += 1;
            modeText.text = "Mode: " + modes[index];
        }
        if (Input.GetMouseButtonUp(0) && bombCd == 0 && index == 0)
        {
            bombCd = 20;
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
            Instantiate(bomb, new Vector3(ray.origin.x, ray.origin.y, 0), Quaternion.identity);
            bombCdText.text = "BombCd: " + bombCd.ToString();
            StartCoroutine("BombCd");
        }
        if (Input.GetMouseButtonUp(0) && enemyCd == 0 && index == 1)
        {
            enemyCd = 20;
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
            Instantiate(enemy, new Vector3(ray.origin.x, ray.origin.y, 0), Quaternion.identity);
            enemyCdText.text = "EnemyCd: " + enemyCd.ToString();
            StartCoroutine("EnemyCd");
        }
        if (bombCd <= 0)
            StopCoroutine("BombCd");
        if (enemyCd <= 0)
            StopCoroutine("EnemyCd");

    }

    IEnumerator BombCd()
    {
        while (bombCd > 0)
        {
            bombCd--;
            bombCdText.text = "BombCd: " + bombCd.ToString();
            yield return new WaitForSeconds(1.0f);
        }
    }

    IEnumerator EnemyCd()
    {
        while (enemyCd > 0)
        {
            enemyCd--;
            enemyCdText.text = "EnemyCd: " + enemyCd.ToString();
            yield return new WaitForSeconds(1.0f);
        }
    }
}
