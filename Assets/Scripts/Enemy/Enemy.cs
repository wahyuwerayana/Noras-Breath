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
    public Transform islandParent;
    public List<Transform> waypoints;
    public Transform waypointsParent;
    private int waypointIndex = 0;
    public float offset;

    private void Start() {
        islandParent = GameObject.Find("Island Parent").transform;
        for(int i = 0; i < 1; i++){
            Transform currentIsland = islandParent.GetChild(i);
            waypointsParent = currentIsland.Find("Waypoint Parent").transform;
            if(waypointsParent != null){
                for(int j = 0; j < waypointsParent.childCount; j++){
                    waypoints.Add(waypointsParent.GetChild(j));
                }
            } else{
                Debug.Log("Tidak dapet Waypoint Parentnya");
            }
        }

        transform.position = waypoints[0].transform.position;
        Debug.Log(waypoints[0].transform.position);
    }

    void Update()
    {
        Move();
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
            }
        }
    }
}
