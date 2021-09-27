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
        StartCoroutine(kakao());
    }

    public void click2()
    {
        //LINK = "寿司盛り合わせください";
        LINK = "c_lt_shinji_2.1.10_0-nvoice_shinji_2.1.10_d2ad418645a667f9d265f3e3ac7a6d16-1632754314200";
        StartCoroutine(papago());
    }

    public void click3()
    {
        LINK = "かしこまりました";
        StartCoroutine(kakao());
    }

    public void click4()
    {
        //LINK = "いただきます";
        LINK = "c_lt_shinji_2.1.10_1-nvoice_shinji_2.1.10_6b1bf127bf30adcdde99bb1ccf8e6eb9-1632754679338";
        StartCoroutine(papago());
    }


    IEnumerator kakao()
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

    IEnumerator papago()
    { 
        string url = "https://papago.naver.com/apis/tts/" + LINK;
        WWW www = new WWW(url);
        while (!www.isDone)
        {
            yield return 0;
        }
        GetComponent<AudioSource>().clip = NAudioPlayer.FromMp3Data(www.bytes);
        audioSource.Play();
    }
}
