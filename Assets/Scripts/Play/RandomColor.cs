using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    public bool main = false, right = false;
    private static Color aColor;
    private float randomColor;

    private void Awake()
    {
        randomColor = Random.Range(0.2f, 0.8f);
        if (main)
        {
            aColor = new Vector4(randomColor, randomColor, randomColor, Random.Range(0.7f, 1f));
        }
    }

    private void Start()
    {
        randomColor = Random.Range(-0.2f, 0.2f);
        if (main || right)
        {
            GetComponent<Renderer>().material.color = aColor;
        }
        else
        {
            GetComponent<Renderer>().material.color = new Vector4(aColor.r + randomColor, aColor.r + randomColor, aColor.r + randomColor, aColor.a);
        }
    }

}
