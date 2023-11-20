using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningObject : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _rigidbody.AddForce(new Vector2(50, 10), ForceMode2D.Impulse);
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            AddForce();
        }
    }

    public void AddForce()
    {
        _rigidbody.AddForce(new Vector2(50, 10), ForceMode2D.Impulse);
    }

    public float GetXSpeed()
    {
        return _rigidbody.velocity.x;
    }
}
