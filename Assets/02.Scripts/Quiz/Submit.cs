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

    int timer = 3;
    
    public void submit()
    {
        if (answer.text == "すみません")
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
