using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelController : MonoBehaviour
{
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
            SquirrelManager.instance.SquirrelShown();
            StartCoroutine(ShowSquirrelRoutine());
        }
    }

    private IEnumerator ShowSquirrelRoutine()
    {
        Debug.Log("showing");
        _animator.SetBool("IsShowing", true);
        yield return new WaitForSeconds(2);

        //if squirrel isn't already hidden or starting to hide.
        if (_isSquirrelHidden == false && _isHiding == false)
        {
            Hide();
        }
    }

    public void Hide()
    {
        SquirrelManager.instance.SquirrelHiding();
        StartCoroutine(HideSquirrelRoutine());
    }

    private IEnumerator HideSquirrelRoutine()
    {
        Debug.Log("hiding");
        _isHiding = true;
        _animator.SetBool("IsShowing", false);
        yield return new WaitForSeconds(0.5f);
        _isSquirrelHidden = true;
        _isHiding = false;
    }
}
