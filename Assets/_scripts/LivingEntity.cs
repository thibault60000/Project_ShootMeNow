using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// IMPLEMENTE INTERFACE
public class LivingEntity : MonoBehaviour, IDamageables {

    // VARIABLES
    public float startingHealth;
    protected float health;
    protected bool dead;


    // INITIALISATION
    protected virtual void Start()  // virtual permet d'override par Enemy.cs
    {
        health = startingHealth;
    }

    // FONCTION QUI DECREMENTE LA VIE
    public void TakeHit(float damage, RaycastHit hit)
    {
        health -= damage;

        if(health <= 0 && !dead){
            Die();
        }
    }

    // FONCTION LORSQUE L'ENTITE N'A PLUS DE VIE
    protected void Die()
    {
        dead = true;
        GameObject.Destroy(gameObject);
    }
}
