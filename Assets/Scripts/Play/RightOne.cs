using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightOne : MonoBehaviour
{
    private GameObject mainCube;

    private void Start()
    {
        mainCube = GameObject.Find("Main Cube");
    }

    private void OnMouseDown()
    {
        if (GetComponent<Renderer>().material.color == mainCube.GetComponent<Renderer>().material.color)
        {
            mainCube.GetComponent<GameCntrl>().next = true;
        }
        else
        {
            mainCube.GetComponent<GameCntrl>().lose = true;
        }
    }
}
