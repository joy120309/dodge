using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    public GameObject bulletPrefab;
    private float spawnRateMin = 0.05f;
    private float spawnRateMax = 0.4f;

    private float spawnRate;
    private float timeAfterSpawn;

    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate) 
        {
            timeAfterSpawn = 0f;
            
            // Spawn at completely random X and Z coordinates within the play area (-8 to 8) in the sky (Y = 10)
            float randomX = Random.Range(-8f, 8f);
            float randomZ = Random.Range(-8f, 8f);
            Vector3 spawnPosition = new Vector3(randomX, 10f, randomZ);

            // Face straight down (rotate 90 degrees around X-axis so forward vector points along -Y)
            Quaternion spawnRotation = Quaternion.Euler(90f, 0f, 0f);

            Instantiate(bulletPrefab, spawnPosition, spawnRotation);
            
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
