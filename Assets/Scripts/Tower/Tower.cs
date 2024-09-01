using System.Collections;
using System.Collections.Generic;
using Lean.Pool;
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

    private List<Transform> targets = new List<Transform>();

    private void Start() {
        //towerShootSound = AudioManager.instance.
    }


    private void Update() {
        targets.RemoveAll(target => target == null || target.GetComponent<Enemy>().isDead);

        FindTargets();
        if(targets.Count > 0){
            if(fireCountdown <= 0f){
                foreach(var target in targets){
                    Shoot(target);
                }
                AudioManager.instance.Play("Tower Hit");
                fireCountdown = 1f / towerATKSpeed;
            }
            
            fireCountdown -= Time.deltaTime;
        } 
        // else{
        //     FindTargets();
        // }
    }

    void FindTargets(){
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        targets.Clear();

        foreach(GameObject enemy in enemies){
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy <= towerRange && !enemy.GetComponent<Enemy>().isDead){
                targets.Add(enemy.transform);
                if(targets.Count >= 3)
                    break;
            }
        }
    }

    void Shoot(Transform target){
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
