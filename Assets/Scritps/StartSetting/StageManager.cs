using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [Header("Asset")]
    public StageLevelSO stageLevelSO;
    public List<StageInfo> stageInfoList;

    [Header("Setting")]
    public int stageLevel;
    public int vertCardNum;
    public int horzCardNum;
    public float findPairScore;
    public float failLoseScore;
    public float lifeTime;
    public Vector3 cameraPosition;

    private void Awake()
    {
        SetStageSetting();
    }

    private void SetStageSetting()
    {
        int listNum = stageLevelSO.StageLevel - 1;
        StageInfo info = stageInfoList[listNum];

        stageLevel = stageLevelSO.StageLevel;
        vertCardNum = info.vertCardNum;
        horzCardNum = info.horzCardNum;

        findPairScore = info.findPairScore;
        failLoseScore = info.failLoseScore;
        lifeTime = info.lifeTime;

        cameraPosition = info.cameraPosition;
    }
}
