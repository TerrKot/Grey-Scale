using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject musicOn, musicOff, mainAudio;
    public SpriteRenderer backGround;
    public SpriteRenderer image;

    private void Start()
    {
        if (gameObject.name == "Music")
        {
            if (PlayerPrefs.GetString("Music") == "No")
            {
                musicOn.SetActive(false);
                musicOff.SetActive(true);
                mainAudio.GetComponent<AudioListener>().enabled = false;
            }
            else
            {
                musicOn.SetActive(true);
                musicOff.SetActive(false);
                mainAudio.GetComponent<AudioListener>().enabled = true;
            }
        }
    }
    private void OnMouseDown()
    {
        transform.localScale = new Vector3(transform.localScale.x + 1f, transform.localScale.y + 1f, transform.localScale.z + 1f);
        backGround.enabled = false;
        image.color = Color.black;
    }
    private void OnMouseUp()
    {
        transform.localScale = new Vector3(transform.localScale.x - 1f, transform.localScale.y - 1f, transform.localScale.z - 1f);
        backGround.enabled = true;
        image.color = Color.white;
    }

    private void OnMouseUpAsButton()
    {
        if (PlayerPrefs.GetString("Music") != "No")
            GameObject.Find("Click Audio").GetComponent<AudioSource>().Play();
        switch (gameObject.name)
        {
            case "Play":
                SceneManager.LoadScene("Play");
                break;
            case "AppStore":
                Application.OpenURL("http://google.com");
                break;
            case "Exit":
                SceneManager.LoadScene("Main");
                break;
            case "Reply":
                SceneManager.LoadScene("Play");
                break;
            case "Close":
                SceneManager.LoadScene("Main");
                break;
            case "HowTo":
                SceneManager.LoadScene("HowTo");
                break;
            case "Music":
                if (PlayerPrefs.GetString("Music") != "No")
                {
                    PlayerPrefs.SetString("Music", "No");
                    musicOn.SetActive(false);
                    musicOff.SetActive(true);
                    GameObject.Find("Main Audio").GetComponent<AudioListener>().enabled = false;

                }
                else
                {
                    PlayerPrefs.SetString("Music", "Yes");
                    musicOn.SetActive(true);
                    musicOff.SetActive(false);
                    GameObject.Find("Main Audio").GetComponent<AudioListener>().enabled = true;
                }
                break;
        }
    }
}
