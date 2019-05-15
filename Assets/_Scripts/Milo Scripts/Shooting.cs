using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Camera _arCamera;
    public ProjectileManager projectileManager;
    [SerializeField]private float _cooldown = 1f;
    private bool _canShoot;

    private void Awake()
    {
        _canShoot = true;
    }

    private void Update()
    {
        Shoot();
    }
    
    private void Shoot()
    {
        if (Input.touches.Length != 0 && _canShoot)
        {
            GameObject bullet = Instantiate(projectileManager?.GetProjectileFromQueue(), _arCamera.transform.position, _arCamera.transform.rotation);
            bullet.transform.parent = this.transform;
            StartCoroutine(StartCooldown(_cooldown));
        }
    }

    private IEnumerator StartCooldown(float cooldownTime)
    {
        _canShoot = false;
        yield return new WaitForSeconds(cooldownTime);
        _canShoot = true;
    }
    
}
