using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class PathDrawManager : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Queue<Vector3> positions;
    private Vector3? lastPosition;
    private void Awake()
    {
        lastPosition = null;
        positions = new Queue<Vector3>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        worldPosition.z = 0;
        if (lastPosition.HasValue)
            if (Vector3.Distance(worldPosition, lastPosition.Value) < 0.2f)
                return;
        positions.Enqueue(worldPosition);
        lastPosition = worldPosition;
        if (positions.Count > 200)
            positions.Dequeue();
        lineRenderer.positionCount = positions.Count;
        lineRenderer.SetPositions(positions.ToArray());
    }
}
