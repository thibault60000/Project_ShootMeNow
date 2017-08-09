using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    // PUBLIC 
    float speed = 10f;


    // MODIFIER VITESSE PROJECTILE
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    // UPDATE
    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
