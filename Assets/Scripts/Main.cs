using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static StoryDataManager storyDataManager = new StoryDataManager();
    public static UIManager UIManager = new UIManager();

    private void Awake()
    {
        storyDataManager.Init();
        UIManager.Init();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
