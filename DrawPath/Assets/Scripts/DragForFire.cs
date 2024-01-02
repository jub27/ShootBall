using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragForFire : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private Transform fireArrow;

    private Vector2 _fireVector;
    private Vector2 FireVector
    {
        get
        {
            return _fireVector;
        }
        set
        {
            _fireVector = value;
            fireArrow.localScale = new Vector3(_fireVector.magnitude * 0.01f, 1.0f, 1.0f);
            fireArrow.right = _fireVector.normalized;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        FireVector = new Vector2(Mathf.Clamp(FireVector.x + (-eventData.delta.x), 1, 500), Mathf.Clamp(FireVector.y + (-eventData.delta.y), 1, 500));
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        FireVector = Vector2.zero;
    }
}
