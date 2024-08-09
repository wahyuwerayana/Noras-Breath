using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float distance, orbitSpeed;
    private float currentAngle = 0f;
    public Transform[] towerList;
    public Transform targetFocus;
    int i = 0;
    void Look(){
        transform.LookAt(targetFocus);

        if(Input.GetKey(KeyCode.A)){
            currentAngle += orbitSpeed * Time.deltaTime;
        } else if(Input.GetKey(KeyCode.D)){
            currentAngle -= orbitSpeed * Time.deltaTime;
        }

        Vector3 offset = new Vector3(Mathf.Sin(currentAngle) * distance, 5, Mathf.Cos(currentAngle) * distance);
        transform.position = targetFocus.position + offset;
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
        // if(Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E)){
        //     changePos();
        // }
        // float percentageComplete = Time.deltaTime / changePosSpeed;
        // Vector3 startPos = transform.position;
        // Vector3 targetPos = new Vector3(towerList[i].position.x, towerList[i].position.y + 2f, towerList[i].position.z);
        // transform.position = Vector3.Lerp(startPos, targetPos, percentageComplete);
    }
}
