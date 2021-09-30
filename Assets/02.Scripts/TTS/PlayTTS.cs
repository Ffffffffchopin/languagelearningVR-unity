using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayTTS : MonoBehaviour
{

    static public string LINK;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    public void click()
    {
        StartCoroutine(japanTTS());
    }

    public void click2()
    {
        StartCoroutine(engTTS());
    }


    IEnumerator japanTTS()
    { 
        string url = "https://tts-translate.kakao.com/read?format=mpeg&lang=ja&txt=" + LINK;
        //string url = "https://tts-translate.kakao.com/newtone?message="+LINK;
        WWW www = new WWW(url);
        while (!www.isDone)
        {
            yield return 0;
        }
        GetComponent<AudioSource>().clip = NAudioPlayer.FromMp3Data(www.bytes);
        audioSource.Play();
    }
    IEnumerator engTTS()
    {
        string url = "https://tts-translate.kakao.com/read?format=mpeg&lang=en&txt=" + LINK;
        //string url = "https://tts-translate.kakao.com/newtone?message="+LINK;
        WWW www = new WWW(url);
        while (!www.isDone)
        {
            yield return 0;
        }
        GetComponent<AudioSource>().clip = NAudioPlayer.FromMp3Data(www.bytes);
        audioSource.Play();
    }

    /*IEnumerator papago()
    { 
        string url = "https://papago.naver.com/apis/tts/" + LINK;
        WWW www = new WWW(url);
        while (!www.isDone)
        {
            yield return 0;
        }
        GetComponent<AudioSource>().clip = NAudioPlayer.FromMp3Data(www.bytes);
        audioSource.Play();
    }*/
}
