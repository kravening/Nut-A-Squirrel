using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// contains the functionality needed to ruffle the tree.
/// </summary>
    public class TreeRuffleBehaviour : MonoBehaviour
    {    /// <summary>
         /// Gets the particleSystem
         /// </summary>
        [SerializeField] private ParticleSystem _particleSystem;
         /// <summary>
         /// Gets the TreeAnimator
         /// </summary>
        [SerializeField] private Animator _treeAnimator;
         /// <summary>
         /// Get the audioSource to play sound on demand
         /// </summary>
        [SerializeField] private AudioSource _audioSource;
         /// <summary>
         /// makes TreeRuffleBehaviour an istance to be called elsewhere.
         /// </summary>
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
        
        /// <summary>
        /// Makes the tree shake, play audio and particle come out,
        /// </summary>
        public void RuffleTree()
        {
            _particleSystem?.Play(true);
            _treeAnimator?.SetTrigger("Ruffle");
            _audioSource?.Play();
        }
    }