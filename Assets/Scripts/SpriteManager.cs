using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class SpriteManager
{
    private List<SpriteAtlas> spriteAtlasList = new List<SpriteAtlas>();

    public void Init()
    {
        SpriteAtlas[] spriteAtlases = Resources.LoadAll<SpriteAtlas>("Textures/Atlas");

        foreach (SpriteAtlas spriteAtlas in spriteAtlases)
        {
            spriteAtlasList.Add(spriteAtlas);
        }
    }

    public Sprite LoadSprite(string imageName)
    {
        foreach (SpriteAtlas spriteAtlas in spriteAtlasList)
        {
            Sprite sprite = spriteAtlas.GetSprite(imageName);

            if (sprite != null)
                return sprite;
        }

        return null;
    }
}
