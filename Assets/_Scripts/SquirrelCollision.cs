using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelCollision : MonoBehaviour
{
    private SquirrelController _squirrelController;

    private void Awake()
    {
        _squirrelController = gameObject.GetComponent<SquirrelController>();
    }

    public void OnCollisionEnter(Collision collider)
    {
        OnSquirrelHit();
    }

    public void OnSquirrelHit()
    {
        _squirrelController.Hide();
    }
}
