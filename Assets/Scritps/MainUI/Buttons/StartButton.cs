﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public GameObject rankButton;
    public GameObject stageSelectButtons;

    public void StartButtonOnClick()
    {
        gameObject.SetActive(false);
        rankButton.SetActive(false);
        stageSelectButtons.SetActive(true);
    }
}
