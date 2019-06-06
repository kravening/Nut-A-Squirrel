using TMPro;
using UnityEngine;

public class UiController : MonoBehaviour
{
	/// <summary>
	/// Gets the TextMeshProGui from the scene.
	/// </summary>
	[SerializeField] private TextMeshProUGUI[] highScoreText;
	/// <summary>
	/// makes the uicontroller an instance
	/// </summary>
	public static UiController instance;

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
	/// Updates the score UI inside the game
	/// </summary>
	/// <param name="score"></param>
	public void UpdateScoreUi(int score)
	{
		highScoreText[0].text = score.ToString();
	}
	/// <summary>
	/// Updates the timer UI inside the game
	/// </summary>
	/// <param name="timer"></param>
	public void TimerUi(int timer)
	{
		highScoreText[1].text = timer.ToString();
	}
}