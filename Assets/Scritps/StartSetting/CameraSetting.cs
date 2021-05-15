using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetting : MonoBehaviour
{
    public StageManager _StageManager;

    private void Start()
    {
        SetPosition();
    }

    private void SetPosition()
    {
        gameObject.transform.position = _StageManager.cameraPosition;
    }
}
