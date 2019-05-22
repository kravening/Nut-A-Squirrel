using System.Collections;
using System.Collections.Generic;
using Behaviour;
using UnityEngine;

public class SquirrelController : MonoBehaviour
{
    [SerializeField]private TreeRuffleBehaviour treeRuffleBehaviour;
    private bool _isSquirrelHidden = true;
    private bool _isHiding = false;
    private Animator _animator;

    public void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Show()
    {
        if (_isSquirrelHidden)
        {
            _isSquirrelHidden = false;
            SquirrelManager.instance?.SquirrelShown();
            StartCoroutine(ShowSquirrelRoutine());
        }
    }

    private IEnumerator ShowSquirrelRoutine()
    {
        treeRuffleBehaviour?.RuffleTree();
        yield return new WaitForSeconds(2);

        _animator?.SetBool("IsShowing", true);
        yield return new WaitForSeconds(2);

        //if squirrel isn't already hidden or starting to hide.
        if (_isSquirrelHidden == false && _isHiding == false)
        {
            Hide();
        }
    }

    public void Hide()
    {
        SquirrelManager.instance?.SquirrelHiding();
        StartCoroutine(HideSquirrelRoutine());
    }

    private IEnumerator HideSquirrelRoutine()
    {
        _isHiding = true;
        _animator?.SetBool("IsShowing", false);
        yield return new WaitForSeconds(0.5f);
        _isSquirrelHidden = true;
        _isHiding = false;
    }
}
