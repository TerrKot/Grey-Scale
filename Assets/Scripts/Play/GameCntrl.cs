using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCntrl : MonoBehaviour
{
    public GameObject colBlock, panelLost;
    public Vector3[] positions;
    private GameObject block;
    private GameObject[] blocks = new GameObject[4];

    private int rand, count;
    private float rCol, gCol, bCol;
    public Text score;
    private static Color aColor;
    private float randomColor;

    [HideInInspector]
    public bool next, lose;

    void Start()
    {
        count = 0;
        next = false;
        lose = false;
        rand = Random.Range(0, positions.Length);
        for (int i = 0; i < positions.Length; i++)
        {
            blocks[i] = Instantiate(colBlock, positions[i], Quaternion.identity) as GameObject;
            if (rand == i)
                block = blocks[i];
        }
        block.GetComponent<RandomColor>().right = true;
    }

    void Update()
    {
        if (lose)
            playerLose();
        if (next && !lose)
            nextColors();
    }

    void nextColors()
    {
        if (PlayerPrefs.GetString("Music") != "No")
        {
            GetComponent<AudioSource>().Play();
        }
        count++;
        score.text = count.ToString();
        randomColor = Random.Range(0.2f, 0.7f);
        aColor = new Vector4(randomColor, randomColor, randomColor, Random.Range(0.7f, 1f));
        GetComponent<Renderer>().material.color = aColor;
        next = false;

        if (count < 3)
        {
            rCol = -0.2f;
            gCol = 0.3f;
        }
        else if (count >= 3 && count < 5)
        {
            rCol = -0.1f;
            gCol = 0.1f;
        }
        else if (count >= 5)
        {
            rCol = -0.05f;
            gCol = 0.05f;
        }

        // New colors for blocks
        rand = Random.Range(0, positions.Length);
        for (int i = 0; i < positions.Length; i++)
        {
            if (i == rand)
                blocks[i].GetComponent<Renderer>().material.color = aColor;
            else
            {
                randomColor = Random.Range(rCol, gCol);
                float r = aColor.r + randomColor;
                float g = aColor.g + randomColor;
                float b = aColor.b + randomColor;
                blocks[i].GetComponent<Renderer>().material.color = new Vector4(r, g, b, aColor.a);
            }
        }
    }

    void playerLose()
    {
        if (PlayerPrefs.GetInt("Score") < count)
        {
            PlayerPrefs.SetInt("Score", count);
        }
        panelLost.SetActive(true);
    }
}
