using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Gamestart : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator flipDownAnimation;
    public Animator flipUpAnimation;
    [SerializeField]
    private GameObject[] props;
    private bool _testbool;
    
	private void Start()
    {
        flipDownAnimation = props[0].GetComponent<Animator>();
        flipUpAnimation = props[1].GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            flipDownAnimation.Play("NFlip");
            _testbool = true;
            props[2].SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Character"))
        {
            props[2].SetActive(false);
            flipDownAnimation.Play("NFlip");
            _testbool = true;
        }
    }

    private void GameStart()
    {
        props[1].SetActive(true);
        props[0].SetActive(false);
        Debug.Log("Called for animation");
        Debug.Log("GameStart");
        flipUpAnimation.Play("TreeFlipAnimation2");
    }
}