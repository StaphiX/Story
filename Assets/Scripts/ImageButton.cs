using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[System.Serializable] public class ImageButtonSelected : UnityEvent<string> { }

public class ImageButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public ImageButtonSelected onSelected = new ImageButtonSelected();

    Image image;
    void Awake()
    {
        image = transform.Find("Image").GetComponent<Image>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Button Pressed");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Button Released");

        onSelected.Invoke(image.sprite.name);
    }

    public void SetSprite(string imageName)
    {
        image.sprite = Main.UIManager.LoadSprite(imageName);
    }
}
