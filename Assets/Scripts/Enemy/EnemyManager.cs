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
  public int spawnDistance = 50;

  void Awake() {
    ENEMIES = new List<Enemy>();
    enemyObjects = new List<GameObject>();
    SpawnInitialEnemies();
    //TODO add a map size to Main class and set this to center of map instead of hard code
    // Vector3 tempPosition = new Vector3(50, 2, 50);
    // this.gameObject.transform.position = tempPosition;
    // print("Enemy spawn position: " + this.gameObject.transform.position); 
  }

  void Update() {
    //Use for testing but add automated spawn for all enemies (no key press) for demo
    if (Input.GetKey(KeyCode.X)) {
      SpawnEnemy();
    }
  }

  public void SpawnEnemy() {
    GameObject enemyObject = Instantiate<GameObject>(enemyPrefab);
    enemyObjects.Add(enemyObject);
    print("created enemy: " + enemyObject);
    print("All enemies: " + enemyObjects);

    Vector3 randomSpawn = new Vector3(
      Random.Range(enemyAnchor.position.x - spawnDistance, enemyAnchor.position.x + spawnDistance),
      2,
      Random.Range(enemyAnchor.position.z - spawnDistance, enemyAnchor.position.z + spawnDistance)
    );

    enemyObject.transform.position = randomSpawn;
    print("enemy position: " + enemyObject.transform.position);
    
    Enemy enemy = enemyObject.GetComponent<Enemy>();
    enemy.transform.SetParent(enemyAnchor);
    ENEMIES.Add(enemy);

    if(ENEMIES.Count > maxNumEnemies) {
      destroyEnemy(enemyObjects[0]);
    }

  }

  void SpawnInitialEnemies() {
    for (int i = 0; i < maxNumEnemies; i++) {
      SpawnEnemy();
    }
  }

  private void destroyEnemy(GameObject enemyObject) {
    Enemy enemy = enemyObject.GetComponent<Enemy>();

    ENEMIES.Remove(enemy);
    enemyObjects.Remove(enemyObject);
    Destroy(enemyObject);

    if (ENEMIES.Count == 0) {
      GameManager.manager.EndGame(true);
    }
  }
}
