using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSelect : MonoBehaviour
{
    public CompareCardPair _CompareCardPair;

    private void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (!CheckIsInputable()) return;

        if (Input.touchCount > 0)
        {
            Touch tempTouchs = Input.GetTouch(0);
            
            if (tempTouchs.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(tempTouchs.position);

                if (Physics.Raycast(ray, out RaycastHit hit, 100f))
                {
                    if (hit.transform.CompareTag("PokerCard"))
                    {
                        SelectCard(hit.transform.gameObject);
                    }
                }
            }
        }
    }

    private void SelectCard(GameObject card)
    {
        CardAnimation animation = card.GetComponent<CardAnimation>();

        if (!animation.isMotionPlaying)
        {
            animation.StartCoroutine("RotateCardMotion");

            if (_CompareCardPair.firstCard == null)
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
