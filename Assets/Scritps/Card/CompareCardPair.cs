using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompareCardPair : MonoBehaviour
{
    [Header ("Reference")]
    public ScoreManager _ScoreManager;

    [Header ("Selected")]
    public GameObject firstCard;
    public GameObject secondCard;

    private bool isCheckable = false;
    private bool isCompared = false;
    private CardAnimation firstAnimation;
    private CardAnimation secondAnimation;

    private void Update()
    {
        CheckIsCheckable();
        CheckCardPair();
        CheckCardCovered();
    }

    private void CheckIsCheckable()
    {
        if (firstCard != null && secondCard != null)
        {
            firstAnimation = firstCard.GetComponent<CardAnimation>();
            secondAnimation = secondCard.GetComponent<CardAnimation>();
            isCheckable = true;
        }
        else
        {
            isCheckable = false;
            isCompared = false;
        }
    }

    private void CheckCardPair()
    {
        if (isCheckable)
        {
            if (firstAnimation.isCardOpened && secondAnimation.isCardOpened)
            {
                if (!firstCard.name.Equals(secondCard.name) && !isCompared)
                {
                    isCompared = true;
                    firstAnimation.isCardCoverable = true;
                    secondAnimation.isCardCoverable = true;
                    _ScoreManager.MinusScore();
                }
                else if (firstCard.name.Equals(secondCard.name))
                {
                    firstCard = null;
                    secondCard = null;
                    _ScoreManager.AddScore();
                }
            }
        }
    }

    private void CheckCardCovered()
    {
        if (isCheckable)
        {
            if (!firstAnimation.isMotionPlaying && !secondAnimation.isMotionPlaying)
            {
                firstCard = null;
                secondCard = null;
            }
        }
    }
}
