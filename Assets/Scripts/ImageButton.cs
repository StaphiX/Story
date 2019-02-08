using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[System.Serializable] public class ImageButtonSelected : UnityEvent<ImageButton> { }

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

        onSelected.Invoke(this);
    }

    public void SetSprite(string imageName)
    {
        image.sprite = Main.UIManager.LoadSprite(imageName);
        image.sprite.name = imageName;
    }

    public string GetSprite()
    {
        return image.sprite.name;
    }
}
