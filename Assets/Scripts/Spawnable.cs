using UnityEngine;

public class Spawnable : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the object moves in the -z direction

    void Update()
    {
        // Move the spawnable object in the -z direction
        transform.Translate(moveSpeed * Time.deltaTime * Vector3.back);

        // Destroy the object if it goes off-screen (behind the player)
        if (transform.position.z < -50f) // Adjust this value depending on your scene setup
        {
            Destroy(gameObject);
        }
    }
}
