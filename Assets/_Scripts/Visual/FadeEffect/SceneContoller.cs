using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class SceneContoller : MonoBehaviour
{
    private static string _fade = "Fade";
    [SerializeField] private Image _black;
    [SerializeField] private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(Fading());
        }
    }

    IEnumerator Fading()
    {
        _anim.SetBool(_fade, true);
        yield return new WaitUntil(()=>_black.color.a==1);
        _anim.SetBool(_fade, false);
        Debug.Log("NoU");
    }
}
