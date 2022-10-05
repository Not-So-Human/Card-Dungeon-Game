using UnityEngine;

public class Door : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if ((collider.gameObject.name == "Player") && (PlayerVariablesAndItems.keyCount > 0))
        {
            PlayerVariablesAndItems.keyCount--;
            Destroy(gameObject);
        }
    }
}
