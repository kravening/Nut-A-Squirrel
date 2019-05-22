using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameStart;

namespace Behaviour
{
    public class TreeRuffleBehaviour : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private Animator _treeAnimator;
        [SerializeField] private AudioSource _audioSource;
        public static TreeRuffleBehaviour Instance;

        private void Start()
        {
            Instance = this;
        }

        public void RuffleTree()
        {
            _particleSystem?.Play(true);
            _treeAnimator?.SetTrigger("Ruffle");
            _audioSource.Play();
        }

        public void CallgameStart()
        {
            Gamestart.instance.GameStart();
        }

        public void TreeFlip()
        {
            Gamestart.instance.treeFlipAnimator.Play("FlipBackAni");
        }
    }
}