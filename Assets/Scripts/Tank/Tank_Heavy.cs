using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Heavy : Tank
{
  void Awake()
  {
    health = 400;
    maxSpeed = 6f;
    turretTurnSpeed = 20f;
    armorHealth = 200;
    armorStrength = .75f;
    ammunition = new int[] {-1, 10, 4};
  }
}
