using Lean.Pool;
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
                LeanPool.Despawn(other.gameObject);
            }
            AudioManager.instance.Play("Portal Sound");
        }
    }
}
