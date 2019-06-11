using UnityEngine;

/// <summary>
/// This class is used to get a certain food type 
/// </summary>
public class FoodEnums
{
    public enum FoodType
    {
        Nut,
        Strawberry,
        Blueberry,
    }

    public static FoodType GetRandomFood()
    {
        return (FoodType)Random.Range(0, 3);
    }
}
