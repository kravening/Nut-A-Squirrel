using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    private float _velocity;
    private float _destroyAfterSeconds;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _velocity = 2f;
        _destroyAfterSeconds = 2.5f;
    }

    private void Start()
    {
        StartCoroutine(DestroyProjectileTimer(_destroyAfterSeconds));
    }

    private void Update()
    {
        MoveProjectile();
    }

    private void MoveProjectile()
    {
        _rb.AddForce(transform.forward * _velocity);
    }

    private void DestroyProjectile()
    {
        Destroy(this.gameObject);
    }
    
   
    private IEnumerator DestroyProjectileTimer(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            DestroyProjectile();
        }
       
    }
}
