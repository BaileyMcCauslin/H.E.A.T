using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndGameScreen : MonoBehaviour
{
  static public EndGameScreen instance;
  [ SerializeField ] public TMP_Text OutcomeText;

  void Awake() {
    instance = this;
    this.gameObject.SetActive(false);
  }

  public void ShowScreen() {
    this.gameObject.SetActive(true);
  }

  public void MainMenu() {
    SceneManager.LoadScene("Main Menu");
  }

  public void Restart() {
    SceneManager.LoadScene("level");
  }
}
