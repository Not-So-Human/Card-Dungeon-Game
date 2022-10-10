using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Player")
        {
            PlayerVariablesAndItems.CoinCount+=5;
            Destroy(gameObject);
        }
    }
}
