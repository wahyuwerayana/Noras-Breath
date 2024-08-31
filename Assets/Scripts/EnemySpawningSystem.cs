using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class EnemySpawningSystem : MonoBehaviour
{
    public List<GameObject> enemyPrefabs;
    public Vector3 offset;
    public Transform spawnPos;
    int enemyTotal;
    int wave = 0;
    float waveCountdown;
    public TMP_Text countdownText;
    public GameObject startButtonParent;
    bool whileBreak = false;
    public void StartWave(){
        StartCoroutine(SpawnEnemy());
        IEnumerator SpawnEnemy(){
            whileBreak = true;
            StopCoroutine(InitiateCountdown());
            countdownText.text = "";
            startButtonParent.gameObject.SetActive(false);
            wave++;
            Debug.Log("Wave: " + wave +  " Start!");
            enemyTotal = (int)GetEnemyTotal(wave);
            int enemyRemaining = enemyTotal;
            Debug.Log(enemyRemaining);
            while(enemyRemaining > 0){
                Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Count)], spawnPos.position + offset, spawnPos.rotation);
                enemyRemaining--;
                //Debug.Log(enemyRemaining);
                yield return new WaitForSeconds(1f);
            }
            whileBreak = false;
            StartCoroutine(InitiateCountdown());
            yield return null;
        }
    }

    float GetEnemyTotal(int currWave){
        if(currWave >= 1 && currWave <= 2)
            return 4;
        else if(currWave >= 3 && currWave <= 4)
            return 5;
        else if(currWave >= 5 && currWave <= 6)
            return 6;
        else if(currWave >= 7 && currWave <= 8)
            return 8;
        else if(currWave >= 9 && currWave <= 10)
            return 10;
        else if(currWave % 10 == 0)
            return ((currWave - 1) / 10) * 2 + 10;
        
        return GetEnemyTotal(currWave - (currWave % 10)) * 1.2f;
    }

    
    IEnumerator InitiateCountdown(){
        Debug.Log("start coroutine");
        waveCountdown = 30f;
        countdownText.text = "Wave " + (wave + 1).ToString() + " in " + waveCountdown + "s";
        while(waveCountdown > 0){
            waveCountdown -= Time.deltaTime;
            countdownText.text = "Wave " + (wave + 1).ToString() + " in " + (waveCountdown).ToString("F0") + "s";
            yield return null;
            if(waveCountdown <= 20f && startButtonParent.gameObject.activeSelf == false && !whileBreak){
                startButtonParent.gameObject.SetActive(true);
            }
            if(whileBreak)
                yield break;
        }
        if(waveCountdown <= 0)
            StartWave();
        yield return null;
    }
}
