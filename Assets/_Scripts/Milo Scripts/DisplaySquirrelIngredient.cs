﻿using UnityEngine;
using UnityEngine.UI;

public class DisplaySquirrelIngredient : MonoBehaviour
{
    public SpriteRenderer _ingredientSprite;
    private SquirrelController _squirrelController;

    private void Awake()
    {
        //_ingredientSprite = GetComponent<SpriteRenderer>();
        _squirrelController = GetComponent<SquirrelController>();
    }

    private void Start()
    {
        DisplayIngredient();
    }

    public void DisplayIngredient()
    {
        Sprite food = SpriteDataManager.instance.GetFoodSpriteFromList((int) _squirrelController.GetPreferredFoodType());
        _ingredientSprite.sprite = food;
    }
    
}
