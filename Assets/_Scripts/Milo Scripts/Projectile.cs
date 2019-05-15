using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [SerializeField]private float _velocity = 20f;
    [SerializeField]private float _destroyAfterSeconds = 2.5f;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.useGravity = false;
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
        _rb.AddForce(transform.forward * (_velocity * Time.deltaTime));
    }

    private void DestroyProjectile()
    {
        Destroy(this.gameObject);
    }
    
   
    private IEnumerator DestroyProjectileTimer(float timeTillDestruction)
    {
        yield return new WaitForSeconds(timeTillDestruction);
        DestroyProjectile();
    }
}
