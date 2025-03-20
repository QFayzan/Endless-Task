using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject coinPrefab; // Coin prefab
    public GameObject bombPrefab; // Bomb prefab
    public GameObject lifePrefab;
    public float spawnInterval = 2f; // Time interval between spawns
    public float spawnYValue = 10f; // Y position for the spawn
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0f; // Reset timer
        }
    }

    void SpawnObject()
    {
        // Random x position between -32 and 32
        float randomX = Random.Range(-32f, 32f);

        // Randomly choose between a coin or a bomb
        //GameObject objectToSpawn = Random.Range(0f, 1f) > 0.5f ? coinPrefab : bombPrefab;
        // Spawn the object at the random x position and given y value
        //Instantiate(objectToSpawn, new Vector3(randomX, spawnYValue, 0f), Quaternion.identity);
        int randomValue = Random.Range(0, 100);
        {
            if(randomValue <40)
            {
                Instantiate(bombPrefab, new Vector3(randomX, spawnYValue, 0f), Quaternion.identity);
            }
            else if (randomValue >95)
            {
                Instantiate(lifePrefab, new Vector3(randomX, spawnYValue, 0f), Quaternion.identity);
            }
            else
            {   
                Instantiate(coinPrefab, new Vector3(randomX, spawnYValue, 0f), Quaternion.identity);
            } 
        }
    }
}
