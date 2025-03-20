using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Destroy any object that enters the trigger zone (offscreen behind the player)
        Destroy(other.gameObject);
    }
}
