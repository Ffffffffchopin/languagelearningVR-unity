﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class afterEat : MonoBehaviour
{
    public static int sushiCount = 0;

    public GameObject diaBar;

    private void Update()
    {
        if(sushiCount==1)
        {
            showBar();
            sushiCount = 0;
        }
    }

    void showBar()
    {
        diaBar.SetActive(true);
        sushiCount = 0;
    }
}
