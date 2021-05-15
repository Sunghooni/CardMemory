using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static string path = Application.persistentDataPath + "/RankData.json";

    public static void SaveRecord(Record newRecord)
    {
        RankData rankData;

        if(LoadData() == null)
        {
            rankData = new RankData();
        }
        else
        {
            rankData = LoadData();
        }
        
        rankData.records[newRecord.stageLevel - 1] = newRecord;
        string json = JsonUtility.ToJson(rankData, true);

        if (json.Equals("{}"))
        {
            Debug.Log("json null");
            return;
        }
        else
        {
            File.WriteAllText(path, json);
        }
    }

    public static RankData LoadData()
    {
        FileInfo loadfile = new FileInfo(path);

        if (loadfile.Exists == false)
        {
            //when file isn't exist, create it
            File.WriteAllText(path, null);
        }

        string jsonRead = File.ReadAllText(path);
        RankData readData = JsonUtility.FromJson<RankData>(jsonRead);

        return readData;
    }
}
