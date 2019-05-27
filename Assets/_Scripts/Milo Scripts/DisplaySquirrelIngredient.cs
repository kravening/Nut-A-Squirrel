using UnityEngine;
using UnityEngine.UI;

public class DisplaySquirrelIngredient : MonoBehaviour
{
    public SpriteRenderer _ingredientSprite;
    private SquirrelController _squirrelController;

    private void Awake()
    {
        _ingredientSprite = GetComponent<SpriteRenderer>();
        _squirrelController = GetComponent<SquirrelController>();
    }

    public void DisplayIngredient()
    {
        Sprite food = SpriteDataManager.instance.GetFoodSpriteFromList((int) _squirrelController.GetPrefferedFoodType());
        _ingredientSprite.sprite = food;
    }
    
}
