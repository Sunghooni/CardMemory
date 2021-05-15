using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankButton : MonoBehaviour
{
    public GameObject StartButton;
    public GameObject RankUI;

    public void RankbuttonOnclick()
    {
        gameObject.SetActive(false);
        StartButton.SetActive(false);
        RankUI.SetActive(true);
    }
}
