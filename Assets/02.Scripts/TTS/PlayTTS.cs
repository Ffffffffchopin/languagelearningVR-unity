using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayTTS : MonoBehaviour
{

    string LINK;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    public void click()
    {
        LINK = "いらっしゃいませ";
        StartCoroutine(DownloadTheAudio());
    }

    public void click2()
    {
        LINK = "寿司盛り合わせください";
        StartCoroutine(DownloadTheAudio());
    }

    public void click3()
    {
        LINK = "かしこまりました";
        StartCoroutine(DownloadTheAudio());
    }

    public void click4()
    {
        LINK = "いただきます";
        StartCoroutine(DownloadTheAudio());
    }


    IEnumerator DownloadTheAudio()
    { //いらっしゃいませ
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
}
