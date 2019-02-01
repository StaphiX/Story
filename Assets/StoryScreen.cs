﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityExtentions;

public enum EStoryScreenState
{
    EShowAll,
    EStoryOpen,
    EPlotOpen
}

[System.Serializable] public class StorySelectedEvent : UnityEvent<StoryTile> { }

public class StoryScreen : BaseScreen
{
    public static StorySelectedEvent storySelectedEvent = new StorySelectedEvent();

    EStoryScreenState eState = EStoryScreenState.EShowAll;

    StoryTile selectedStory = null;

    protected override void AddEvents()
    {
        base.AddEvents();
        storySelectedEvent.AddListener(StorySelected);
    }

    protected override void RemoveEvents()
    {
        base.RemoveEvents();
        storySelectedEvent.RemoveListener(StorySelected);
    }

    void Start()
    {
        EStoryScreenState eState = EStoryScreenState.EShowAll;
    }

    void Update()
    {
        
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

        Debug.Log("StorySelected: " + storyTile.ToStringValues());
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
