using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class displays the next ingredient that the player wil be able to shoot
/// </summary>
public class DisplayPlayerIngredient : MonoBehaviour
{
    public Image nextPlayerIngredient;
    private ProjectileManager _projectileManager;

    public static DisplayPlayerIngredient instance;

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
        _projectileManager = GetComponent<ProjectileManager>();
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }

    private void Start()
    {
        //DisplayNextIngredient();
    }

    /// <summary>
    /// Call this function to display the ingredient
    /// </summary>

    public void DisplayNextIngredient(FoodEnums.FoodType food)
    {
        nextPlayerIngredient.GetComponent<Image>().sprite = SpriteDataManager.instance.GetFoodSpriteFromList((int)food);
    }
}
