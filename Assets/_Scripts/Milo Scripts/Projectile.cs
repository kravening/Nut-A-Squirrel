using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// When this class is added to an object it will move straight forward in its set direction over time
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [SerializeField]private float _velocity = 20f;
    [SerializeField]private float _destroyAfterSeconds = 2.5f;
    private Rigidbody _rb;
    private SpriteRenderer _spriteRenderer;
    public FoodEnums.FoodType foodType;



    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody>();
        _rb.useGravity = false;
    }

    private void Start()
    {
        //assigns project the matching sprite. 
        _spriteRenderer.sprite = SpriteDataManager.instance.GetFoodSpriteFromList((int) foodType);

        StartCoroutine(DestroyProjectileTimer(_destroyAfterSeconds));
        MoveProjectile();
    }

    /// <summary>
    /// this function adds force to the rigidbody making the object this class is on move in it's set direction.
    /// </summary>
    private void MoveProjectile()
    {
        _rb?.AddForce(transform.forward * _velocity, ForceMode.Impulse);
    }

    public void MoveTowardsPlayer()
    {
        _rb.velocity = Vector3.zero;
        transform.LookAt(Camera.main.transform);
        MoveProjectile();
    }

    /// <summary>
    /// when this function gets called the projectile will be destroyed.
    /// </summary>
    private void DestroyProjectile()
    {
        Destroy(this.gameObject);
    }
    
    /// <summary>
    /// this routine keeps track of when the projectile needs to be destroyed, time wise.
    /// </summary>
    /// <param name="timeTillDestruction"></param>
    /// <returns></returns>
    private IEnumerator DestroyProjectileTimer(float timeTillDestruction)
    {
        yield return new WaitForSeconds(timeTillDestruction);
        DestroyProjectile();
    }

    public void ResetTimer()
    {
        StopCoroutine(DestroyProjectileTimer(_destroyAfterSeconds));
        StartCoroutine(DestroyProjectileTimer(_destroyAfterSeconds));
    }
}
