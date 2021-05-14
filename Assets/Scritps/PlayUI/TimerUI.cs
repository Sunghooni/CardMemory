using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    private TextMeshProUGUI tmp;
    private float leftTime = 60;
    private const string basicSentence = "TIMER : ";
    private const string timeUnit = "s";

    private void Awake()
    {
        tmp = gameObject.GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (leftTime > 0)
        {
            leftTime -= Time.deltaTime;
        }
        else
        {
            leftTime = 0;
        }
        tmp.text = basicSentence + Mathf.Round(leftTime).ToString() + timeUnit;
    }
}
