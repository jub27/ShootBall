using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionMark : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D runningObject;

    private void Update()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Vector2.SignedAngle(Vector2.right, runningObject.velocity)));
        //Debug.Log(runningObject.velocity);
    }
}
