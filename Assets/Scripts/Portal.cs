using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform nextPortal;
    public static Vector3 portalOffset;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Enemy")){
            if(nextPortal != null){
                other.transform.position = nextPortal.position + portalOffset;
                other.transform.rotation = nextPortal.rotation;
            } else{
                Destroy(other.gameObject);
            }
        }
    }
}
