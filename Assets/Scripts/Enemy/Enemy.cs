using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float EnemyHP;
    public Transform targetPos;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = targetPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage){
        EnemyHP -= damage;
        if(EnemyHP <= 0){
            Die();
        }
    }

    void Die(){
        Destroy(gameObject);
    }
}
