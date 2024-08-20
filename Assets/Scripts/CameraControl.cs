using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [Header("Camera Properties")]
    public float distance;
    public float height;
    public float orbitSpeed; 
    public float changePosSpeed;
    private float currentAngle = 0f;
    [SerializeField]
    private float cooldown;
    
    [Header("Arena Lookat")]
    public Transform[] targetFocus;
    
    int i = 0;
    bool onCooldown = false;
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

    IEnumerator ChangePos(float cooldown){
        onCooldown = true;

        if(Input.GetKey(KeyCode.Q)){
            if(i > 0)
                i--;
        } else if(Input.GetKey(KeyCode.E)){
            if(i < targetFocus.Length - 1)
                i++;
        }

        yield return new WaitForSeconds(cooldown);
        onCooldown = false;
    }

    void Update()
    {
        Look();
        if((Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E)) && !onCooldown){
            StartCoroutine(ChangePos(cooldown));
        }
    }
}
