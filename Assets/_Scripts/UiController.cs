using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
	[SerializeField]
	private string[] names;
	[SerializeField]
	private Slider _slider;

	// Start is called before the first frame update
	void Start()
	{
		names = QualitySettings.names;
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void QualitySetter(int quality)
	{
		for (int i = 0; i < names.Length; i++)
		{
			if (i == _slider.value)
			{
				QualitySettings.SetQualityLevel(i, true);
			}
		}
	}
}