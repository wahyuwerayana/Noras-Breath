using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float enemyMaxHP;
    private float enemyCurrentHP;
    public float enemySpeed;
    public float enemyATKSpeed;
    public int enemyATK;
    public static List<Transform> waypoints;
    private int waypointIndex = 0;
    public float offset;
    private Animator animator;
    public LayerMask obstacleLayer;
    public float detectionRange = 1f;
    private float lastAttackTime = 0f;
    public float attackDelay = 2f;
    public GameObject healthBarPrefab;
    private GameObject healthBar;
    private Slider healthSlider;
    bool walkSoundEnabled = false;
    public float walksoundDelay;
    public bool isDead = false;

    private void Start() {
        animator = GetComponent<Animator>();
        healthBar = Instantiate(healthBarPrefab, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
        healthSlider = healthBar.GetComponentInChildren<Slider>();
        healthBar.transform.SetParent(transform);
        enemyCurrentHP = enemyMaxHP;
        healthSlider.value = enemyCurrentHP / enemyMaxHP;
    }

    void Update()
    {
        if(!isDead)
            Move();
        if(transform.position.y <= 0){
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage){
        enemyCurrentHP -= damage;
        healthSlider.value = enemyCurrentHP / enemyMaxHP;
        if(enemyCurrentHP <= 0){
            isDead = true;
            Die();
        }
    }

    void Die(){
        animator.SetTrigger("die");
        GameManager.spiritShard += 5;
        Destroy(gameObject, 1f);
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
                    StartCoroutine(playSound(walksoundDelay, "Enemy Footstep"));
            } else{
                animator.SetFloat("y", 0f);
                if(Time.time >= lastAttackTime){
                    lastAttackTime = Time.time + attackDelay;
                    Attack(direction);
                }
            }
        }

        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Waypoint")){
            if(waypointIndex < waypoints.Count - 1){
                waypointIndex++;
                //Debug.Log("Current Waypoint: " + other.name);
            }
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

    void Attack(Vector3 direction){
        animator.SetTrigger("attack");
        RaycastHit hit;
        if(Physics.Raycast(transform.position, direction, out hit, detectionRange, obstacleLayer)){
            hit.transform.GetComponent<Barricade>().BarricadeTakeDamage(enemyATK);
            enemyCurrentHP -= hit.transform.GetComponent<Barricade>().InflictPoison();
        }
    }
}
