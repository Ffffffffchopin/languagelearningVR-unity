using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Submit : MonoBehaviour
{
    public Text answer;

    public GameObject O;
    public GameObject X;

    int timer = 5;
    
    public void JpSubmit()
    {
        if (answer.text == "いくら")
        {
            X.SetActive(false);
            O.SetActive(true);

            StartCoroutine(NextScene());
        }

        else
        {
            O.SetActive(false);
            X.SetActive(true);
        }
    }

    public void UsSubmit()
    {
        if (answer.text == "Bread")
        {
            X.SetActive(false);
            O.SetActive(true);

            StartCoroutine(NextScene());
        }

        else
        {
            O.SetActive(false);
            X.SetActive(true);
        }
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(timer);
        SceneManager.LoadScene("Menu");
    }
}
