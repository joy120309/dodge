using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    public GameObject bulletPrefab;
    private float spawnRateMin = 0.5f;
    private float spawnRateMax = 4f;

    private Transform target;
    private float spawnRate;
    private float timeAfterSpawn;
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindAnyObjectByType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate) 
        {
            timeAfterSpawn = 0f;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, target.rotation);
            bullet.transform.LookAt(target);
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
