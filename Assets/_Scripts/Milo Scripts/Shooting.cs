using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
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
        if (Input.GetKeyUp(KeyCode.Space) && _canShoot)
        {   
            GameObject bullet = Instantiate(projectileManager?.GetProjectileFromQueue(), transform.position, transform.rotation);
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
