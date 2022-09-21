using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerWeapon : MonoBehaviour
{
    public Weapon currentWeapon;
    public GameObject projectile;

    private float nextTimeOfFire = 0;

    // Update is called once per frame
    private void Update()
    {
        // Mouse button one
        if (Input.GetButton("Fire1"))
        {
            if(Time.time >= nextTimeOfFire)
            {
                currentWeapon.Attack();
                nextTimeOfFire = Time.time + 1 / currentWeapon.fireRate;
            }
        }
    }
}
