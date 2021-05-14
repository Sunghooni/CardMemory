using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageUI : MonoBehaviour
{
    public StageLevel _StageLevel;
    private TextMeshProUGUI tmp;
    private const string basicSentence = "STAGE : ";

    private void Start()
    {
        tmp = gameObject.GetComponent<TextMeshProUGUI>();
        tmp.text = basicSentence + _StageLevel.stageLevel.ToString();
    }
}
