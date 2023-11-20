using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UIElements;


public class PathDrawManager : MonoBehaviour
{
    [SerializeField]
    private RunningObject runningObject;
    private LineRenderer lineRenderer;
    private Queue<Vector3> positions;
    private Vector3? lastPosition;
    private EdgeCollider2D edgeCollider;
    private void Awake()
    {
        lastPosition = null;
        positions = new Queue<Vector3>();
        lineRenderer = GetComponent<LineRenderer>();
        edgeCollider = GetComponent<EdgeCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        Vector3 inputPosition = Input.mousePosition;
#elif UNITY_ANDROID
        Vector3 inputPosition;
        if (Input.touchCount <= 0)
        {
            if (lastPosition.HasValue)
                inputPosition = lastPosition.Value;
            else
                inputPosition = new Vector2(Screen.width / 2.0f, Screen.height / 2.0f);
        }
        else
            inputPosition = Input.GetTouch(0).position;
#endif
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(inputPosition);
        worldPosition.z = 0;
        worldPosition.x = runningObject.transform.position.x + 0.07f;
        positions.Enqueue(worldPosition);
        lastPosition = inputPosition;
        if (positions.Count > 500)
            positions.Dequeue();
        lineRenderer.positionCount = positions.Count;
        lineRenderer.SetPositions(positions.ToArray());
        edgeCollider.SetPoints(positions.Select(item => new Vector2(item.x, item.y)).ToList());
    }
}
