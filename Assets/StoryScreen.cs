using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using UnityEngine.UI;
using UnityExtentions;

public enum EStoryScreenState
{
    EShowAll,
    EStoryOpen,
    EPlotOpen
}

[System.Serializable] public class StorySelectedEvent : UnityEvent<StoryTile> { }
[System.Serializable] public class StoryIconSelectedEvent : UnityEvent<string> { }

public class StoryScreen : BaseScreen
{
    public static StorySelectedEvent storySelectedEvent = new StorySelectedEvent();
    public static StoryIconSelectedEvent storyIconSelectedEvent = new StoryIconSelectedEvent();

    EStoryScreenState eState = EStoryScreenState.EShowAll;

    ScrollRect scrollView = null;
    StoryTile selectedStory = null;

    protected override void AddEvents()
    {
        base.AddEvents();
        storySelectedEvent.AddListener(StorySelected);
        storyIconSelectedEvent.AddListener(StoryIconSelected);
    }

    protected override void RemoveEvents()
    {
        base.RemoveEvents();
        storySelectedEvent.RemoveListener(StorySelected);
        storyIconSelectedEvent.RemoveListener(StoryIconSelected);
    }

    private void Awake()
    {
        eState = EStoryScreenState.EShowAll;

        scrollView = GetComponentInChildren<ScrollRect>();
        if(scrollView == null)
        {
            Debug.Log("StoryScreen is missing child ScrollRect");
            return;
        }

        List<StoryData> storyData = Main.storyDataManager.GetStoryData();
        if(storyData.Count <= 0)
        {
            AddNewStoryTile();
        }
        else
        {
            foreach(StoryData data in storyData)
            {
                AddStoryTile(data);
            }
        }
    }

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void AddNewStoryTile()
    {
        Debug.Log("Add New Story Tile");
        RectTransform content = scrollView.content;

        RectTransform tileTransfrom = Main.UIManager.InstantiateUI("UI/StoryTile", content);
        tileTransfrom.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 50, tileTransfrom.sizeDelta.y);

        StoryTile storyTile = tileTransfrom.GetComponent<StoryTile>();
        if (storyTile != null)
            storyTile.SetStoryData(Main.storyDataManager.NewStory());
    }

    public void AddStoryTile(StoryData data)
    {
        Debug.Log("Add Story Tile");
        RectTransform content = scrollView.content;
        float contentY = content.anchoredPosition.y;

        RectTransform tileTransfrom = Main.UIManager.InstantiateUI("UI/StoryTile", content);
        tileTransfrom.anchoredPosition = new Vector2(0, contentY);

        StoryTile storyTile = tileTransfrom.GetComponent<StoryTile>();
        if (storyTile != null)
            storyTile.SetStoryData(data);
    }

    public void StorySelected(StoryTile storyTile)
    {
        selectedStory = storyTile;

        switch (eState)
        {
            case EStoryScreenState.EShowAll:
                SetState(EStoryScreenState.EStoryOpen);
                break;
            case EStoryScreenState.EStoryOpen:
                SetState(EStoryScreenState.EShowAll);
                break;
            case EStoryScreenState.EPlotOpen:
                SetState(EStoryScreenState.EShowAll);
                break;
            default:
                break;
        }  

        Debug.Log("StorySelected: " + storyTile.GetStoryData().ToStringValues());
    }

    public void StoryIconSelected(string imageName)
    {
        if (eState != EStoryScreenState.EStoryOpen || selectedStory == null)
            return;

        selectedStory.SetIcon(imageName);
    }

    public void SetState(EStoryScreenState eState)
    {
        switch(eState)
        {
            case EStoryScreenState.EShowAll:
                break;
            case EStoryScreenState.EStoryOpen:
                break;
            case EStoryScreenState.EPlotOpen:
                break;
            default:
                break;
        }

        this.eState = eState;
    }
}
