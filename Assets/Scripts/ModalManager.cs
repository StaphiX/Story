using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityExtentions;

public class ModalManager
{
    GameObject modalManagerGO = null;

    List<BaseModal> modalStack = new List<BaseModal>();

    public void Init()
    {
        modalManagerGO = new GameObject("ModalManager", typeof(RectTransform));
        modalManagerGO.transform.SetParent(Main.UIManager.GetCanvas().transform);
        RectTransform modalManagerTransform = modalManagerGO.GetComponent<RectTransform>();
        modalManagerTransform.Set(0, 0, 0, 0, AnchorPreset.StretchAll);
    }

    public RectTransform OpenModal(string modal)
    {
        RectTransform modalTransform = Main.UIManager.InstantiateUI("Modal/" + modal, modalManagerGO.transform);

        BaseModal baseModal = modalTransform.GetComponent<BaseModal>();
        modalStack.Add(baseModal);

        return modalTransform;
    }
}
