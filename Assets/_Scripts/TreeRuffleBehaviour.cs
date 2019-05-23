using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// contains the functionality needed to ruffle the tree.
/// </summary>
public class TreeRuffleBehaviour : MonoBehaviour
{
    [SerializeField]private ParticleSystem _particleSystem;
    [SerializeField]private Animator _treeAnimator;
    [SerializeField]private AudioSource _audioSource;

    /// <summary>
    /// call this function to ruffle the tree.
    /// </summary>
    public void RuffleTree()
    {
        _particleSystem?.Play(true);
        _treeAnimator?.SetTrigger("Ruffle");
        _audioSource.Play();
    }
}
