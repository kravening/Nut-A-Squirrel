using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public List<GameObject> projectiles = new List<GameObject>();// all the projectile objects available
    private List<GameObject> _projectileQueue =  new List<GameObject>();// queue for next projectile 
    private int _queueSize = 4;

    private void Start()
    {
        InitializeProjectileQueue();
        GetProjectileFromQueue();
    }

    public GameObject GetProjectileFromQueue()
    {
        GameObject projectileToShoot = _projectileQueue[0];
        _projectileQueue.RemoveAt(0);
        AddProjectileToQueue();

        return projectileToShoot;
    }

    private void InitializeProjectileQueue()
    {
        for (int i = 0; i < _queueSize; i++)
        {
            AddProjectileToQueue();
        }
    }

    private void AddProjectileToQueue()
    {
        _projectileQueue.Add(projectiles?[Random.Range(0, projectiles.Count)]);
    }
}
