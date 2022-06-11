using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawner : MonoBehaviour
{
    private Camera mainCamera;

    [SerializeField]
    private GameObject healthPrefab;

    private float spawnHealthWaitTime;

    [SerializeField]
    private float minHealthSpawnTime = 2.0f, maxHealthSpawnTime = 3.5f;


    [SerializeField]
    private float minYHealthPostition = -3.3f, maxYHealthPosition = 2f;

    private Vector3 healthSpawnPosition = Vector2.zero;

    private GameObject objectToSpawn;

    private void Start()
    {
        mainCamera = Camera.main;
    }
    private void Update()
    {
        HandleHealthSpawn();
    }

    void HandleHealthSpawn()
    {
        if (Time.time > spawnHealthWaitTime)
        {
            spawnHealthWaitTime = Time.time + Random.Range(minHealthSpawnTime, maxHealthSpawnTime);
            if (Random.Range(0, 8) > 6)
            {
                CreateHealth();
            }
        }
    }

    void CreateHealth()
    {
        healthPrefab.SetActive(true);
        healthSpawnPosition.x = mainCamera.transform.position.x + 30f;
        objectToSpawn = Instantiate(healthPrefab);
        healthSpawnPosition.y = Random.Range(minYHealthPostition, maxYHealthPosition);
        objectToSpawn.transform.position = healthSpawnPosition;
    }
}
