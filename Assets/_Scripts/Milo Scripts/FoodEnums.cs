using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class FoodEnums : MonoBehaviour
{
    private static Food _food;
    
    public enum Food
    {
        Nut,
        Apple,
        Cranberry
    }

    public Food GetRandomFood()
    {
        _food = (Food)Random.Range(0, 3);
        return _food;
    }

}
