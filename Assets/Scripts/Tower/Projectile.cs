using System.Collections;
using System.Collections.Generic;
using Lean.Pool;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;
    private Transform target;
    private float damage;
    
    public void Seek(Transform _target, float _damage){
        target = _target;
        damage = _damage;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null){
            LeanPool.Despawn(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(direction.magnitude <= distanceThisFrame){
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget(){
        Enemy enemy = target.GetComponent<Enemy>();

        if(enemy != null){
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
