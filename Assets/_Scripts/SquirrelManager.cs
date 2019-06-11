using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
/// <summary>
/// This class manages a collection of target controllers
/// </summary>
public class SquirrelManager : MonoBehaviour
{
    /// <summary>
    /// the instance off this singleton, this variable the class it's in.
    /// </summary>
    public static SquirrelManager instance;

    /// <summary>
    /// a list with references to squirrels in the field.
    /// </summary>
    public List<SquirrelController> squirrels = new List<SquirrelController>();

    /// <summary>
    /// maximum amount of squirrels that can come out of hiding in one moment, new ones won't spawn if the current amount of squirrels in the field are higher or equal to this number.
    /// </summary>
    private int _maxSquirrelsShowing = 5;

    /// <summary>
    /// minimum amount of squirrels to show at one time, if there are less squirrels than this number currently in the game field a new one will come out of hiding.
    /// </summary>
    private int _minSquirrelsShowing = 1;

    /// <summary>
    /// the current amount of squirrels out showing in the game field.
    /// </summary>
    private int _currentShowingSquirrels = 0;

    /// <summary>
    /// the minimal amount of time for a squirrel to show up.
    /// </summary>
    private float _minAppearTimer = 1;

    /// <summary>
    /// the maximum possible amount of time for a squirrel to show up.
    /// </summary>
    private float _maxAppearTimer = 4;

    /// <summary>
    /// a variable to keep the time for when a new squirrel will show up.
    /// </summary>
    private float _currentNewSquirrelTime = 0;

    /// <summary>
    /// a boolean that tells this manager if the game is paused or not.
    /// </summary>
    private bool _isGameRunning = false;

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
        
        // if there are more max squirrels showing in the squirrels list, set max squirrels showing to the amount of elements in the list to prevent index errors.
        if (_maxSquirrelsShowing > squirrels.Count)
        {
            _maxSquirrelsShowing = squirrels.Count;
        }
    }

    private void Start()
    {
        GameTimeManager.instance.GameStartedEvent += ResumeSpawning;
        GameTimeManager.instance.GameEndedEvent += PauseSpawning;
    }


    private void OnDestroy()
    {

        if (instance == this)
        {
            instance = null;
        }
    }

    private void Update()
    {
        if (!_isGameRunning)// don't execute any update logic if the game isn't running
        {
            return;
        }

        UpdateTimer();
        CheckToSeeIfSquirrelWillSpawn();
    }

    /// <summary>
    /// this functions decrements the squirrelTimer with the unity deltaTime each frame.
    /// </summary>
    private void UpdateTimer()
    {
        _currentNewSquirrelTime -= Time.deltaTime;
        
    }
    /// <summary>
    /// this function will run through a few checks to see if it's the right moment to call for a new squirrel
    /// </summary>
    private void CheckToSeeIfSquirrelWillSpawn()
    {
        //less than the minimum amount of squirrels in the field, force a squirrel to show.
        if (_currentShowingSquirrels < _minSquirrelsShowing)
        {
            ShowNewSquirrel();
            return;
        }

        //it's not yet time to spawn to spawn a squirrel, exit function.
        if (_currentNewSquirrelTime >= 0)
        {
            return;
        }

        //there already are enough squirrels out on the field, exit function.
        if (_currentShowingSquirrels >= _maxSquirrelsShowing)
        {
            return;;
        }

        ShowNewSquirrel();
        ResetSquirrelTimer();

    }
    /// <summary>
    /// this function calls a random unshowing squirrel to show itself.
    /// </summary>
    private  void ShowNewSquirrel()
    {
        int randomIndex = Random.Range(0, squirrels.Count);
        Debug.Log(randomIndex);
         squirrels[randomIndex].Show();
    }

    /// <summary>
    /// randomly set a time for a new squirrel to appear, the random number is based on the min and max appear time.
    /// </summary>
    private  void ResetSquirrelTimer()
    {
        _currentNewSquirrelTime = Random.Range(_minAppearTimer, _maxAppearTimer);
    }

    /// <summary>
    /// increment the counter of how many squirrels currently are in the field.
    /// </summary>
    public void SquirrelShown()
    {
        _currentShowingSquirrels++;
    }

    /// <summary>
    /// decrements the counter of how many squirrels currently are in the field.
    /// </summary>
    public void SquirrelHiding()
    {
        _currentShowingSquirrels--;
    }

    /// <summary>
    /// pauses the spawning of squirrels
    /// </summary>
    private void PauseSpawning()
    {
        _isGameRunning = false;
    }

    /// <summary>
    /// resumes the spawning of squirrels
    /// </summary>
    private void ResumeSpawning()
    {
        _isGameRunning = true;
    }


}
