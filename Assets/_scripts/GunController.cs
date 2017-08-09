using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    // OBJECTS 
    Gun equippedGun;

    // PUBLIC
    public Transform weaponHold;
    public Gun startingGun;


    // INITIALISATION
    private void Start()
    {
        if (startingGun != null)
            EquipGun(startingGun);
    }

    // FONCTION QUI GERER LE FAIT D'EQUIPER UNE ARME
    public void EquipGun(Gun gunToEquip)
    {
        if (equippedGun != null)
            Destroy(equippedGun.gameObject);

           equippedGun = Instantiate(gunToEquip, weaponHold.position, weaponHold.rotation) as Gun;
           equippedGun.transform.parent = weaponHold;

    }

    // FONCTION QUI GERE LE TIR
    public void Shoot()
    {
        if(equippedGun != null)
        {
            equippedGun.Shoot();
        }
    }
}
