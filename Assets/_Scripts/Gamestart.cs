
using UnityEngine;
    /// <summary>
    /// This class starts the game
    /// </summary>
    public class Gamestart : MonoBehaviour
    {
        /// <summary>
        /// get the props gameobjects to be used for setactive
        /// </summary>
        [SerializeField] private GameObject[] props;
        /// <summary>
        /// gets the animator
        /// </summary>
        [SerializeField] public Animator treeFlipAnimator;

        public static Gamestart instance;

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(this);
            }
            else
            {
                instance = this;
            }
        }

        private void OnDestroy()
        {
            if (instance == this)
            {
                instance = null;
            }
            GameTimeManager.GameEndedEvent -= RestartGame;
        }

        private void Start()
        {
            GameTimeManager.GameEndedEvent += RestartGame;
        }

        /// <summary>
        /// test function
        /// </summary>
        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //TreeRuffleBehaviour.Instance.TreeFlip();
                props[0]?.SetActive(false);
                GameStart();
            }
        }
        
        /// <summary>
        /// Checks collision and calls gamestart when its hit
        /// </summary>
        /// <param name="collision"></param>
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Nut"))
            {
                GameStart();
                //TreeRuffleBehaviour.Instance.TreeFlip();
            }
        }

        public void RestartGame()
        {
            props[0]?.SetActive(true);
        }

        private void GameStart()
        {
            props[0]?.SetActive(false);
            GameTimeManager.instance.StartGame();
        }
    }
