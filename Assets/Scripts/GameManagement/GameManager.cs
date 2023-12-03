using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

  static public GameManager manager;

  void Awake(){
    manager = this;
  }

  public void EndGame(bool playerWon) {
    if (playerWon) {
      EndGameScreen.instance.OutcomeText.SetText("Mission Success");
      print("Mission Success");
    }
    else {
      EndGameScreen.instance.OutcomeText.SetText("Mission Failed");
      print("Mission Failed");
    }
    
    EndGameScreen.instance.ShowScreen();
  }

}
