using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StageLevelSO : ScriptableObject
{
    [SerializeField] private int stageLevel;
    [SerializeField] private int maxSize = 3;
    [SerializeField] private int minSize = 1;

    public int StageLevel
    {
        get { return stageLevel; }

        set
        {
            value = value > maxSize ? maxSize : value;
            value = value < minSize ? minSize : value;
            stageLevel = value;
        }
    }
}
