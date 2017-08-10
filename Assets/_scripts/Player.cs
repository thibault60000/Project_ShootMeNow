using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(GunController))]
public class Player : LivingEntity {

    // PUBLIC
    public float moveSpeed = 5f;

    // OBJECTS 
    PlayerController controller;
    GunController gunController;
    Camera viewCamera;

	// INITIALISATION
	protected override void Start () {
        base.Start(); // Gère l'ovveride de LivingEntity.cs
        controller = GetComponent<PlayerController>();
        gunController = GetComponent<GunController>();
        viewCamera = Camera.main;
	}
	
	// UPDATE (UNE FOIS PAR FRAME)
	void Update () {
        // Gérer les Inputs pour le mouvement
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized.normalized * moveSpeed;
        controller.Move(moveVelocity);

        // Récupérer la où la souris est sur la caméra
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            Debug.DrawLine(ray.origin, point, Color.red);
            controller.LookAt(point);
        }

        // Gérer les Inputs liés à l'arme
        if (Input.GetMouseButton(0))
        {
            gunController.Shoot();
        }
	}
}
