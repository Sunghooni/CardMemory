using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCheck : MonoBehaviour
{
    public StageManager _StageManager;

    public bool isFinished = false;
    public bool isTimeOut = false;
    public bool isGameClear = false;

    private float foundCardPair;
    private float totalCardPair;
    private FinishManager _FinishManager;

    private void Awake()
    {
        _FinishManager = gameObject.GetComponent<FinishManager>();
    }

    private void Start()
    {
        totalCardPair = _StageManager.horzCardNum * _StageManager.vertCardNum * 0.5f;
    }

    public void SetTimeOut()
    {
        _FinishManager.ShowPlayResault();
        isFinished = true;
        isTimeOut = true;
    }

    public void AddFoundPair()
    {
        foundCardPair++;

        if (totalCardPair == foundCardPair)
        {
            _FinishManager.ShowPlayResault();
            isFinished = true;
            isGameClear = true;
        }
    }
}
