using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float distance, height, orbitSpeed, changePosSpeed;
    private float currentAngle = 0f;
    public Transform[] targetFocus;
    int i = 0;
    void Look(){
        transform.LookAt(targetFocus[i]);

        if(Input.GetKey(KeyCode.A)){
            currentAngle += orbitSpeed * Time.deltaTime;
        } else if(Input.GetKey(KeyCode.D)){
            currentAngle -= orbitSpeed * Time.deltaTime;
        }

        Vector3 offset = new Vector3(Mathf.Sin(currentAngle) * distance, height, Mathf.Cos(currentAngle) * distance);
        float percentageComplete = Time.deltaTime / changePosSpeed;
        Vector3 startPos = transform.position;
        Vector3 targetPos = new Vector3(targetFocus[i].position.x, targetFocus[i].position.y + 2f, targetFocus[i].position.z);
        transform.position = Vector3.Slerp(startPos, targetPos + offset, percentageComplete);
    }

    void changePos(){
        if(Input.GetKey(KeyCode.Q)){
            if(i > 0)
                i--;
        } else if(Input.GetKey(KeyCode.E)){
            if(i < 3)
                i++;
        }
    }

    void Update()
    {
        Look();
        if(Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E)){
            changePos();
        }
    }
}
