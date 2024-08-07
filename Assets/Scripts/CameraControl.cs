using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float lookSpeed, lookSpeedVertical, upBound, downBound, changePosSpeed;
    public Transform[] towerList;
    float verticalBound = 0f;
    int i = 0;
    void Look(){
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.eulerAngles += new Vector3(0, mouseX * lookSpeed * Time.deltaTime, 0);
        verticalBound += mouseY * lookSpeedVertical * Time.deltaTime;
        verticalBound = Mathf.Clamp(verticalBound, downBound, upBound);
        transform.eulerAngles = new Vector3(verticalBound, transform.eulerAngles.y, transform.eulerAngles.z);
    }

    void changePos(){
        int towerLength = towerList.Length;
            
        if(Input.GetKeyDown(KeyCode.Q)){
            if(i - 1 < 0)
                i = towerLength;
            i--;
        } else if(Input.GetKeyDown(KeyCode.E)){
            if(i + 1 >= towerLength)
                i = -1;
            i++;
        }
    }
    
    void Update()
    {
        Look();
        if(Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E)){
            changePos();
        }
        float percentageComplete = Time.deltaTime / changePosSpeed;
        Vector3 startPos = transform.position;
        Vector3 targetPos = new Vector3(towerList[i].position.x, towerList[i].position.y + 2f, towerList[i].position.z);
        transform.position = Vector3.Lerp(startPos, targetPos, percentageComplete);
    }
}
