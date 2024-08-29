using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawningSystem : MonoBehaviour
{
    public List<GameObject> enemyPrefabs;
    public Vector3 offset;
    public void SpawnEnemy(Transform spawnPos){
        Debug.Log("Wave Start!");
        GameObject enemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Count)], spawnPos.position + offset, spawnPos.rotation);
    }
}
