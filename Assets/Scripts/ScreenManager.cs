using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityExtentions;

public class ScreenManager
{
    GameObject screenManagerGO = null;

    List<BaseScreen> screenStack = new List<BaseScreen>();

    public void Init()
    {
        RectTransformData rectTransform = RectTransformExtention.FromPosition(0, 0, AnchorPreset.StretchAll);
        screenManagerGO = new GameObject("ScreenManager", typeof(RectTransform));
        screenManagerGO.transform.SetParent(Main.UIManager.GetCanvas().transform);
        RectTransform screenManagerTransform = screenManagerGO.GetComponent<RectTransform>();
        screenManagerTransform.Set(rectTransform);

        InstantiateScreen("ScreenStoryboard");
    }

    public void InstantiateScreen(string screen)
    {
        RectTransformData rectTransform = RectTransformExtention.FromPosition(0, 0, AnchorPreset.StretchAll);
        GameObject screenGo = Main.UIManager.InstantiateUI("Screens/" + screen, rectTransform, screenManagerGO.transform);

        screenStack.Add(screenGo.GetComponent<BaseScreen>());
    }

    public void SendMessage<T>(T data)
    {

    }
}
