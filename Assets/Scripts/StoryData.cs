using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class StoryData : IComparable<Guid>
{
    public Guid guid;
    public string title;
    public string icon;
    public string description;

    public List<StoryPlotData> plot = new List<StoryPlotData>();

    public StoryData()
    {
        guid = Guid.NewGuid();
        title = "StoryTitle";
        icon = "iconStory";
        description = "This is a description of the story as a whole";
    }

    public StoryData(Guid guid, string title, string icon, string description)
    {
        this.guid = guid;
        if(this.guid == null)
            this.guid = Guid.NewGuid();
        this.title = title;
        this.icon = icon;
        this.description = description;
    }

    public int CompareTo(Guid guid)
    {
        return this.guid.CompareTo(guid);
    }

    public string GuidString()
    {
        return guid.ToString("D");
    }

    public string GetDataPath()
    {
        return StoryDataManager.storyDataPath + "/" + GuidString() + "_" + title;
    }
}
