using UnityEngine;


/// <summary>
/// this singleton handles the highscore and current scoring data of the game.
/// </summary>
public class Highscore : MonoBehaviour
{
    /// <summary>
    /// this variable refers to the instance of this class
    /// </summary>
    public static Highscore instance { get; private set; }

    private int _currentScore;

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

        _currentScore = 0;
        CheckKeys();
    }
    
    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }

    /// <summary>
    /// Check if Score and HighScore key exist in PlayerPrefs
    /// </summary>
    private void CheckKeys()
    {
        IntializeKey("HighScore");
        IntializeKey("Score");
        PlayerPrefs.Save();
    }

    /// <summary>
    /// increments _currentScore
    /// </summary>
    /// <param name="incrementValue"></param>
    public void IncrementScore(int incrementValue)
    {
        _currentScore += incrementValue;
    }
    
    /// <summary>
    /// decrements _currentScore
    /// </summary>
    /// <param name="decrementValue"></param>
    public void DecrementScore(int decrementValue)
    {
        _currentScore -= decrementValue;
    }

    /// <summary>
    /// saves the currentscore to the device
    /// </summary>
    /// <param name="scoreToSave"></param>
    public void SaveScoreToDevice(int scoreToSave)
    {
        if (_currentScore > PlayerPrefs.GetInt("Score"))
        {
            PlayerPrefs.SetInt("Score", scoreToSave);
            PlayerPrefs.Save();
        }
    }

    /// <summary>
    /// save the highscore to the device
    /// </summary>
    public void SaveHighScoreToDevice()
    {
        if (GetCurrentScore() > GetHighScore())
        {
            PlayerPrefs.SetInt("HighScore", GetCurrentScore());
            PlayerPrefs.Save();
        }
    }

    /// <summary>
    /// returns the currentscore
    /// </summary>
    /// <returns></returns>
    private int GetCurrentScore()
    {
        UiController.instance.UpdateScoreUi(10);
        return _currentScore;
    }

    /// <summary>
    /// return the highscore from the playerprefs
    /// </summary>
    /// <returns></returns>
    public int GetHighScore()
    {
        int highscore = PlayerPrefs.GetInt("HighScore");
        return highscore;
    }

    /// <summary>
    /// Intitializes a new key with the given keyName if it doesn't already exist on the device.
    /// </summary>
    /// <param name="keyName"></param>
    private void IntializeKey(string keyName)
    {
        if (!PlayerPrefs.HasKey(keyName))
        {
            PlayerPrefs.SetInt(keyName, 0);
        }
    }
}
