using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    // VARIABLES 
    float speed = 10f;
    float damage = 1;

    // OBJECTS 
    public LayerMask collisionMask;

    // MODIFIER VITESSE PROJECTILE
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }


    // UPDATE
    private void Update()
    {
        float moveDistance = speed * Time.deltaTime;
        transform.Translate(Vector3.forward * moveDistance);
        CheckCollisions(moveDistance);
    }


    // Fonction qui test les collisions du projectile
    void CheckCollisions(float moveDistance)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, moveDistance, collisionMask, QueryTriggerInteraction.Collide))
        {
            // Si le projectile touche quelque chose, on appelle cette fonction
            OnHitObject(hit);
        }
    }


    // Fonction executée si le projectile touche quelque chose
    void OnHitObject(RaycastHit hit)
    {
        IDamageables damageableObject = hit.collider.GetComponent<IDamageables>();
        if(damageableObject != null)
        {
            damageableObject.TakeHit(damage, hit);
        }
        GameObject.Destroy(gameObject);
    }
}
