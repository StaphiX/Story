using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IconModal : BaseModal
{
    IconList iconList;

    protected override void Awake()
    {
        iconList = transform.Find("IconList").GetComponent<IconList>();
    }

    public void Set(UnityAction<ImageButton> onIconSelected)
    {
        if (iconList == null)
            return;

        iconList.onIconSelected.AddListener(onIconSelected);
    }
}
