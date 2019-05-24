using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class UIController : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI highScoreText;

	// Start is called before the first frame update
	void Start()
	{
		UpdateScoreUi(4);
	}

	private void UpdateScoreUi(int score)
	{
		Debug.Log(score);
		highScoreText.text = score.ToString();
	}
}