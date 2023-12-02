using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tank : MonoBehaviour
{

  public float health; //Health value to be read by 
  public float speed;
  public float turretTurnSpeed;
  public float armorHealth;
  public float armorStrength; //A percentage value that reduces damage
  public Weapon weapon; // Could be used to change the weapon on the tank
  public Missle[] missles;

  public int activeMissle;

  enum MISSLE_TYPES {
    basic, 
    he, // high damage, doesn't damage armor
    heat // bypasses armor
  }

  void OnCollisionEnter(Collision collision)
  {
    Missle missle = collision.gameObject.GetComponent<Missle>();

    //checks to see if the collision was a missle
    if (missle != null) {
      TakeDamage(missle);
    }  
  }

  private virtual void TakeDamage(float missle) {
    float totalDamage;
    
    switch (missle.type) {
      case: MISSLE_TYPES.basic
        armorHealth -= missle.damage;
        if(armorHealth > 0) {
          totalDamage = missle.damage * armorStrength;
        }
        break;
      case: MISSLE_TYPES.he
        totalDamage = missle.damage - armorHealth;
      case: MISSLE_TYPES.heat
        armorHealth -= missle.damage / 2;
        totalDamage = missle.damage;
    }

    health -= totalDamage;
  }

  private void ShootMissle() {
    if (missles[activeMissle] == 0) {
      activeMissle = MISSLE_TYPES.basic;
      //Should update the missle type on the HUD UI
    }

    //shoot the active missle type;
  }
}
