using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;
using UnityExtentions;
using UnityEngine.UI;
using TMPro;

public class IconList : MonoBehaviour
{
    GridLayoutGroup gridGroup;

    private void Awake()
    {
        gridGroup = GetComponent<GridLayoutGroup>();

        LoadAllIcons();
    }

    private void LoadAllIcons()
    {
        LoadIcon("icon_default");
        LoadIcon("icon_mountain");
        LoadIcon("icon_ribbon");
    }

    private void LoadIcon(string imageName)
    {
        RectTransform rectTransform = Main.UIManager.InstantiateUI("UI/ImageBUtton", gridGroup.transform);
        ImageButton imageButton = rectTransform.GetComponent<ImageButton>();
        imageButton.SetSprite(imageName);

        imageButton.onSelected.AddListener(IconSelected);
    }

    private void IconSelected(string icon)
    {
        Debug.Log("Selected icon: " + icon);
    }


}
