using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetting : MonoBehaviour
{
    public StageLevel _StageLevel;
    private const float fixedX = 0.7f;
    private const float fixedZ = 1f;

    private void Start()
    {
        SetPosition();
    }

    private void SetPosition()
    {
        float xPos = (_StageLevel.horzCardNum - 1) * fixedX * 0.5f;
        float zPos = (_StageLevel.vertCardNum - 1) * fixedZ * 0.5f;
        float yPos = gameObject.transform.position.y;
        float fixedY = 0.5f;

        Vector3 cameraPos = gameObject.transform.position;

        if (_StageLevel.stageLevel != 1)
        {
            float tanValue = Mathf.Tan(60 * Mathf.PI / 180);
            yPos = (xPos + fixedY) * tanValue;
        }

        
        cameraPos += Vector3.right * xPos;
        cameraPos += Vector3.forward * zPos;
        cameraPos.y = yPos;

        gameObject.transform.position = cameraPos;
    }
}
