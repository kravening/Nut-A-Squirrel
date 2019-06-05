using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Behaviour;
using Manager;
using UnityEngine.Serialization;

namespace GameStart
{
    public class Gamestart : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] private GameObject[] props;
        [SerializeField] public Animator treeFlipAnimator;

        public static Gamestart instance;

        private void Start()
        {
            instance = this;
            Debug.Log(TreeRuffleBehaviour.Instance);
        }

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //TreeRuffleBehaviour.Instance.TreeFlip();
                props[0].SetActive(false);
                GameStart();
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name.Contains("Nut"))
            {
                props[0].SetActive(false);
                GameStart();
                //TreeRuffleBehaviour.Instance.TreeFlip();
            }
        }

        public void GameStart()
        {
            Debug.Log("Called for animation");
            Debug.Log("call for GameStart");
            GameTimeManager.instance.StartGame();
            //TreeRuffleBehaviour.Instance.TreeFlip();
        }
    }
}