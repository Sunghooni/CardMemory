using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadRankData : MonoBehaviour
{
    [Header("Asset")]
    public GameObject stage1;
    public GameObject stage2;
    public GameObject stage3;

    private void Awake()
    {
        SpreadData();
    }

    private void SpreadData()
    {
        RankData data = DataManager.LoadData();

        if (data == null) return;

        stage1.GetComponent<ShowRecord>().SetText(data.records[0]);
        stage2.GetComponent<ShowRecord>().SetText(data.records[1]);
        stage3.GetComponent<ShowRecord>().SetText(data.records[2]);
    }
}
