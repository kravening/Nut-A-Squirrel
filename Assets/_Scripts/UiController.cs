using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiController : MonoBehaviour
{
   public UiController _instance;
   [SerializeField] private TextMeshProUGUI highScoreText;

   private void Start()
   {
      _instance = this;
   }

   public void UpdateScoreUI(int score)
   {
      highScoreText.text = score.ToString();
   }
}
