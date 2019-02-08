using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class IconModal : BaseModal
{
    IconGrid iconGrid;

    protected override void Awake()
    {
        ScrollRect tScroller = transform.Find("IconList").GetComponent<ScrollRect>();
        if (tScroller == null)
            return;

        iconGrid = tScroller.content.Find("IconGrid").GetComponent<IconGrid>();
    }

    public void Set(UnityAction<ImageButton> onIconSelected)
    {
        if (iconGrid == null)
            return;

        iconGrid.onIconSelected.AddListener(onIconSelected);
    }
}
