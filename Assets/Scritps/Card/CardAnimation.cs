using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAnimation : MonoBehaviour
{
    [Header("CardState")]
    public bool isMotionPlaying = false;
    public bool isCardCoverable = false;
    public bool isCardOpened = false;

    private const float changeDirTime = 0.5f;
    private const float playTime = 1f;
    private Vector3 startPosition;
    private Vector3 startRotation;
    private Vector3 turnedRotation;

    public IEnumerator RotateCardMotion()
    {
        float timer = 0;
        float coverDelay = 0.5f;
        bool isMoveUp = true;

        isMotionPlaying = true;
        startPosition = gameObject.transform.position;
        startRotation = gameObject.transform.eulerAngles;
        turnedRotation = gameObject.transform.eulerAngles + Vector3.forward * 180;

        while (timer < playTime)
        {
            Vector3 moveDir = isMoveUp ? Vector3.up : Vector3.down;
            float moveSpeed = Time.deltaTime * 3;

            timer += moveSpeed;

            if (timer > changeDirTime && isMoveUp)
            {
                moveSpeed += changeDirTime - timer;
                timer = changeDirTime;
                isMoveUp = false;
            }
            else if (timer > playTime)
            {
                moveSpeed += playTime - timer;
                timer = playTime;
            }
            
            transform.Translate(moveDir * moveSpeed, Space.World);
            transform.eulerAngles = Vector3.Lerp(startRotation, turnedRotation, timer);

            yield return new WaitForFixedUpdate();
        }

        transform.position = startPosition;
        isCardOpened = !isCardOpened;

        while (isCardOpened)
        {
            if (isCardCoverable)
            {
                yield return new WaitForSeconds(coverDelay);
                StartCoroutine(RotateCardMotion());

                isCardCoverable = false;
                break;
            }
            yield return new WaitForFixedUpdate();
        }
        
        if (!isCardOpened)
        {
            isMotionPlaying = false;
        }
    }
}
