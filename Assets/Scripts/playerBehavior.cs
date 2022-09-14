using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            PlayerTakeDmg(20);
            Debug.Log(GameManager.gameManager._playerHealth.healthAmount);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            PlayerHeal(10);
            Debug.Log(GameManager.gameManager._playerHealth.healthAmount);
        }
    }

    private void PlayerTakeDmg(int dmg)
    {
        GameManager.gameManager._playerHealth.Dmg(dmg);
    }
    private void PlayerHeal(int healing)
    {
        GameManager.gameManager._playerHealth.Heal(healing);
    }
}
