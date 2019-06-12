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
	[SerializeField] private TextMeshProUGUI[] textItems;

	[SerializeField] private GameObject highScoreUi;
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
		GameTimeManager.GameEndedEvent -= HighScore;
		GameTimeManager.GameStartedEvent -= removeHighScoreUI;
	}

	private void Start()
	{
		GameTimeManager.GameEndedEvent += HighScore;
		GameTimeManager.GameStartedEvent += removeHighScoreUI;
	}

	/// <summary>
	/// Updates the score UI inside the game
	/// </summary>
	/// <param name="score"></param>
	public void UpdateScoreUi(int score)
	{
		scoreText = score;
		textItems[0].text = score.ToString();
	}

	private void removeHighScoreUI()
	{
		highScoreUi.SetActive(false);
	}

	private void HighScore()
	{
		highScoreUi.SetActive(true);
		textItems[2].text = scoreText.ToString();
	}

	/// <summary>
	/// Updates the timer UI inside the game
	/// </summary>
	/// <param name="timer"></param>
	public void TimerUi(int timer)
	{
		textItems[1].text = timer.ToString();
	}
}