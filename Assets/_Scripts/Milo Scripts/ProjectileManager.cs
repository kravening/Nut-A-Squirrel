using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// this class takes track of which projectile is next in the queue to shoot.
/// </summary>
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

    /// <summary>
    /// this function returns the first game object in the queue and then generates a new one.
    /// </summary>
    /// <returns></returns>
    public GameObject GetProjectileFromQueue()
    {
        GameObject projectileToShoot = _projectileQueue[0];
        _projectileQueue.RemoveAt(0);
        AddProjectileToQueue();

        return projectileToShoot;
    }

    /// <summary>
    /// this function takes care of the initial setup of the queue.
    /// </summary>
    private void InitializeProjectileQueue()
    {
        for (int i = 0; i < _queueSize; i++)
        {
            AddProjectileToQueue();
        }
    }

    /// <summary>
    /// this function adds a new projectile to the queue, picked randomly from the possible types of projectiles.
    /// </summary>
    private void AddProjectileToQueue()
    {
        _projectileQueue.Add(projectiles?[Random.Range(0, projectiles.Count)]);
    }
}
