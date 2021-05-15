using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerUI : PlayUI
{
    [Header("Reference")]
    public StageManager _StageManager;
    public FinishCheck _FinishCheck;
    public GameObject endPosition;

    [Header("Timer")]
    public float leftTime;

    private TextMeshProUGUI tmp;
    private bool isTimerFinished = false;
    private bool isTimerWarning = false;

    private const string basicSentence = "TIMER : ";
    private const string timeUnit = "s";

    private void Awake()
    {
        tmp = gameObject.GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        leftTime = _StageManager.lifeTime;
    }

    private void Update()
    {
        SetTimerUI();
        TimeOutUpdate();
        SetTimerWarning();
    }

    private void SetTimerUI()
    {
        if (isTimerFinished) return;

        leftTime -= Time.deltaTime;
        leftTime = leftTime > 0 ? leftTime : 0;
        tmp.text = basicSentence + Mathf.Round(leftTime).ToString() + timeUnit;
    }

    private void SetTimerWarning()
    {
        if (!isTimerWarning && Mathf.Round(leftTime) <= 5)
        {
            tmp.color = Color.red;
            isTimerWarning = true;
        }
    }

    private void TimeOutUpdate()
    {
        if (!isTimerFinished && leftTime == 0)
        {
            isTimerFinished = true;
            _FinishCheck.SetTimeOut();
            SoundManager.instance.PlayFailSound();
        }
        else if(_FinishCheck.isGameClear)
        {
            isTimerFinished = true;
        }
    }

    public override void FinishMotion()
    {
        gameObject.transform.position = endPosition.transform.position;
        tmp.color = Color.white;
    }
}
