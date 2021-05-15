using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankBackButton : MonoBehaviour
{
    [Header("Asset")]
    public GameObject startButton;
    public GameObject rankButton;
    public GameObject rankUI;

    public void RankBackButtonOnclick()
    {
        startButton.SetActive(true);
        rankButton.SetActive(true);
        rankUI.SetActive(false);
    }
}
