using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Goal : MonoBehaviour
{
  public Transform positionBall;
  public Transform positionPlayer1;
  public Transform positionPlayer2;
  public Transform player1;
  public Transform player2;
  public Transform ball;
  public int scorePlayer1;
  public int scorePlayer2;
  public int goal;
  public TextMeshProUGUI uiScorePlayer1;
  public TextMeshProUGUI uiScorePlayer2;
  
  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Ball"))
    {
      if (goal == 1)
      {
        scorePlayer1++;
        uiScorePlayer1.text = "Atlas -" + scorePlayer1.ToString();
      }
      else
      {
        scorePlayer2++;
        uiScorePlayer2.text = scorePlayer2.ToString() + " - Poland";
      }
      ball.transform.parent = null;
      ball.transform.position = positionBall.position;
    }
  }
}
