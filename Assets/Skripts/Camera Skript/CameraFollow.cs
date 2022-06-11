using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform playerPos;

    [SerializeField]
    private float offsetX = -6f;

    private Vector3 tempPos;

    private void Start()
    {
        FindPlayerRefernece();
    }

    public void FindPlayerRefernece()
    {
        playerPos = GameObject.FindWithTag(TagHelper.playerTag).transform;
    }

    private void LateUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {

        if (!playerPos)
            return;

        tempPos = transform.position;
        tempPos.x = playerPos.position.x - offsetX;
        transform.position = tempPos;

    }

}
