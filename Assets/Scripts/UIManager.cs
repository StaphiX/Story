using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityExtentions;

public class UIManager
{
    ScreenManager screenManager = new ScreenManager();
    Canvas UICanvas = null;
    Vector2 UIReferenceRes = new Vector2(2732, 2048);

    public UIManager()
    {

    }

    public Canvas GetCanvas()
    {
        return UICanvas;
    }

    public float GetWidth()
    {
        return UIReferenceRes.x;
    }

    public float GetHeight()
    {
        return UIReferenceRes.y;
    }

    public Vector2 GetReferenceRes()
    {
        return UIReferenceRes;
    }

    public void Init()
    {
        UICanvas = GameObject.FindObjectOfType<Canvas>();
        CanvasScaler scaler = UICanvas.GetComponent<CanvasScaler>();
        UIReferenceRes = scaler.referenceResolution;

        screenManager.Init();
    }

    public GameObject InstantiateUI(string prefabName, RectTransformData rectTransformData, Transform parent = null)
    {
        GameObject prefab = Resources.Load<GameObject>(prefabName);
        GameObject UIObject = GameObject.Instantiate(prefab);
        UIObject.name = prefab.name;

        if (parent != null)
            UIObject.transform.SetParent(parent);
        else if (UICanvas != null)
            UIObject.transform.SetParent(UICanvas.transform);
        else
            Debug.Log("Missing Canvas");

        RectTransform rectTrasform = UIObject.GetComponent<RectTransform>();
        rectTrasform.Set(rectTransformData);

        return UIObject;
    }
}
