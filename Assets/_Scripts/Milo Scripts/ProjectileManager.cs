using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This class takes track of which projectile is next in the queue to shoot.
/// </summary>
public class ProjectileManager : MonoBehaviour
{
    public Projectile projectile;// all the projectile objects available
    public List<Projectile> _projectileQueue =  new List<Projectile>();// queue for next projectile 

    private int _queueSize = 4;

    public static ProjectileManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }

    private void Start()
    {
        InitializeProjectileQueue();
        GetProjectileFromQueue();
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
    /// this function adds a new projectile to the queue, picked randomly from the possible types of projectile.
    /// </summary>
    private void AddProjectileToQueue()
    {
        Projectile newProjectile = projectile;
        //assigns projectile a random food type.
        newProjectile.foodType = FoodEnums.GetRandomFood();

        //add it to the queue
        _projectileQueue.Add(newProjectile);
    }

    /// <summary>
    /// this function returns the first game object in the queue and then generates a new one.
    /// </summary>
    /// <returns></returns>
    public GameObject GetProjectileFromQueue()
    {
        GameObject projectileToShoot = _projectileQueue[0].gameObject;
        _projectileQueue.RemoveAt(0);
        AddProjectileToQueue();
        
        return projectileToShoot;
    }
    
    public Projectile GetProjectileWithSetIngredientType(FoodEnums.FoodType ingredientType)
    {
        _projectileQueue.Add(projectile);
        _projectileQueue[_projectileQueue.Count - 1].foodType = ingredientType;
        Projectile newProjectile = _projectileQueue[_projectileQueue.Count - 1];
        _projectileQueue.RemoveAt(_projectileQueue.Count - 1);

        return newProjectile;
    }
}
