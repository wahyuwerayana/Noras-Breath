using System.Collections.Generic;
using System.Collections;
using Lean.Pool;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemyHP;
    public float enemySpeed;
    public float enemyATKSpeed;
    public static List<Transform> waypoints;
    private int waypointIndex = 0;
    public float offset;
    private Animator animator;
    public LayerMask obstacleLayer;
    public float detectionRange = 1f;
    private float lastAttackTime = 0f;
    public float attackDelay = 2f;
    bool walkSoundEnabled = false;

    private void Start() {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        Move();
        if(transform.position.y <= 0){
            Die();
        }
    }

    public void TakeDamage(float damage){
        enemyHP -= damage;
        if(enemyHP <= 0){
            Die();
        }
    }

    void Die(){
        LeanPool.Despawn(gameObject);
    }

    void Move(){
        if(waypointIndex < waypoints.Count){
            Transform target = waypoints[waypointIndex];
            Vector3 direction = (target.position - transform.position).normalized;

            Debug.DrawRay(transform.position, direction * detectionRange, Color.red);

            if(!IsObstacleInFront(direction)){
                animator.SetFloat("y", 1f);
                Quaternion lookRotation = Quaternion.LookRotation((waypoints[waypointIndex].position - transform.position).normalized);
                transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 1f);
                transform.position = Vector3.MoveTowards(transform.position, target.position, enemySpeed * Time.deltaTime);
                if(!walkSoundEnabled)
                    StartCoroutine(playSound(1f, "Enemy Footstep"));
            } else{
                animator.SetFloat("y", 0f);
                if(Time.time >= lastAttackTime){
                    lastAttackTime = Time.time + attackDelay;
                    Attack();
                }
            }
        }

        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Waypoint")){
            if(waypointIndex < waypoints.Count - 1)
                waypointIndex++;
        }
    }

    IEnumerator playSound(float delay, string soundName){
        walkSoundEnabled = true;
        AudioManager.instance.Play(soundName);
        yield return new WaitForSeconds(delay);
        walkSoundEnabled = false;
    }

    bool IsObstacleInFront(Vector3 direction){
        RaycastHit hit;
        if(Physics.Raycast(transform.position, direction, out hit, detectionRange, obstacleLayer)){
            return true;
        }
        return false;
    }

    void Attack(){
        animator.SetTrigger("attack");
    }
}
