using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : PlayUI
{
    [Header("Reference")]
    public ScoreManager _ScoreManager;

    [Header("Asset")]
    public GameObject endPosition;

    private const string basicSentence = "SCORE : ";
    private TextMeshProUGUI tmp;

    private void Awake()
    {
        tmp = gameObject.GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        ShowScore();
    }

    private void ShowScore()
    {
        string scoreSentence = basicSentence + _ScoreManager.playScore.ToString();
        tmp.text = scoreSentence;
    }

    public override void FinishMotion()
    {
        gameObject.transform.position = endPosition.transform.position;
    }
}
