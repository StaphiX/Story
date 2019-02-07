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
        screenManagerGO = new GameObject("ScreenManager", typeof(RectTransform));
        screenManagerGO.transform.SetParent(Main.UIManager.GetCanvas().transform);
        RectTransform screenManagerTransform = screenManagerGO.GetComponent<RectTransform>();
        screenManagerTransform.Set(0, 0, 0, 0, AnchorPreset.StretchAll);

        InstantiateScreen("ScreenStoryboard");
    }

    public RectTransform InstantiateScreen(string screen)
    {
        RectTransform screenTransform = Main.UIManager.InstantiateUI("Screens/" + screen, screenManagerGO.transform);
        screenTransform.Set(0, 0, 0, 0, AnchorPreset.StretchAll);

        BaseScreen baseScreen = screenTransform.gameObject.GetComponent<BaseScreen>();
        screenStack.Add(baseScreen);

        return screenTransform;
    }
}
