using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildObjectController : MonoBehaviour
{
    public Transform currentTransform;
    public GameObject barricade;
    public GameObject[] tower;

    public void BuildBarricade()
    {
        Instantiate(barricade, currentTransform.position, currentTransform.rotation * Quaternion.Euler(0, 90, 0));
        ClickableObject clickableObject = currentTransform.GetComponent<ClickableObject>();
        clickableObject.ResetState();
        Destroy(currentTransform.gameObject);
    }

    public void BuildTower(){
        Instantiate(tower[Random.Range(0, tower.Length - 1)], currentTransform.position, Quaternion.Euler(0, 0, 0));
        ClickableObject clickableObject = currentTransform.GetComponent<ClickableObject>();
        clickableObject.ResetState();
    }
}
