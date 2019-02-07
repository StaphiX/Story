using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;
using UnityExtentions;
using UnityEngine.UI;
using TMPro;

[System.Serializable] public class StorySelectedEvent : UnityEvent<StoryTile> { }

public class StoryTile : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    StoryData storyData;

    private int iPressTime = 0;
    public UnityEvent onClick;

    TextMeshProUGUI titleText;
    TextMeshProUGUI descText;
    ImageButton iconButton;

    public StorySelectedEvent onSelected = new StorySelectedEvent();

    private void Awake()
    {
        titleText = transform.Find("Title").GetComponent<TextMeshProUGUI>();
        descText = transform.Find("Description").GetComponent<TextMeshProUGUI>();
        iconButton = transform.Find("Icon").GetComponent<ImageButton>();

        iconButton.onSelected.AddListener(EditIcon);
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

        onSelected.Invoke(this);

        RectTransform modelTransform = Main.UIManager.OpenModal("IconModal");
        IconModal iconModel = modelTransform.GetComponent<IconModal>();
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

        SetIcon(storyData.icon);
    }

    public void EditIcon(ImageButton imageButton)
    {
        RectTransform modalTransfrom = Main.UIManager.OpenModal("IconModal");
        IconModal iconModal = modalTransfrom.GetComponent<IconModal>();
        iconModal.Set(IconSelected);
    }

    public void IconSelected(ImageButton imageButton)
    {
        SetIcon(imageButton.GetSprite());
    }

    public void SetIcon(string icon)
    {
        if (iconButton != null)
        {
            iconButton.SetSprite(icon);
        }
    }

    public StoryData GetStoryData()
    {
        return storyData;
    }
}
