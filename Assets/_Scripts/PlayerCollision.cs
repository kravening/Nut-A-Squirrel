using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class handles the collision for the player
/// </summary>
public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collider)
    {
        if (collider?.gameObject?.GetComponent<Projectile>())
        {
            Highscore.instance.DecrementScore(100);
            // TODO: play minecraft steve OOF sound clip.
        }
    }
}
