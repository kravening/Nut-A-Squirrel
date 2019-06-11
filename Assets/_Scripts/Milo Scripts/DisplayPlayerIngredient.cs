using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class displays the next ingredient that the player wil be able to shoot
/// </summary>
public class DisplayPlayerIngredient : MonoBehaviour
{
    public SpriteRenderer _playerIngredient;
    private ProjectileManager _projectileManager;
    
    private void Awake()
    {
        _playerIngredient = GetComponent<SpriteRenderer>();
        _projectileManager = GetComponent<ProjectileManager>();
    }
    /// <summary>
    /// Call this function to display the ingredient
    /// </summary>
    private void DisplayIngredient()
    {
        Sprite food = SpriteDataManager.instance.GetFoodSpriteFromList((int) _projectileManager._projectileQueue[0].gameObject.GetComponent<Projectile>().foodType);
        _playerIngredient.sprite = food;

    }
}
