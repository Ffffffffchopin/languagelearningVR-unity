using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using System.Collections;
using Microsoft.Win32;
using UnityEngine.SceneManagement;

/// <summary>
/// dictation mode is the mode where the PC tries to recognize the speech with out any assistnace or guidance. it is the most clear way.
/// 
/// Hypotethis are thrown super fast, but could have mistakes.
/// Resulted complete phrase will be determined once the person stops speaking. the best guess from the PC will go on the result.
/// 
/// for grammer controls and ruels see here
/// https://www.w3.org/TR/speech-grammar/
/// 
/// added by shachar oz
/// </summary>
public class SpeechToText : MonoBehaviour
{
    public Text ResultedText;
    DictationRecognizer dictationRecognizer;
    [SerializeField] public Image check;
    int count = 0;
    int same = 100;
    public RegistryKey rkey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Speech_OneCore\Settings\SpeechRecognizer", true);

    public class UnityEventString : UnityEngine.Events.UnityEvent<string> { };
    public UnityEventString OnPhraseRecognized;

    public UnityEngine.Events.UnityEvent OnUserStartedSpeaking;

    private bool isUserSpeaking;
    private IEnumerator routine;
    [SerializeField] public Image O;
    [SerializeField] public Image X;
    void Start()
    {
        routine = showResult();
        StartDictationEngine();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            rkey.SetValue("RecognizedLanguage", "en-us");
            dictationRecognizer.Dispose();
            SceneManager.LoadSceneAsync(1);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            rkey.SetValue("RecognizedLanguage", "ja");
            dictationRecognizer.Dispose();
            SceneManager.LoadSceneAsync(1);
        }

    }



    /// <summary>
    /// Hypotethis are thrown super fast, but could have mistakes.
    /// </summary>
    /// <param name="text"></param>
    private void DictationRecognizer_OnDictationHypothesis(string text)
    {
        Debug.LogFormat("Dictation hypothesis: {0}", text);

        if (isUserSpeaking == false) //말할때
        {
            ResultedText.text = "";
            isUserSpeaking = true;
            OnUserStartedSpeaking.Invoke();
        }
    }


    /// <summary>
    /// thrown when engine has some messages, that are not specifically errors
    /// </summary>
    /// <param name="completionCause"></param>
    private void DictationRecognizer_OnDictationComplete(DictationCompletionCause completionCause)
    {
        if (completionCause != DictationCompletionCause.Complete)
        {
            Debug.LogWarningFormat("Dictation completed unsuccessfully: {0}.", completionCause);


            switch (completionCause)
            {
                case DictationCompletionCause.TimeoutExceeded:
                case DictationCompletionCause.PauseLimitExceeded:
                    //we need a restart
                    CloseDictationEngine();
                    StartDictationEngine();
                    break;

                case DictationCompletionCause.UnknownError:
                case DictationCompletionCause.AudioQualityFailure:
                case DictationCompletionCause.MicrophoneUnavailable:
                case DictationCompletionCause.NetworkFailure:
                    //error without a way to recover
                    CloseDictationEngine();
                    break;

                case DictationCompletionCause.Canceled:
                //happens when focus moved to another application 

                case DictationCompletionCause.Complete:
                    CloseDictationEngine();
                    StartDictationEngine();
                    break;
            }
        }
    }

    /// <summary>
    /// Resulted complete phrase will be determined once the person stops speaking. the best guess from the PC will go on the result.
    /// </summary>
    /// <param name="text"></param>
    /// <param name="confidence"></param>
    private void DictationRecognizer_OnDictationResult(string text, ConfidenceLevel confidence)
    {
        Debug.LogFormat("Dictation result: {0}", text);
        if (ResultedText) ResultedText.text += text + "\n";

        Debug.Log("후=" + same);
        if (isUserSpeaking == true) //목소리끝날때
        {
            /*if (string.Compare(text, comment, true) == 0) //같을때
            {
                O.gameObject.SetActive(true);
            }
            else
                X.gameObject.SetActive(true);*/
            StartCoroutine("showResult");
            isUserSpeaking = false;
            OnPhraseRecognized.Invoke(text);
        }
    }


    private void DictationRecognizer_OnDictationError(string error, int hresult)
    {
        Debug.LogErrorFormat("Dictation error: {0}; HResult = {1}.", error, hresult);
    }


    private void OnApplicationQuit()
    {
        CloseDictationEngine();
    }

    private void StartDictationEngine()
    {
        isUserSpeaking = false;

        dictationRecognizer = new DictationRecognizer();

        dictationRecognizer.DictationHypothesis += DictationRecognizer_OnDictationHypothesis;
        dictationRecognizer.DictationResult += DictationRecognizer_OnDictationResult;
        dictationRecognizer.DictationComplete += DictationRecognizer_OnDictationComplete;
        dictationRecognizer.DictationError += DictationRecognizer_OnDictationError;

        dictationRecognizer.Start();
    }

    private void CloseDictationEngine()
    {
        if (dictationRecognizer != null)
        {
            dictationRecognizer.DictationHypothesis -= DictationRecognizer_OnDictationHypothesis;
            dictationRecognizer.DictationComplete -= DictationRecognizer_OnDictationComplete;
            dictationRecognizer.DictationResult -= DictationRecognizer_OnDictationResult;
            dictationRecognizer.DictationError -= DictationRecognizer_OnDictationError;

            if (dictationRecognizer.Status == SpeechSystemStatus.Running)
                dictationRecognizer.Stop();

            dictationRecognizer.Dispose();
        }
    }

    public IEnumerator showResult()
    {

        while (count < 3)
        {
            count++;
            yield return new WaitForSeconds(1f);
        }
        StopCoroutine(routine);
        count = 0;
        O.gameObject.SetActive(false);
        X.gameObject.SetActive(false);
    }
}