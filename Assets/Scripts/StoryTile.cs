using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;
using UnityExtentions;
using UnityEngine.UI;
using TMPro;

public class StoryTile : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    StoryData storyData;

    private int iPressTime = 0;
    public UnityEvent onClick;

    TextMeshProUGUI titleText;
    TextMeshProUGUI descText;
    Image iconImage;


    private void Awake()
    {
        titleText = transform.Find("Title").GetComponent<TextMeshProUGUI>();
        descText = transform.Find("Description").GetComponent<TextMeshProUGUI>();
        iconImage = transform.Find("Icon").GetComponent<Image>();
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

    public void SetStoryData(StoryData data)
    {
        storyData = data;
        if(titleText != null)
        {
            titleText.text = storyData.title;
        }
        if (descText != null)
        {
            descText.text = storyData.description;
        }
        if (iconImage != null)
        {
            Sprite sprite = Main.UIManager.LoadSprite(storyData.icon);
            if(sprite != null)
            {
                iconImage.sprite = sprite;
            }
        }
    }

    public StoryData GetStoryData()
    {
        return storyData;
    }
}
