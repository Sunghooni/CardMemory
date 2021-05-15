using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageUI : PlayUI
{
    [Header("Reference")]
    public StageManager _StageManager;

    [Header("Asset")]
    public GameObject endPosition;

    private TextMeshProUGUI tmp;
    private const string basicSentence = "STAGE : ";

    private void Start()
    {
        tmp = gameObject.GetComponent<TextMeshProUGUI>();
        tmp.text = basicSentence + _StageManager.stageLevel.ToString();
    }

    public void MoveToEndPosition()
    {
        Vector3 toPos = gameObject.transform.GetChild(0).localPosition;
        gameObject.transform.position += toPos;
    }

    public override void FinishMotion()
    {
        gameObject.transform.position = endPosition.transform.position;
    }
}
