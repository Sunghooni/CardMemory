using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishManager : MonoBehaviour
{
    [Header("Reference")]
    public StageManager _StageManager;
    public ScoreManager _ScoreManager;
    public PlayUI ScoreUI;
    public PlayUI StageUI;
    public PlayUI TimerUI;

    [Header("Asset")]
    public GameObject endPanel;
    public Light mainLight;

    private readonly float showResaultsDelay = 0.5f;

    public void ShowPlayResault()
    {
        SoundManager.instance.PlayClearSound();
        Invoke(nameof(ShowEndUI), showResaultsDelay);
        Invoke(nameof(SaveBestScore), showResaultsDelay);
    }

    private void ShowEndUI()
    {
        ScoreUI.FinishMotion();
        StageUI.FinishMotion();
        TimerUI.FinishMotion();

        endPanel.SetActive(true);
        mainLight.intensity = 0;
    }

    private void SaveBestScore()
    {
        int stageLevel = _StageManager.stageLevel;
        float nowScore = _ScoreManager.GetComponent<ScoreManager>().playScore;
        float timer = TimerUI.GetComponent<TimerUI>().leftTime;
        RankData rank = DataManager.LoadData();

        Record record = new Record
        {
            stageLevel = stageLevel,
            score = nowScore,
            timer = timer
        };

        if (rank == null || rank.records[stageLevel - 1] == null)
        {
            DataManager.SaveRecord(record);
        }
        else if (rank.records[stageLevel - 1].score < nowScore)
        {
            DataManager.SaveRecord(record);
        }
        else if (rank.records[stageLevel - 1].score == nowScore)
        {
            if (rank.records[stageLevel - 1].timer < timer)
            {
                DataManager.SaveRecord(record);
            }
        }
    }
}
