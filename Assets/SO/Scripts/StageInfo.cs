using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StageInfo : ScriptableObject
{
    public int horzCardNum;
    public int vertCardNum;
    public float findPairScore;
    public float failLoseScore;
    public float lifeTime;
    public Vector3 cameraPosition;
}
