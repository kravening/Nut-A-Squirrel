using UnityEngine;
using UnityEngine.UI;

public class DisplayPlayerIngredient : MonoBehaviour
{
    public SpriteRenderer _playerIngredient;
    private ProjectileManager _projectileManager;
    
    private void Awake()
    {
        _playerIngredient = GetComponent<SpriteRenderer>();
        _projectileManager = GetComponent<ProjectileManager>();
    }

    private void DisplayIngredient()
    {
        Sprite food = SpriteDataManager.instance.GetFoodSpriteFromList((int) _projectileManager._projectileQueue[0].gameObject.GetComponent<Projectile>().foodType);
        _playerIngredient.sprite = food;

    }
}
