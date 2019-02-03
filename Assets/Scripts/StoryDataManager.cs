using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityExtentions;

public class StoryDataManager
{
    public static string storyDataPath = "/StoryData";
    public static string storyMasterFile = storyDataPath + "/storyMaster.json";

    List<StoryData> storyData = new List<StoryData>();
    StoryDataComparer storyComparer = new StoryDataComparer();

    public void Init()
    {
        storyDataPath = Application.dataPath + "/StoryData";
        storyMasterFile = storyDataPath + "/storyMaster.json";

        LoadFromDisk();
    }

    public void LoadFromDisk()
    {
        if(!Directory.Exists(storyMasterFile))
        {
            Debug.Log("No Story Master File Found");
            return;
        }

        string storyMaster = File.ReadAllText(storyMasterFile);
        if(storyMaster.Length <= 0)
        {
            Debug.Log("No Story Master File Found");
            return;
        }

        List<string> storyMasterList = JsonUtility.FromJson<List<string>>(storyMasterFile);
        if(storyMasterList.Count > 0)
            storyData.Clear();

        foreach (string fileName in storyMasterList)
        {
            LoadStoryData(fileName);
        }    
    }

    public void SaveToDisk()
    {
        List<string> idList = storyData.Select(z => z.GuidString()).ToList();

        string json = JsonUtility.ToJson(idList, true);
        File.WriteAllText(storyMasterFile, json);

        foreach(StoryData data in storyData)
        {
            SaveStoryData(data);
        }
    }

    public void SaveStoryData(StoryData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(data.GetDataPath(), json);
    }

    public void LoadStoryData(string fileName)
    {
        string json = File.ReadAllText(fileName);
        StoryData data = JsonUtility.FromJson<StoryData>(json);
        InsertStory(data);
    }

    public List<StoryData> GetStoryData()
    {
        return storyData;
    }

    public void InsertStory(StoryData data)
    {
        storyData.BinaryInsert(data, storyComparer);
    }

    public StoryData GetStory(Guid guid)
    {
        return storyData.GetItemByKey(guid);
    }
}

public class StoryDataComparer : IComparer<StoryData>
{
    public int Compare(StoryData x, StoryData y)
    {
        return x.guid.CompareTo(y.guid);
    }
}
