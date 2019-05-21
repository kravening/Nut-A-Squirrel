using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimeManager : MonoBehaviour
{

    public delegate void GameStarted();
    public event GameStarted GameStartedEvent;

    public delegate void GameEnded();
    public event GameEnded GameEndedEvent;

    public static GameTimeManager instance { get; private set; }
    public float currentTime { get; private set; }

    private float _roundTime = 60;

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

    public void StartGame()
    {
        currentTime = 0;
        StartCoroutine(GameTimer());
    }

    private IEnumerator GameTimer()
    {
        GameStartedEvent.Invoke();

        while (currentTime <= _roundTime)
        {
            
            currentTime += Time.deltaTime;
            Debug.Log(currentTime);
            yield return new WaitForSeconds(0);
        }

        yield return new WaitForSeconds(0);

        EndGame();
    }

    private void EndGame()
    {
        GameEndedEvent.Invoke();
    }

}
