using UnityEngine;


/// <summary>
/// this class handles the in game score and highscore
/// </summary>

public class Highscore : MonoBehaviour
{
    private int _currentScore;

    private void Awake()
    {
        _currentScore = 0;
        CheckKeys();
    }
    //Check if Score and HighScore key exist in PlayerPrefs
    private void CheckKeys()
    {
        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }

        if (!PlayerPrefs.HasKey("Score"))
        {
            PlayerPrefs.SetInt("Score", _currentScore);
        }
        
        PlayerPrefs.Save();
    }
    
    // add a score to the currentscore
    private void AddScore(int score)
    {
        _currentScore += score;
        SaveScoreToDevice(_currentScore);
    }
    
    // save the currentscore to the device
    private void SaveScoreToDevice(int score)
    {
        if (_currentScore > PlayerPrefs.GetInt("Score"))
        {
            PlayerPrefs.SetInt("Score", score);
            PlayerPrefs.Save();
        }
    }
    
    // save the highscore to the device
    private void SaveHighScoreToDevice()
    {
        if (GetScore() > GetHighScore())
        {
            PlayerPrefs.SetInt("HighScore", GetScore());
            PlayerPrefs.Save();
        }
    }

    // return the score from the playerprefs
    private int GetScore()
    {
        int score = PlayerPrefs.GetInt("Score");
        return score;
    }

    // return the highscore from the playerprefs 
    private int GetHighScore()
    {
        int highscore = PlayerPrefs.GetInt("HighScore");
        return highscore;
    }  
}
