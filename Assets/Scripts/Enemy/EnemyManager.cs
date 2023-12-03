using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
  static private List<Enemy> ENEMIES;
  static private List<GameObject> enemyObjects;

  [Header("Inscribed: Settings for Spawning Enemies")]
  public GameObject enemyPrefab;
  public Transform enemyAnchor;

  public int maxNumEnemies = 20;
  public float spawnRadius = 50f;

  void Awake() {
    ENEMIES = new List<Enemy>();
    enemyObjects = new List<GameObject>();
    //TODO add a map size to Main class and set this to center of map instead of hard code
    // Vector3 tempPosition = new Vector3(50, 2, 50);
    // this.gameObject.transform.position = tempPosition;
    // print("Enemy spawn position: " + this.gameObject.transform.position); 
  }

  void FixedUpdate() {
    //Use for testing but add automated spawn for all enemies (no key press) for demo
    if (Input.GetKey(KeyCode.X)) {
      InstantiateEnemy();
    }
  }

  public void InstantiateEnemy() {
    GameObject enemyObject = Instantiate<GameObject>(enemyPrefab);
    enemyObjects.Add(enemyObject);
    print("created enemy: " + enemyObject);
    print("All enemies: " + enemyObjects);

    enemyObject.transform.position = enemyAnchor.position;
    print("enemy position: " + enemyObject.transform.position);
    
    Enemy enemy = enemyObject.GetComponent<Enemy>();
    enemy.transform.SetParent(enemyAnchor);
    ENEMIES.Add(enemy);

    if(ENEMIES.Count > maxNumEnemies) {
      destroyEnemy(enemyObjects[0]);
    }

  }

  private void destroyEnemy(GameObject enemyObject) {
    Enemy enemy = enemyObject.GetComponent<Enemy>();

    ENEMIES.Remove(enemy);
    enemyObjects.Remove(enemyObject);
    Destroy(enemyObject);
  }
}
