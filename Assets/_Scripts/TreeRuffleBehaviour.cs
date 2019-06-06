using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// contains the functionality needed to ruffle the tree.
/// </summary>
    public class TreeRuffleBehaviour : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private Animator _treeAnimator;
        [SerializeField] private AudioSource _audioSource;
        public static  TreeRuffleBehaviour Instance;

        /// <summary>
        /// call this function to ruffle the tree.
        /// </summary>
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        private void OnDestroy()
        {
            if (Instance == this)
            {
                Instance = null;
            }
        }

        public void RuffleTree()
        {
            _particleSystem?.Play(true);
            _treeAnimator?.SetTrigger("Ruffle");
            _audioSource?.Play();
        }

        public void TreeFlip()
        {
            //Gamestart.instance.treeFlipAnimator.Play("FlipBackAni");
        }
    }