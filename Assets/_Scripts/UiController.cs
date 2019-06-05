using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class UiController : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI highScoreText;
	public UiController _instance;

	private void Start()
	{
		_instance = this;
	}

	public void UpdateScoreUi(int score)
	{
		Debug.Log(score);
		highScoreText.text = score.ToString();
	}
}