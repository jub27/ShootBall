using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    [SerializeField]
    private Transform runningObject;

    // Update is called once per frame
    void Update()
    {
        Vector3 position = runningObject.position;
        position.y = 0f;
        position.z = 0f;
        transform.position = position;
    }
}