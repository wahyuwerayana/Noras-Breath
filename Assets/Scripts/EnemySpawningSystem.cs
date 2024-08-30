using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

public class EnemySpawningSystem : MonoBehaviour
{
    public List<GameObject> enemyPrefabs;
    public Vector3 offset;
    public void SpawnEnemy(Transform spawnPos){
        Debug.Log("Wave Start!");
        GameObject enemy = LeanPool.Spawn(enemyPrefabs[Random.Range(0, enemyPrefabs.Count)], spawnPos.position + offset, spawnPos.rotation);
    }
}
