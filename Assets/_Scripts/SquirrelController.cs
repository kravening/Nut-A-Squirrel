using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this class controls the behaviour of the squirrel.
/// </summary>
public class SquirrelController : MonoBehaviour
{
    // this is a reference to the treerufflebehaviour on the inhabitants tree.
    [SerializeField]private TreeRuffleBehaviour treeRuffleBehaviour;

    // these booleans are use to keep track of the state of the squirrel
    private bool _isSquirrelHidden = true;
    private bool _isHiding = false;

    // this is a reference to the animator component on this object
    private Animator _animator;

    public FoodEnums.FoodType _preferredFoodType;

    public void Awake()
    {
        _preferredFoodType = FoodEnums.GetRandomFood();
        _animator = GetComponent<Animator>();
    }

    /// <summary>
    /// this function calls the squirrel to show up.
    /// </summary>
    public void Show()
    {
        if (_isSquirrelHidden)
        {
            _isSquirrelHidden = false;
            SquirrelManager.instance?.SquirrelShown();
            StartCoroutine(ShowSquirrelRoutine());
        }
    }

    /// <summary>
    /// this is a routine for showing the squirrels, ensuring the logic is in the right order.
    /// </summary>
    /// <returns></returns>
    private IEnumerator ShowSquirrelRoutine()
    {
        treeRuffleBehaviour?.RuffleTree();
        yield return new WaitForSeconds(0.5f);

        _animator?.SetBool("IsShowing", true);
        yield return new WaitForSeconds(4);

        //if squirrel isn't already hidden or starting to hide.
        if (_isSquirrelHidden == false && _isHiding == false)
        {
            Hide();
        }
    }

    /// <summary>
    /// this function calls for the squirrel to hide.
    /// </summary>
    private void Hide()
    {
        SquirrelManager.instance?.SquirrelHiding();
        StartCoroutine(HideSquirrelRoutine());
    }

    /// <summary>
    /// this is a routine for hiding the squirrels, ensuring the logic is in the right order.
    /// </summary>
    private IEnumerator HideSquirrelRoutine()
    {
        _isHiding = true;
        _animator?.SetBool("IsShowing", false);
        yield return new WaitForSeconds(0.5f);
        _isSquirrelHidden = true;
        _isHiding = false;
    }

    private IEnumerator ThrowIngredientRoutine(Projectile incomingIngredient)
    { 
        Projectile newProjectile = ProjectileManager.instance.GetProjectileWithSetIngredientType(incomingIngredient.foodType);
        newProjectile.transform.position = incomingIngredient.transform.position;
        newProjectile.transform.LookAt(Camera.main.transform);

        Instantiate(newProjectile.gameObject);

        Destroy(incomingIngredient.gameObject);

        yield return new WaitForSeconds(0.25f);
        Hide();
    }

    private IEnumerator EatIngredientRoutine()
    {
        Highscore.instance?.IncrementScore(100);
        // start animation
        yield return new WaitForSeconds(0.5f);
        Hide();
    }

    public void ThrowIngredient(Projectile ingredient)
    {
        StartCoroutine(ThrowIngredientRoutine(ingredient));
        Hide();
    }

    public void EatIngredient()
    {
        StartCoroutine(EatIngredientRoutine());
    }

    public FoodEnums.FoodType GetPreferredFoodType()
    {
        return _preferredFoodType;
    }
}
