using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityExtentions;

public class UIManager
{
    SpriteManager spriteManager = new SpriteManager();
    ScreenManager screenManager = new ScreenManager();
    ModalManager modalManager = new ModalManager();

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

        spriteManager.Init();
        screenManager.Init();
        modalManager.Init();
    }

    public RectTransform InstantiateUI(string prefabName, Transform parent = null)
    {
        GameObject prefab = Resources.Load<GameObject>(prefabName);
        if (prefab == null)
        {
            Debug.Log("Prefab not found - check prefab name");
            return null;
        }

        GameObject UIObject = GameObject.Instantiate(prefab);
        UIObject.name = prefab.name;

        if (parent != null)
            UIObject.transform.SetParent(parent);
        else if (UICanvas != null)
            UIObject.transform.SetParent(UICanvas.transform);
        else
            Debug.Log("Missing Canvas");

        return UIObject.GetComponent<RectTransform>();
    }

    public RectTransform InstantiateImage(string imageName, Transform parent = null)
    {
        RectTransform rectTransform = InstantiateUI("UI/Image", parent);
        Image image = rectTransform.GetComponent<Image>();
        image.sprite = LoadSprite(imageName);

        return rectTransform;
    }

    public Sprite LoadSprite(string imageName)
    {
        return spriteManager.LoadSprite(imageName);
    }

    public RectTransform InstantiateScreen(string prefabName)
    {
        return screenManager.InstantiateScreen(prefabName);
    }

    public RectTransform OpenModal(string modal)
    {
        return modalManager.OpenModal(modal);
    }
}
