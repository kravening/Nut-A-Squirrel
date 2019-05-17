using System.Collections;
using UnityEngine;

/// <summary>
/// this class houses the behaviour needed to spawn a gameobject to shoot off into the game world.
/// </summary>
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
    
    /// <summary>
    /// call this function to shoot a bullet.
    /// </summary>
    private void Shoot()
    {
        if (Input.touches.Length != 0 && _canShoot)
        {
            GameObject bullet = Instantiate(projectileManager?.GetProjectileFromQueue(), _arCamera.transform.position, _arCamera.transform.rotation);
            bullet.transform.parent = this.transform;
            StartCoroutine(StartCooldown(_cooldown));
        }
    }
    /// <summary>
    /// this routine manages the cooldown for the bullet
    /// </summary>
    /// <param name="cooldownTime"></param>
    /// <returns></returns>
    private IEnumerator StartCooldown(float cooldownTime)
    {
        _canShoot = false;
        yield return new WaitForSeconds(cooldownTime);
        _canShoot = true;
    }
    
}
