using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public List<GameObject> projectiles = new List<GameObject>();// all the projectile objects available
    private List<GameObject> _projectileQueue =  new List<GameObject>();// queue for next projectile 

    private void Start()
    {
        GetProjectileQueue();
    }

    public GameObject GetProjectileQueue()
    {
        _projectileQueue.Add(projectiles[Random.Range(0, projectiles.Count)]);
        
        GameObject projectileToShoot = _projectileQueue[0];
        
        _projectileQueue.RemoveAt(0);

        return projectileToShoot;
    }
}
