using System.Collections;
using UnityEngine;

public class KeyPickupAndDestroy : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Player")
        {
            PlayerVariablesAndItems.keyCount ++;
            Destroy (gameObject);
        }
    }
}
