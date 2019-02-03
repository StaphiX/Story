using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;
using UnityExtentions;

public class StoryTile : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    StoryData storyData;

    private int iPressTime = 0;

    public UnityEvent onClick;

    private void Awake()
    {
        //SetTile();
    }

    //void SetTile();
    //{
    //    StoryManager.GetStory(storyID);
    //}

    public void OnPointerDown(PointerEventData eventData)
    {
        iPressTime = Time.frameCount;
        Debug.Log("Tile Pressed");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        int iHoldTime = Time.frameCount - iPressTime;
        Debug.Log("Tile Released: " + iHoldTime.ToString());
        iPressTime = 0;

        StoryScreen.storySelectedEvent.Invoke(this);
    }
}
