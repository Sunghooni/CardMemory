using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float playScore = 0;

    private const float onePairScore = 15;
    private const float failLoseScore = 3;

    public void AddScore()
    {
        playScore += onePairScore;
    }

    public void MinusScore()
    {
        if (playScore >= failLoseScore)
        {
            playScore -= failLoseScore;
        }
    }
}
