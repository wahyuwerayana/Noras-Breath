using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button3D : MonoBehaviour
{
    private Material originalMaterial;
    public Material hoverMaterial;
    public Material pressedMaterial;

    private Renderer rendererButton;

    private void Start() {
        rendererButton = GetComponentInChildren<Renderer>();
        originalMaterial = rendererButton.material; 
    }

    private void OnMouseOver() {
        Debug.Log("Mouse Over Button");
    }
}
