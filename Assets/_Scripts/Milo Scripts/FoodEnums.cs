using UnityEngine;


public class FoodEnums
{
    public enum FoodType
    {
        Nut,
        Apple,
        Cranberry
    }

    public static FoodType GetRandomFood()
    {
        return (FoodType)Random.Range(0, 2);
    }
}
