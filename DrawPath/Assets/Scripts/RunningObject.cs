using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent (typeof (Rigidbody2D))]
public class RunningObject : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private const float DRAG = 0.05f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.gravityScale = 0;
    }

    private void Update()
    {
        float velocity = _rigidbody.velocity.x;
        velocity -= _rigidbody.velocity.x * DRAG * Time.deltaTime;
        Vector2 newVelocity = _rigidbody.velocity;
        newVelocity.x = velocity;
        _rigidbody.velocity = newVelocity;
    }

    public void AddForce()
    {
        _rigidbody.velocity = new Vector2(0, 0);
        _rigidbody.AddForce(new Vector2(Random.Range(20, 50), 10), ForceMode2D.Impulse);
        CalOnGroundTime(_rigidbody.velocity.y);
    }

    void CalOnGroundTime(float yVelocity)
    {
        float timeOnRunningObjectHighest = yVelocity / -Physics2D.gravity.y;
        float distance = (_rigidbody.velocity.x / DRAG) * (1 - Mathf.Exp(-DRAG * timeOnRunningObjectHighest * 2.0f));
        GamePlaySceneManager.Instance.EventManager.MakeEvent(new Vector3(_rigidbody.transform.position.x + distance, 0, 0));
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log(222);
    }
}
