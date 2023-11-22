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
        Vector3 position = new Vector3(runningObject.position.x, transform.position.y, transform.position.z);
        transform.position = position;
    }
}