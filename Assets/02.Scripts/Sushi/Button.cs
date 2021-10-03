using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    int now = 0;
    public int endScript;
    public string csvfile;
    public Text origin;
    public Text read;
    public Text korea;
    public GameObject closeButton;
    public GameObject thisButton;
    public GameObject diaBar;
    public GameObject sushi;
    public GameObject okane;
    private Dialog[] dialogs;
    void Start()
    {
        Debug.Log("success");
        parser theParser = new parser();
        dialogs = theParser.Parse(csvfile);
        nextButton();
    }

    // Start is called before the first frame update
    public void nextButton()
    {
        Debug.Log(now);
        
        if (now == endScript - 1)
        {
            close();
        }
        else
        {
            Debug.Log(now);
            if (now == 4)
            {
                sushiShow();
            }
            if (now == 7)
            {
                okaneShow();
            }
            PlayTTS.LINK = dialogs[now].original;
            origin.text = dialogs[now].original;
            read.text = dialogs[now].read;
            korea.text = dialogs[now].korean;
            now++;
        }
    }

    // Update is called once per frame
    public void close()
    {
        closeButton.SetActive(true);
        thisButton.SetActive(false);
    }
    public void sushiShow()
    {
        sushi.SetActive(true);
        diaBar.SetActive(false);
    }
    public void okaneShow()
    {
        okane.SetActive(true);
        diaBar.SetActive(false);
    }
}
