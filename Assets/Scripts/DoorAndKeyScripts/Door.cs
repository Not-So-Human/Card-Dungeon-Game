using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject doorGate;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if ((collider.gameObject.name == "Player") && (PlayerVariablesAndItems.keyCount > 0))
        {
            PlayerVariablesAndItems.keyCount--;
            Destroy(doorGate);
        }
    }
}
