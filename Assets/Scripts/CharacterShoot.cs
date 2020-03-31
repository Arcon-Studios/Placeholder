using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public string weaponType = "pistol";
    public float fireRate, shot = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called one per frame
    void Update()
    {
        if (weaponType == "pistol")
            fireRate = 60.0f;
        if (weaponType == "submachinegun")
            fireRate = 300.0f;

        if (Input.GetButton("Fire1"))
        {
            if (Time.time - shot > 1 / (fireRate / 60))
            {
                shot = Time.time;
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
