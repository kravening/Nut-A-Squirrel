using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this class handles the incoming collisions of the squirrels
/// </summary>
public class SquirrelCollision : MonoBehaviour
{

    private SquirrelController _squirrelController;

    private void Awake()
    {
        _squirrelController = gameObject.GetComponent<SquirrelController>();
    }

    private void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject?.GetComponent<Projectile>()?.foodType == _squirrelController?.GetPreferredFoodType())
        {
            EatIngredient();
            Destroy(collider.gameObject);
        }
        else if(collider?.gameObject?.GetComponent<Projectile>())
        {
            ThrowIngredient(collider.gameObject.GetComponent<Projectile>());
        }
        else
        {
            Destroy(collider.gameObject);
        }
    }

    /// <summary>
    /// if the colliding object is a nut this function gets called and calls for the squirrel to hide, and increments the score.
    /// </summary>
    private void EatIngredient()
    {
        _squirrelController?.EatIngredient();
    }

    private void ThrowIngredient(Projectile ingredient)
    {
        _squirrelController?.ThrowIngredient(ingredient);
    }
}
