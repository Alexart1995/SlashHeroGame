using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepositionBackGround : MonoBehaviour
{
    private GameObject[] backgronds;

    [SerializeField]
    private string backgroundTag;
    private float maxXPosition;
    private float offsetValue;
    private float newXPosition;
    private Vector3 newPosition;
    private float generateLevelWaitTime = 2f;
    private float waitTime;
    private void Awake()
    {
        backgronds = GameObject.FindGameObjectsWithTag(backgroundTag);
        offsetValue = backgronds[0].GetComponent<BoxCollider2D>().bounds.size.x;
        maxXPosition = backgronds[0].transform.position.x;
        for (int i = 0; i < backgronds.Length; i++)
        {
            if (backgronds[i].transform.position.x > maxXPosition)
                maxXPosition = backgronds[i].transform.position.x;
        }
    }

    private void Start()
    {

    }

    private void Update()
    {
        CheckToSpawnLevel();
    }

    void CheckToSpawnLevel()
    {
        if (Time.time > waitTime)
        {
            GenerateGrounds();
            waitTime = Time.time + generateLevelWaitTime;
        }
    }
    private void GenerateGrounds()
    {
        GameObject background = GameObject.Instantiate(backgronds[0]);
        newXPosition = maxXPosition + offsetValue;
        maxXPosition = newXPosition;
        newPosition = background.transform.position;
        newPosition.x = newXPosition;
        newPosition.y = backgronds[0].transform.position.y;
        background.transform.position = newPosition;
    }
}
