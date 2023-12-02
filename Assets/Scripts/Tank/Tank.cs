using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{

  [Header("Inscribed")]
  //Tank
  public float health = 200.0f;
  public float maxSpeed = 20.0f;
  public float armorHealth = 100.0f;
  public float armorStrength = 0.25f;
  public float nextShotTime = 0; //Initialized at zero so you can fire immediately
  // Gun
  public Gun gun;
  public float reloadTime = 50.0f;
  public float turretTurnSpeed = 10.0f;
  [ SerializeField ] GameObject barrelShootingPosition;
  //Missile
  public GameObject missile;
  public float projectileVelocity = 3500.0f;
  

  public int[] ammunition = new int[] {-1, 10, 5};

  public int activeMissile;

  enum MISSILE_TYPES {
    basic, 
    he, // high damage, doesn't damage armor
    heat // bypasses armor
  }

  void Awake() {
    nextShotTime = 0;
  }

  void Update() {
    if (Input.GetKeyDown(KeyCode.RightAlt) || Input.GetKeyDown(KeyCode.LeftAlt)) {
      if (activeMissile == (int)MISSILE_TYPES.heat) {  
        activeMissile = 0;
      }
      else {
        activeMissile += 1;
        return;
      }
    }
    if (Input.GetMouseButtonDown(0)) {
      ShootMissle();
    }

  }

  void OnCollisionEnter(Collision collision)
  {
    Missile missile = collision.gameObject.GetComponent<Missile>();

    //checks to see if the collision was a missle
    if (missile != null) {
      TakeDamage(missile);
    }  
  }

  void TakeDamage(Missile missile) {
    float totalDamage = 0;
    
    switch (missile.type) {
      case (int)MISSILE_TYPES.basic:
        armorHealth -= missile.damage;
        if(armorHealth > 0) {
          totalDamage = missile.damage * armorStrength;
        }
        break;
      case (int)MISSILE_TYPES.he:
        totalDamage = missile.damage - armorHealth;
        break;
      case (int)MISSILE_TYPES.heat:
        armorHealth -= missile.damage / 2;
        totalDamage = missile.damage;
        break;
      default:
        armorHealth -= missile.damage;
        if(armorHealth > 0) {
          totalDamage = missile.damage * armorStrength;
        }
        break;
    }

    health -= totalDamage;
  }

  void ShootMissle() {
    if (!gameObject.activeInHierarchy) {
      return; 
    }
    
    if (ammunition[activeMissile] == 0) {
      activeMissile = (int)MISSILE_TYPES.basic;
      //Should update the missle type on the HUD UI
    }

    if (Time.time < nextShotTime) {
      return;
    } else {
      if (this.ammunition[activeMissile] == 0) {
        activeMissile = (int)MISSILE_TYPES.basic;
        //Should update the missle type on the HUD UI
      }
      
      GameObject currentMissile = Instantiate(missile, 
                            barrelShootingPosition.transform.position, 
                            barrelShootingPosition.transform.rotation);
      currentMissile.GetComponent<Rigidbody>().AddRelativeForce(
              new Vector3(transform.position.x, transform.position.y, projectileVelocity));
    
      nextShotTime = Time.time + reloadTime;
    }
  }
}
