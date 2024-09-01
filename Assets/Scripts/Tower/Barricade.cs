using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : MonoBehaviour
{
    private int currentHealth;
    public int maxHealth = 100;
    public int barricadeATK;
    public GameObject patchClick;

    private void Start() {
        currentHealth = maxHealth;
    }

    public void BarricadeTakeDamage(int damage){
        currentHealth -= damage;
        if(currentHealth <= 0){
            SpawnClickableObject();
            Destroy(gameObject);
        }
    }

    public void SpawnClickableObject(){
        Instantiate(patchClick, gameObject.transform.position, gameObject.transform.rotation * Quaternion.Euler(0, 90, 0));
    }

    public int InflictPoison(){
        AudioManager.instance.Play("Poison Bush Hit");
        return barricadeATK;
    }
}
