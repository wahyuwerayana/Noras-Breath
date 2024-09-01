using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildObjectController : MonoBehaviour
{
    public Transform currentTransform;
    public GameObject barricade;
    public GameObject[] tower;
    private GameManager gameManagerScript;

    private void Start() {
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    public void BuildBarricade()
    {
        if(GameManager.spiritShard < 125){
            StartCoroutine(gameManagerScript.DisplayWarningText("Spirit Shard is Not Enough!"));
            return;
        }

        gameManagerScript.ReduceSpiritShard(125);
        Instantiate(barricade, currentTransform.position, currentTransform.rotation * Quaternion.Euler(0, 90, 0));
        ClickableObject clickableObject = currentTransform.GetComponent<ClickableObject>();
        clickableObject.ResetState();
        Destroy(currentTransform.gameObject);
    }

    public void BuildTower(){
        if(GameManager.spiritShard < 100){
            StartCoroutine(gameManagerScript.DisplayWarningText("Spirit Shard is Not Enough!"));
            return;
        }
        
        gameManagerScript.ReduceSpiritShard(100);
        Instantiate(tower[Random.Range(0, tower.Length - 1)], currentTransform.position, Quaternion.Euler(0, 0, 0));
        ClickableObject clickableObject = currentTransform.GetComponent<ClickableObject>();
        clickableObject.ResetState();
    }
}
