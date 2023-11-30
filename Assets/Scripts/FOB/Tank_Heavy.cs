using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Heavy : Tank
{
  void Awake()
  {
    health = 400;
    speed = 6f;
    turretTurnSpeed = 20f;
    armorHealth = 200;
    armorStrength = .75f;
    missles = {-1, 10, 4};
  }
}
