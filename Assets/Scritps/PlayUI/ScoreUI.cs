using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public ScoreManager _ScoreManager;
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
}
