﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitSceneManager : MonoBehaviour
{
    public void OnButtonClick()
    {
        Application.Quit();
        Debug.Log("프로그램을 종료합니다.");
    }
}