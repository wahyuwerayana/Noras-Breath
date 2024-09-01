using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using TMPro;

public class EnemySpawningSystem : MonoBehaviour
{
    public List<GameObject> enemyPrefabs;
    public Vector3 offset;
    public Transform spawnPos;
    int enemyTotal;
    int wave = 0;
    float waveCountdown;
    public TMP_Text countdownText;
    public TMP_Text numberOfEnemy;
    public GameObject startButtonParent;
    bool whileBreak = false;
    public void StartWave(){
        StartCoroutine(SpawnEnemy());
        IEnumerator SpawnEnemy(){
            numberOfEnemy.gameObject.SetActive(false);
            whileBreak = true;
            StopCoroutine(InitiateCountdown());
            countdownText.text = "";
            startButtonParent.gameObject.SetActive(false);
            wave++;
            //Debug.Log("Wave: " + wave +  " Start!");
            enemyTotal = (int)GetEnemyTotal(wave);
            int enemyRemaining = enemyTotal;
            //Debug.Log(enemyRemaining);
            while(enemyRemaining > 0){
                Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Count)], spawnPos.position + offset, spawnPos.rotation);
                enemyRemaining--;
                //Debug.Log(enemyRemaining);
                if(wave >= 11 && enemyRemaining <= enemyTotal - Mathf.Round((float)(enemyTotal * 0.8f)))
                    StartCoroutine(InitiateCountdown());
                yield return new WaitForSeconds(1f);
            }
            whileBreak = false;
            if(wave < 11)
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
        else if(currWave % 5 == 0)
            return GetEnemyTotal(currWave - 1);
        
        return GetEnemyTotal(currWave - (currWave % 5)) * 1.2f;
    }

    
    IEnumerator InitiateCountdown(){
        waveCountdown = 20f;
        countdownText.text = "Wave " + (wave + 1).ToString() + " in " + waveCountdown + "s";
        numberOfEnemy.text = GetEnemyTotal(wave + 1).ToString("F0");
        while(waveCountdown > 0){
            waveCountdown -= Time.deltaTime;
            countdownText.text = "Wave " + (wave + 1).ToString() + " in " + (waveCountdown).ToString("F0") + "s";
            yield return null;
            if(waveCountdown <= 15f && startButtonParent.gameObject.activeSelf == false && !whileBreak){
                startButtonParent.gameObject.SetActive(true);
            }
            if(whileBreak){
                GameManager.spiritShard += GetBonusShard((int)waveCountdown);
                yield break;
            }
        }
        if(waveCountdown <= 0)
            StartWave();
        yield return null;
    }

    int GetBonusShard(int countdown){
        int countdownClamp = Mathf.Clamp(countdown, 1, 15);
        return (countdownClamp * 5) - 15;
    }

    public void PointerEnter(){
        numberOfEnemy.gameObject.SetActive(true);
    }

    public void PointerExit(){
        numberOfEnemy.gameObject.SetActive(false);
    }

    private void Start() {
        numberOfEnemy.text = GetEnemyTotal(wave + 1).ToString("F0");
    }
}
