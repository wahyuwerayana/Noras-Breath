using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFaceCamera : MonoBehaviour
{
    [Header("Camera Reference")][SerializeField]
    private Camera mainCamera;

    private void Start() {
        mainCamera = Camera.main;
    }
    
    void Update()
    {
        transform.LookAt(mainCamera.transform);
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y + 180f, 0f);
    }
}
