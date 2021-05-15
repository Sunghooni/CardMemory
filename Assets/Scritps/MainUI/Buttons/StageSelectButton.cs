using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectButton : MonoBehaviour
{
    public StageLevelSO stageLevelSO;
    public int stageNumber;

    public void StageButtonOnclick()
    {
        stageLevelSO.StageLevel = stageNumber;
        SceneManager.LoadScene("PlayScene");
    }
}
