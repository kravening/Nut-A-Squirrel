
using UnityEngine;

    public class Gamestart : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] private GameObject[] props;
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
        }

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

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Nut"))
            {
                props[0]?.SetActive(false);
                GameStart();
                //TreeRuffleBehaviour.Instance.TreeFlip();
            }
        }

        private void GameStart()
        {
            GameTimeManager.instance.StartGame();
        }
    }
