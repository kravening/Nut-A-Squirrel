using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class handles returns the sprites for the different foods 
/// </summary>
public class SpriteDataManager : MonoBehaviour
{
    public static SpriteDataManager instance { get; private set; }

    /// <summary>
    /// holds the sprites of the different ingredients, the sprites must be ordered in the same order as the foodList enum.
    /// </summary>
    public List<Sprite> foodSpriteList = new List<Sprite>();

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }

    public Sprite GetFoodSpriteFromList(int index)
    {
        if (index > foodSpriteList?.Count)
        {
            //fallback sprite
            return foodSpriteList[0];
        }

        return foodSpriteList[index];
    }


}
