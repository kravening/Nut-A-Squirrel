using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

/// <summary>
/// This controller handles all the UI elements of the game
/// </summary>
public class UIController : MonoBehaviour
{
	/// <summary>
	/// Gets the TextMeshProGui from the scene.
	/// </summary>
	[SerializeField] private TextMeshProUGUI[] Textitems;

	[SerializeField] private GameObject HighScoreUI;
	/// <summary>
	/// makes the uicontroller an instance
	/// </summary>
	public static UIController instance;

	private int scoreText;

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
		GameTimeManager.instance.GameEndedEvent -= HighScore;
		GameTimeManager.instance.GameStartedEvent -= removeHighScoreUI;
	}

	private void Start()
	{
		GameTimeManager.instance.GameEndedEvent += HighScore;
		GameTimeManager.instance.GameStartedEvent += removeHighScoreUI;
	}

	/// <summary>
	/// Updates the score UI inside the game
	/// </summary>
	/// <param name="score"></param>
	public void UpdateScoreUi(int score)
	{
		scoreText = score;
		Textitems[0].text = score.ToString();
	}

	private void removeHighScoreUI()
	{
		HighScoreUI.SetActive(false);
	}

	private void HighScore()
	{
		HighScoreUI.SetActive(true);
		Textitems[2].text = scoreText.ToString();
	}

	/// <summary>
	/// Updates the timer UI inside the game
	/// </summary>
	/// <param name="timer"></param>
	public void TimerUi(int timer)
	{
		Textitems[1].text = timer.ToString();
	}
}