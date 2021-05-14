using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageLevel : MonoBehaviour
{
    public int stageLevel;
    public int vertCardNum;
    public int horzCardNum;

    private void Awake()
    {
        vertCardNum = stageLevel < 3 ? 2 : 3;
        horzCardNum = stageLevel * 2;
    }
}
