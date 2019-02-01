using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;
using UnityExtentions;

public class StoryTile : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Guid storyID;
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

        return;

        RectTransformData rectData = new RectTransformData(GetComponent<RectTransform>());
        rectData.anchoredPosition.y -= rectData.sizeDelta.y;

        Main.UIManager.InstantiateUI("UI/StoryTile", rectData, transform.parent);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        int iHoldTime = Time.frameCount - iPressTime;
        Debug.Log("Tile Released: " + iHoldTime.ToString());
        iPressTime = 0;

        StoryScreen.storySelectedEvent.Invoke(this);
    }
}
