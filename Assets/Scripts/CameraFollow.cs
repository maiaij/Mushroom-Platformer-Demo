using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// edit??

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void Update()
    {
        transform.position = new Vector3(
            target.position.x,
            target.position.y+3,
            transform.position.z);
    }
}