using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectButton : MonoBehaviour
{
    [Header("Referenece")]
    public StageLevelSO stageLevelSO;

    [Header("StageNumber")]
    public int stageNumber;

    public void StageButtonOnclick()
    {
        stageLevelSO.StageLevel = stageNumber;
        SceneManager.LoadScene("PlayScene");
    }
}
