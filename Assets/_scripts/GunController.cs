﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    Gun equippedGun;
    public Transform weaponHold;
    public Gun startingGun;

    private void Start()
    {
        if (startingGun != null)
            EquipGun(startingGun);
    }

    public void EquipGun(Gun gunToEquip)
    {
        if (equippedGun != null)
            Destroy(equippedGun.gameObject);

           equippedGun = Instantiate(gunToEquip, weaponHold.position, weaponHold.rotation) as Gun;
           equippedGun.transform.parent = weaponHold;

    }
}
