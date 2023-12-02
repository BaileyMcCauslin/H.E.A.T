using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Medium : Tank
{
  void Awake()
  {
    health = 200;
    speed = 9f;
    turretTurnSpeed = 40f;
    armorHealth = 100;
    armorStrength = .50f;
    missles = new int[] {-1, 5, 4};

  }
}
