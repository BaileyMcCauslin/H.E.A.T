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
  public Missile[] missiles;

  public int activeMissile;

  enum MISSILE_TYPES {
    basic, 
    he, // high damage, doesn't damage armor
    heat // bypasses armor
  }

  void OnCollisionEnter(Collision collision)
  {
    Missile missile = collision.gameObject.GetComponent<Missle>();

    //checks to see if the collision was a missle
    if (missile != null) {
      TakeDamage(missile);
    }  
  }

  void TakeDamage(float missile) {
    float totalDamage = 0;
    
    switch (missile.type) {
      case MISSILE_TYPES.basic:
        armorHealth -= missile.damage;
        if(armorHealth > 0) {
          totalDamage = missile.damage * armorStrength;
        }
        break;
      case MISSILE_TYPES.he:
        totalDamage = missile.damage - armorHealth;
        break;
      case MISSILE_TYPES.heat:
        armorHealth -= missile.damage / 2;
        totalDamage = missile.damage;
        break;
    }

    health -= totalDamage;
  }

  private void ShootMissile() {
    if (missles[activeMissile] == 0) {
      activeMissile = MISSILE_TYPES.basic;
      //Should update the missle type on the HUD UI
    }

    //shoot the active missle type;
  }
}
