using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingObstacle : MonoBehaviour
{

    [SerializeField]
    private float rotateSpeed = 100f;

    private float zAngle;

    private float minZRotation = -0.6f;
    private float maxZRotation = 0.6f;


    private void Start()
    {
        if (Random.Range(0, 2) > 0)
            rotateSpeed *= -1;
    }
    private void Update()
    {
        SwingWithTransform();
    }
    void SwingWithTransform()
    {
        zAngle += Time.deltaTime * rotateSpeed;
        transform.rotation = Quaternion.AngleAxis(zAngle, Vector3.forward);

        if (transform.rotation.z < minZRotation)
            rotateSpeed = Mathf.Abs(rotateSpeed);
        if (transform.rotation.z > maxZRotation)
            rotateSpeed = -Mathf.Abs(rotateSpeed);
    }
}
