using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float speed;
    private void Update()
    {
        transform.Translate(speed * Vector3.right * Time.deltaTime);
    }
}
