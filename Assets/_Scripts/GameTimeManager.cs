using System.Collections;
using UnityEngine;



    public class GameTimeManager : MonoBehaviour
    {
        /// <summary>
        /// an event signaling the game has started
        /// </summary>
        public delegate void GameStarted();

        public event GameStarted GameStartedEvent;

        /// <summary>
        /// an event signaling the game has paused
        /// </summary>
        public delegate void GamePaused();

        public event GamePaused GamePausedEvent;

        /// <summary>
        /// an event signaling the game has resumed
        /// </summary>
        public delegate void GameResumed();

        public event GamePaused GameResumedEvent;

        /// <summary>
        /// an event signaling the game has ended
        /// </summary>
        public delegate void GameEnded();

        public event GameEnded GameEndedEvent;

        /// <summary>
        /// instance of this class
        /// </summary>
        public static GameTimeManager instance { get; private set; }

        /// <summary>
        /// current time of the game round
        /// </summary>
        public float currentTime { get; private set; }

        /// <summary>
        /// max time of any given game round
        /// </summary>
        private float _roundTime = 180;
        
        //private UiController _uiController;

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

        /// <summary>
        /// this invokes the game started event, and starts the timer for the game.
        /// </summary>
        public void StartGame()
        {
            //resets round time.
            currentTime = _roundTime;
            GameStartedEvent.Invoke();
            StartCoroutine(GameTimer());
        }

        /// <summary>
        /// this pauses the game timer and time based behaviours resulting in the game staying stationary, besides maybe the shaders.
        /// </summary>
        public void PauseGame()
        {
            Time.timeScale = 0;
            GamePausedEvent.Invoke();
        }

        /// <summary>
        /// this resumes the game timer and time based behaviours resulting in the game continuing from where it was paused.
        /// </summary>
        public void ResumeGame()
        {
            Time.timeScale = 1;
            GameResumedEvent.Invoke();
        }

        /// <summary>
        /// this function functions as the game timer, and will call the game ended event once the max round time has been reached.
        /// </summary>
        /// <returns></returns>
        private IEnumerator GameTimer()
        {
            
            
            while (currentTime > 0)
            {
                UiController.instance.TimerUi((int)currentTime);
                currentTime -= Time.deltaTime;
                yield return new WaitForSeconds(0);
            }
            
            UiController.instance.TimerUi(0);
            
            yield return new WaitForSeconds(0);

            EndGame();
        }

        private void EndGame()
        {
            GameEndedEvent.Invoke();
        }

    }