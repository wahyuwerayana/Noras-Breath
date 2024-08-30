using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickableObject : MonoBehaviour
{
    [Header("Button Reference")]
    private GameObject canvas;
    private GameObject multiButton;
    private Button singleButton;
    public bool needTwoButton;
    private BuildObjectController buildObjectControllerReference;

    
    private static ClickableObject previousClickableObject = null;
    bool currentState = false, hovering = false;
    private void OnMouseOver(){
        hovering = true;
        
        if(Input.GetMouseButtonDown(0)){
            if(previousClickableObject != null && previousClickableObject != this)
                previousClickableObject.ResetState();

            currentState = !currentState;
            buildObjectControllerReference.currentTransform = this.transform;
            if(needTwoButton){
                multiButton.transform.position = multiButton.transform.position = new Vector3(transform.position.x, transform.position.y + .5f, transform.position.z);
                multiButton.SetActive(currentState);
            } else if(!needTwoButton){
                singleButton.transform.position = singleButton.transform.position = new Vector3(transform.position.x, transform.position.y +.5f, transform.position.z);
                singleButton.gameObject.SetActive(currentState);
            }

            previousClickableObject = this;
        }
    }

    private void OnMouseExit() {
        hovering = false;
    }

    private void Start() {
        canvas = GameObject.Find("Button Canvas");
        singleButton = canvas.transform.GetChild(0).GetComponent<Button>();
        multiButton = canvas.transform.GetChild(1).gameObject;
        if(gameObject.name == "Ground")
            needTwoButton = true;
        buildObjectControllerReference = canvas.GetComponent<BuildObjectController>();
    }
    
    private void Update(){
        if(currentState && !hovering && Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()){
            ResetState();
        } 
    }

    public void ResetState(){
        currentState = false;
        singleButton.gameObject.SetActive(false);
        multiButton.gameObject.SetActive(false);
    }
}