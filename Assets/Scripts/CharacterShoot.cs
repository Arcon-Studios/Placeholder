using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public string weaponType = "pistol";
    private float fireRate, shot = 0f, semishot = 0f, time, dmg = 0.0f;
    private bool canFire = true, fired = false; // describes whether semiauto guns have a charge
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called one per frame
    void Update()
    {
        if (weaponType == "smg")
        {
            fireRate = 300.0f;
            dmg = 5.0f;
        }
        else if (weaponType == "ar")
        {
            fireRate = 200.0f;
            dmg = 10.0f;
        }
        else if (weaponType == "pstl")
        {
            fireRate = 60.0f;
            dmg = 5.0f;
        }
        else if (weaponType == "snip")
        {
            fireRate = 20.0f;
            dmg = 30.0f;
        }


        if (Input.GetButton("Fire1"))
        {
            if (weaponType == "pstl" || weaponType == "snip")
            {
                if (canFire && !fired)
                {
                    Shoot();
                    canFire = false;
                    semishot = (60.0f / fireRate);
                }
            }
            else if (Time.time - shot > 1 / (fireRate / 60))
            {
                shot = Time.time;
                Shoot();
            }
            fired = true;
        }
        if (semishot > 0)
            semishot -= Time.deltaTime;
        canFire = (semishot <= 0);

        if (Input.GetKeyUp("mouse 0"))
            fired = false;   
    }

    private void Shoot() {
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bscrip = bullet.GetComponent<Bullet>();
        bscrip.setdmg(dmg);
    }

}