using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {

    public List<GameObject> enemyTypes;
    public float spawnInterval = 1;

    private List<GameObject> enemyQueue;
    private bool spawnEnemies = false;
    public float spawnAmount = 0;

    public void SetUp() {
        StartCoroutine(SpawnEnemiesInterval());
        enemyQueue = new List<GameObject>();
    }

    public void SpawnEnemies() {
        spawnEnemies = true;
    }

    public void StopEnemySpawn() {
        spawnEnemies = false;
    }

    void Update() {
        if (spawnEnemies && enemyQueue.Count == 0) {
            StopEnemySpawn();
            StopCoroutine(SpawnEnemiesInterval());
        }
    }

    IEnumerator SpawnEnemiesInterval() {
        for (int i = 0; i < spawnAmount; i++) {

            yield return new WaitForSeconds(spawnInterval);

            GameObject go = (GameObject)Instantiate(enemyTypes[Random.Range(0, enemyTypes.Count)], transform.position, transform.rotation);
            enemyQueue.Add(go);
            spawnEnemies = true;
        }
        yield return 0;
    }
}
