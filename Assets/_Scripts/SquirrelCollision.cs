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
        if (collider.gameObject?.GetComponent<Projectile>()?.foodType ==
            _squirrelController?.GetPrefferedFoodType())
        {
            OnSquirrelHit(true);
        }
        else
        {
            OnSquirrelHit(false);
        }
    }

    /// <summary>
    /// if the colliding object is a nut this function gets called and calls for the squirrel to hide, and increments the score.
    /// </summary>
    public void OnSquirrelHit(bool isNutAccordingToPreference)
    {
        if (isNutAccordingToPreference)
        {
            Highscore.instance?.IncrementScore(100);
            _squirrelController?.Hide();
        }
        else
        {
            _squirrelController?.ThrowNut();
        }
    }
}
