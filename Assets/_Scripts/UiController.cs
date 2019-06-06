using TMPro;
using UnityEngine;
using UnityEngine.Serialization;


public class UiController : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI[] highScoreText;
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

		public void UpdateScoreUi(int score)
		{
			Debug.Log(score);
			highScoreText[0].text = score.ToString();
		}

		public void TimerUi(int timer)
		{
			highScoreText[1].text = timer.ToString();
		}
	}