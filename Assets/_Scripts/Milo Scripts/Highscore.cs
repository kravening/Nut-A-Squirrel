using UnityEngine;


/// <summary>
/// this class handles the highscore and current scoring data of the game.
/// </summary>

public class Highscore : MonoBehaviour
{
    private int _currentScore;

    private void Awake()
    {
        _currentScore = 0;
        CheckKeys();
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
    /// <param name="scoreToAdd"></param>
    public void IncrementScore(int incrementValue)
    {
        _currentScore += incrementValue;
    }

    /// <summary>
    /// saves the currentscore to the device
    /// </summary>
    /// <param name="scoreToSave"></param>
    private void SaveScoreToDevice(int scoreToSave)
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
    private void SaveHighScoreToDevice()
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
    public int GetCurrentScore()
    {
        return _currentScore;
    }

    /// <summary>
    /// return the highscore from the playerprefs
    /// </summary>
    /// <returns></returns>
    private int GetHighScore()
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
