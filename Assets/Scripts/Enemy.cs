using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;

    public float Health {
        set {
            health = value;

            if(health <= 0) {
                Defeated();
            }
        }
        get {
            return health;
        }
    }

    public float health = 4;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damage) {
        health -= damage;

        if(health <= 0) {
            Defeated();
        }

        Debug.Log("Enemy health: " + health);
    }

    public void Defeated(){
        // animator.SetTrigger("Defeated");
        Destroy(gameObject);
    }

    public void RemoveEnemy() {
        Destroy(gameObject);
    }
}
