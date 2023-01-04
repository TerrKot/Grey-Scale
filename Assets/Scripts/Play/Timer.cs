using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Color color, deafultColor;
    public GameObject mainCube;
    private Color lastColor;

    private void Start()
    {
        lastColor = mainCube.GetComponent<Renderer>().material.color;
    }

    private void Update()
    {
        if (!mainCube.GetComponent<GameCntrl>().lose)
        {
            if (transform.localScale.x <= 0.02f)
            {
                Destroy(gameObject);
            }
            if (transform.localScale.x < 6.01f)
            {
                GetComponent<Renderer>().material.color = Color.Lerp(GetComponent<Renderer>().material.color, color, Time.deltaTime);
                transform.localScale -= new Vector3(0.01f, 0f, 0f);
            }
        }
        if (mainCube.GetComponent<Renderer>().material.color != lastColor)
        {
            lastColor = mainCube.GetComponent<Renderer>().material.color;
            transform.localScale = new Vector3(6, 1, 1);
            GetComponent<Renderer>().material.color = deafultColor;
        }
    }
    private void OnDestroy()
    {
        if (mainCube)
        {
            mainCube.GetComponent<GameCntrl>().lose = true;
        }
    }
}
