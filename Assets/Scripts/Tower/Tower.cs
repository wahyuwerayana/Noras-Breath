using System.Collections;
using System.Collections.Generic;
using Lean.Pool;
using Unity.VisualScripting;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float towerHP;
    public float towerRange;
    public float towerATK;
    public float towerATKSpeed;
    public Transform firePoint;
    public GameObject projectilePrefab;
    private float fireCountdown = 0f;

    private Transform target;

    private void Update() {
        if(target != null && target.GetComponent<Enemy>().isDead)
            target = null;

        FindTarget();

        if(target != null){
            if(fireCountdown <= 0f){
                Shoot();
                fireCountdown = 1f / towerATKSpeed;
            }

            fireCountdown -= Time.deltaTime;
        }
    }

    void FindTarget(){
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies){
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if((distanceToEnemy < shortestDistance) && enemy.GetComponent<Enemy>().isDead == false){
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if((nearestEnemy != null && shortestDistance <= towerRange) && nearestEnemy.GetComponent<Enemy>().isDead == false){
            target = nearestEnemy.transform;
        } else{
            target = null;
        }
    }

    void Shoot(){
        GameObject projectileGO = (GameObject)LeanPool.Spawn(projectilePrefab, firePoint.position, firePoint.rotation);
        Projectile projectile = projectileGO.GetComponent<Projectile>();

        if(projectile != null){
            projectile.Seek(target, towerATK);
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, towerRange);
    }
}
