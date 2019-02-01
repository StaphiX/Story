using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScreen : MonoBehaviour
{
    void OnEnable()
    {
        AddEvents();
    }

    // Update is called once per frame
    void OnDisable()
    {
        RemoveEvents();
    }

    protected virtual void AddEvents()
    {

    }

    protected virtual void RemoveEvents()
    {

    }
}
