using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public ProjectileManager _ProjectileManager;
    private float _cooldown;
    private bool _canShoot;

    private void Awake()
    {
        _cooldown = 1f;
        _canShoot = true;
    }

    private void Update()
    {
        Shoot();
    }

    
    private void Shoot()
    {
        if (Input.GetKeyUp(KeyCode.Space) && _canShoot)
        {   
            GameObject bullet = Instantiate(_ProjectileManager.GetProjectileQueue(), transform.position, transform.rotation);
            _canShoot = false;
            StartCoroutine(ShootTime(_cooldown));
        }
    }

    private IEnumerator ShootTime(float time)
    { 
        while (!_canShoot)
        {
            yield return new WaitForSeconds(time);
            _canShoot = true;
        }
    }
    
}
