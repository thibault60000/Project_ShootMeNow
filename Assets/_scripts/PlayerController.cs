﻿using System.Collections;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    Rigidbody myRigidbody;
    Vector3 velocity;

    // INITIALISATION
    void Start(){
        myRigidbody = GetComponent<Rigidbody>();
    }

    // ASSIGNE LE MOUVEMENT
    public void Move(Vector3 _velocity){
        velocity = _velocity;
    }

    // ASSIGNE LE REGARD 
    public void LookAt(Vector3 lookPoint){
        Vector3 heightCorrectedPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
        transform.LookAt(heightCorrectedPoint);
    }

    // APPELLEE A CHAQUE FRAME (POUR LES FORMES)
    public void FixedUpdate()
    {
        myRigidbody.MovePosition(myRigidbody.position + velocity * Time.fixedDeltaTime);
    }
}
