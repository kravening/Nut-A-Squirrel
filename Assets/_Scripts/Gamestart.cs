using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamestart : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator _animation;
    [SerializeField]
    private GameObject[] props;
    private bool _testbool;
    
	private void Start()
    {
        _animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           _animation.Play("NFlip");
            _testbool = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Character"))
        {
            _animation.Play("NFlip");
            _testbool = true;
        }
    }

    private void GameStart()
    {
        props[1].SetActive(true);
        props[0].SetActive(false);
        Debug.Log("Called for animation");
        Debug.Log("GameStart");
        _animation.Play("TreeFlipAnimation2");
    }
}