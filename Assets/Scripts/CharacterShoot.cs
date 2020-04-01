﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public string weaponType = "pistol";
    public float fireRate, shot = 0f, semishot = 0f, time;
    public bool canFire = true; // describes whether semiauto guns have a charge
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called one per frame
    void Update()
    {
        if (weaponType == "submachinegun")
            fireRate = 300.0f;
        else if (weaponType == "assualt rifle")
            fireRate = 200.0f;
        else if (weaponType == "pistol")
            fireRate = 60.0f;



        if (Input.GetButton("Fire1"))
        {
            if (weaponType == "pistol" || weaponType == "sniper")
            {
                if (canFire)
                {
                    Shoot();
                    canFire = false;
                    semishot = (fireRate / 60.0f);
                }
            }
            else if (Time.time - shot > 1 / (fireRate / 60))
            {
                shot = Time.time;
                Shoot();
            }
        }
        if (semishot > 0)
            semishot -= Time.deltaTime;
        canFire = (semishot <= 0);
    }

    private void Shoot() {

        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

    }

}