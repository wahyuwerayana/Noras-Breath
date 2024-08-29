using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Scripting.APIUpdating;

public class Enemy : MonoBehaviour
{
    public float enemyHP;
    public float enemySpeed;
    public static List<Transform> waypoints;
    private int waypointIndex = 0;
    public float offset;


    void Update()
    {
        Move();
        if(transform.position.y <= 0){
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage){
        enemyHP -= damage;
        if(enemyHP <= 0){
            Die();
        }
    }

    void Die(){
        Destroy(gameObject);
    }

    void Move(){
        if(waypointIndex < waypoints.Count){
            Transform target = waypoints[waypointIndex];
            transform.position = Vector3.MoveTowards(transform.position, target.position, enemySpeed * Time.deltaTime);
            

            if(Vector3.Distance(transform.position, target.position) <= offset){
                waypointIndex++;
                Debug.Log("Current Waypoint:" + waypoints[waypointIndex]);
            }
        }
    }
}
