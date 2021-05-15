using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("Reference")]
    public StageManager _StageManager;

    [Header("Score")]
    public float playScore = 0;

    private float findPairScore;
    private float failLoseScore;

    private void Start()
    {
        findPairScore = _StageManager.findPairScore;
        failLoseScore = _StageManager.failLoseScore;
    }

    public void AddScore()
    {
        playScore += findPairScore;
    }

    public void MinusScore()
    {
        if (playScore >= failLoseScore)
        {
            playScore -= failLoseScore;
        }
    }
}
