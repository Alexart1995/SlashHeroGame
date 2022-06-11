using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject wolfPrefab, spikePrefab, swingPrefab;

    [SerializeField]
    private GameObject[] blades;

    [SerializeField]
    private float spikeYPosition = -3.36f;

    [SerializeField]
    private float wolfYPosition = -2.89f;

    [SerializeField]
    private float bladeMinYPosition = -3f, bladeMaxYPosition = 2f;

    [SerializeField]
    private float swingObstacleMinYPosition = 2.78f, swingObstacleMaxYPosition = 5.22f;

    [SerializeField]
    private float minSpawnTime = 2f, maxSpawnTime = 3.5f;

    private float spawnWaitTime;

    private int obstacleTypesCount = 4;
    private int obstacleToSpawn;

    private Camera mainCamera;

    private Vector3 obstacleSpawnPosition = Vector2.zero;

    private GameObject objectToSpawn;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        HandleObstacleSpawn();
    }

    void HandleObstacleSpawn()
    {
        if (Time.time > spawnWaitTime)
        {
            spawnWaitTime = Time.time + Random.Range(minSpawnTime, maxSpawnTime);
            CreateObstacle();
        }
    }
    void CreateObstacle()
    {
        obstacleToSpawn = Random.Range(0, obstacleTypesCount);

        obstacleSpawnPosition.x = mainCamera.transform.position.x + 20f;
        switch(obstacleToSpawn)
        {
            case 0:
                objectToSpawn = GameObject.Instantiate(wolfPrefab);
                obstacleSpawnPosition.y = wolfYPosition;
                break;
            case 1:
                objectToSpawn = GameObject.Instantiate(swingPrefab);
                obstacleSpawnPosition.y = Random.Range(swingObstacleMinYPosition, swingObstacleMaxYPosition);
                break;
            case 2:
                objectToSpawn = GameObject.Instantiate(spikePrefab);
                obstacleSpawnPosition.y = spikeYPosition;
                break;
            case 3:
                objectToSpawn = GameObject.Instantiate(blades[Random.Range(0, blades.Length)]);
                obstacleSpawnPosition.y = Random.Range(bladeMinYPosition, bladeMaxYPosition);
                break;
        }

        objectToSpawn.transform.position = obstacleSpawnPosition;
    }
}
