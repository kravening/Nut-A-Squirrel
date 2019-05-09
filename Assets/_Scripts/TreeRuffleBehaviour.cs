using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeRuffleBehaviour : MonoBehaviour
{
    [SerializeField]private ParticleSystem _particleSystem;
    [SerializeField]private Animator _treeAnimator;
    [SerializeField]private AudioSource _audioSource;

    public void RuffleTree()
    {
        _particleSystem?.Play(true);
        _treeAnimator?.SetTrigger("Ruffle");
        _audioSource.Play();
    }
}
