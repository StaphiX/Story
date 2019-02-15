using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footer : MonoBehaviour
{
    public ImageButtonSelected onAddNewSelected = new ImageButtonSelected();

    ImageButton addNewButton;

    // Start is called before the first frame update
    void Start()
    {
        addNewButton = transform.Find("AddNew").GetComponent<ImageButton>();

        addNewButton.onSelected.AddListener(AddNewSelected);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddNewSelected(ImageButton imageButton)
    {
        onAddNewSelected.Invoke(imageButton);
    }
}
