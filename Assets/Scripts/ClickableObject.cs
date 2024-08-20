using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickableObject : MonoBehaviour
{
    [Header("Button Reference")]
    public GameObject button;

    bool currentState = false, hovering = false;
    private void OnMouseOver(){
        hovering = true;
        if(Input.GetMouseButtonDown(0)){
            currentState = !currentState;
            button.SetActive(currentState);
        }
    }

    private void OnMouseExit() {
        hovering = false;
    }

    private void Update(){
        if(currentState && Input.GetMouseButtonDown(0) && hovering == false && !EventSystem.current.IsPointerOverGameObject()){
            currentState = false;
            button.SetActive(currentState);
        }

        if(button.activeSelf == false && currentState == true){
            currentState = false;
        }
    } 
}
