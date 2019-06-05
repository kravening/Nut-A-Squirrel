using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Controller
{
	public class UiController : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI[] highScoreText;
		public static UiController _instance;

		private void Start()
		{
			_instance = this;
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
}