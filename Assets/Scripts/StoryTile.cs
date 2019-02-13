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

    TMP_InputField titleText;
    TMP_InputField descText;
    ImageButton iconButton;

    ImageButton editButton;
    ImageButton crossButton;
    ImageButton tickButton;

    bool bCanEdit = false;
    bool bShowPlot = false;

    public StorySelectedEvent onSelected = new StorySelectedEvent();

    private void Awake()
    {
        titleText = transform.Find("Title").GetComponent<TMP_InputField>();
        descText = transform.Find("Description").GetComponent<TMP_InputField>();
        iconButton = transform.Find("Icon").GetComponent<ImageButton>();
        editButton = transform.Find("Edit").GetComponent<ImageButton>();
        crossButton = transform.Find("Cross").GetComponent<ImageButton>();
        tickButton = transform.Find("Tick").GetComponent<ImageButton>();

        crossButton = transform.Find("Cross").GetComponent<ImageButton>();
        tickButton = transform.Find("Tick").GetComponent<ImageButton>();
        editButton.onSelected.AddListener(EditSelected);
        crossButton.onSelected.AddListener(CrossSelected);
        tickButton.onSelected.AddListener(TickSelected);
        iconButton.onSelected.AddListener(IconSelected);
    }

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
            titleText.textComponent.SetText(storyData.title);
        }
        if (descText != null)
        {
            descText.textComponent.SetText(storyData.description);
        }

        SetIcon(storyData.icon);
    }

    public void IconSelected(ImageButton imageButton)
    {
        if (!bCanEdit)
            return;

        RectTransform modalTransfrom = Main.UIManager.OpenModal("IconModal");
        IconModal iconModal = modalTransfrom.GetComponent<IconModal>();
        iconModal.Set(IconModalCallback);
    }

    public void IconModalCallback(ImageButton imageButton)
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

    public void EditSelected(ImageButton imageButton)
    {
        AllowEdit(true);

    }

    public void TickSelected(ImageButton imageButton)
    {
        FinishEdit(true);
    }

    public void CrossSelected(ImageButton imageButton)
    {
        FinishEdit(false);
    }

    private void AllowEdit(bool bAllow)
    {
        bCanEdit = bAllow;

        titleText.interactable = bAllow;
        descText.interactable = bAllow;

        tickButton.SetActive(bAllow);
        crossButton.SetActive(bAllow);
        editButton.SetActive(!bAllow);
    }

    private void FinishEdit(bool bKeepChanges)
    {
        AllowEdit(false);
    }

    public StoryData GetStoryData()
    {
        return storyData;
    }
}
