using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RunningObject : MonoBehaviour
{
    public GameObject eventObject;
    private Rigidbody2D _rigidbody;
    private PhysicMaterial _physicMaterial;
    private const float DRAG = 0.05f;
    private float time;
    private GameObject obj;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        AddForce();
    }

    private void Update()
    {
        float velocity = _rigidbody.velocity.x;
        time += Time.deltaTime;
        velocity -= _rigidbody.velocity.x * DRAG * Time.deltaTime;
        Vector2 newVelocity = _rigidbody.velocity;
        newVelocity.x = velocity;
        _rigidbody.velocity = newVelocity;
    }

    public void AddForce()
    {
        _rigidbody.velocity = new Vector2(Mathf.Abs(_rigidbody.velocity.x), Mathf.Abs(_rigidbody.velocity.y));
        _rigidbody.AddForce(new Vector2(50, 10), ForceMode2D.Impulse);
        CalOnGroundTime(_rigidbody.velocity.y);
    }

    void CalOnGroundTime(float yVelocity)
    {
        float timeOnRunningObjectHighest = yVelocity / -Physics2D.gravity.y;
        float distance = (_rigidbody.velocity.x / DRAG) * (1 - Mathf.Exp(-DRAG * timeOnRunningObjectHighest * 2.0f));
        obj = Instantiate(eventObject);
        obj.transform.position = new Vector3(_rigidbody.transform.position.x + distance, 0, 0);
    }

    public float GetXSpeed()
    {
        return _rigidbody.velocity.x;
    }


}
