using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSelectForPC : MonoBehaviour
{
    public CompareCardPair _CompareCardPair;
    public FinishCheck _FinishCheck;

    private void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (!CheckIsInputable()) return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                if (hit.transform.CompareTag("PokerCard"))
                {
                    SelectCard(hit.transform.gameObject);
                }
            }
        }
    }

    private void SelectCard(GameObject card)
    {
        CardAnimation animation = card.GetComponent<CardAnimation>();

        if(!animation.isMotionPlaying)
        {
            animation.StartCoroutine("RotateCardMotion");

            if(_CompareCardPair.firstCard == null)
            {
                _CompareCardPair.firstCard = card;
            }
            else
            {
                _CompareCardPair.secondCard = card;
            }    
        }
    }

    private bool CheckIsInputable()
    {
        if (_FinishCheck.isFinished)
        {
            return false;
        }
        if (_CompareCardPair.firstCard != null && _CompareCardPair.secondCard != null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
