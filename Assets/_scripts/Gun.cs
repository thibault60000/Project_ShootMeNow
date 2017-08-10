﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    // VARIABLES 
    public float msBetweenShots = 100f;
    public float muzzleVelocity = 35f;
    float nextShotTime;

    // OBJECTS 
    public Transform muzzle;
    public Projectile projectile;

    // TIRER
    public void Shoot()
    {
        if(Time.time > nextShotTime)
        {
            nextShotTime = Time.time + msBetweenShots / 1000;
            Projectile newProjectile = Instantiate(projectile, muzzle.position, muzzle.rotation) as Projectile;
            newProjectile.SetSpeed(muzzleVelocity);
        }
        
    }
}
