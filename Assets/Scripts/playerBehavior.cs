using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBehavior : MonoBehaviour
{
    void Update()
    {
        // Testing Input To Take Damage
        if (Input.GetKeyDown(KeyCode.F))
        {
            PlayerTakeDmg(20);
            Debug.Log("Health: " + GameManager.gameManager._playerHealth.healthAmount);
        }
        // Testing Input To Heal
        if (Input.GetKeyDown(KeyCode.G))
        {
            PlayerHeal(10);
            Debug.Log("Health: " + GameManager.gameManager._playerHealth.healthAmount);
        }
    }

    private void PlayerTakeDmg(int dmg)
    {
        // Applies the damage function (subracting health)
        GameManager.gameManager._playerHealth.Dmg(dmg);
    }
    private void PlayerHeal(int healing)
    {
        // Applies the healing function (adding health)
        GameManager.gameManager._playerHealth.Heal(healing);
    }
}
