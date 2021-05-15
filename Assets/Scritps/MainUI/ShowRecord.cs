using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowRecord : MonoBehaviour
{
    public void SetText(Record record)
    {
        if (record == null) return;

        GameObject score = gameObject.transform.GetChild(1).GetChild(0).gameObject;
        GameObject timer = gameObject.transform.GetChild(2).GetChild(0).gameObject;

        score.GetComponent<TextMeshProUGUI>().text = record.score.ToString() + "P";
        timer.GetComponent<TextMeshProUGUI>().text = Mathf.Round(record.timer).ToString() + "Sec";
    }
}
