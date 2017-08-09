using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour {

    // Objects
    NavMeshAgent pathfinder;
    Transform target;

	// Initialisation
	void Start () {
        pathfinder = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(UpdatePath()); // Appele la méthode qui calcul la distance du joueur un certain nombre de fois par seconde
	}
	
	// FONCTION APPELLEE A CHAQUE FRAME
	void Update () {
	}

    IEnumerator UpdatePath()
    {
        // Nombre de fois par seconde où l'enemy refresh la position du joueur 
        float refreshRate = 0.25f;

        while( target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, 0, target.position.z);
            pathfinder.SetDestination(targetPosition);
            yield return new WaitForSeconds(refreshRate);
        }
    }
}
