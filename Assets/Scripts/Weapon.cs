using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Able to select weapon script
[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public Sprite currentWeaponSprite;

    // Sets asset
    public GameObject projectilePrefab;
    public float fireRate = 1;
    public int damage = 20;

    public void Attack()
    {
        // How the weapon moves
        Instantiate(projectilePrefab, GameObject.Find("FirePoint").transform.position, Quaternion.identity);

    }
}
