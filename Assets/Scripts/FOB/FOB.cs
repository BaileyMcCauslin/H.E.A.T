using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FOB : MonoBehaviour
{
  private double health;
  private bool destroyed;

  void Awake()
  {
    health = 500;
    ShowStructure();
  }

  void OnTriggerEnter(Collider collider) {
    print("FOB collision detected");

    GameObject collisionObject = collider.gameObject;
    print(collisionObject);
    Missile missile = collider.gameObject.GetComponent<Missile>();
    
    //check to see if collision was with a missile
    if (missile != null) {
      health -= missile.damage;
      print(gameObject.name + " took " + missile.damage + " damage.\nRemaining health: " + health);
      
      if (health <= 0) {
        this.destroyed = true;
        ShowDestroyed();
      }
    }

    if (this.destroyed) {
      // This should take players to some end game screen showing the winner.
      // For now just goes to main menu.
      SceneManager.LoadScene("Main Menu");
    }
  }

  private void ShowDestroyed() {
    foreach (Transform child in transform) {
      if (child.name == "Structure") {
        child.gameObject.SetActive(true);
      }
      else if (child.name == "Destroyed") {
        child.gameObject.SetActive(false);
      }
    }

    destroyed = true;
  }

  private void ShowStructure() {
    foreach (Transform child in transform) {
      if (child.name == "Structure") {
        child.gameObject.SetActive(true);
      }
      else if (child.name == "Destroyed") {
        child.gameObject.SetActive(false);
      }
    }

    destroyed = false;
  }
}
