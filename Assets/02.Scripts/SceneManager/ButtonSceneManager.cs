using Microsoft.Win32;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;

public class ButtonSceneManager : MonoBehaviour
{
    public string sceneName;
    DictationRecognizer dictationRecognizer;
    public RegistryKey rkey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Speech_OneCore\Settings\SpeechRecognizer", true);
    public void UsOnButtonClick()
    {
        rkey.SetValue("RecognizedLanguage", "en-us");
        SceneManager.LoadSceneAsync(sceneName);
        Debug.Log(sceneName + "로 이동합니다.");
    }
    public void JpOnButtonClick()
    {
        rkey.SetValue("RecognizedLanguage", "ja");
        SceneManager.LoadSceneAsync(sceneName);
        Debug.Log(sceneName + "로 이동합니다.");
    }
}