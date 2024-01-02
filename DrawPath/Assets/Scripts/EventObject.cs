using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EventObject : MonoBehaviour
{
    public static ObjectPool<EventObject> pool;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<RunningObject>().AddForce();
    }

    private void OnBecameInvisible()
    {
        pool.Release(this);
    }
}