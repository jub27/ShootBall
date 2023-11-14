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
        inputPosition.x = Screen.width / 2.0f;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(inputPosition);
        worldPosition.z = 0;
        positions.Enqueue(worldPosition);
        lastPosition = inputPosition;
        if (positions.Count > 100)
            positions.Dequeue();
        lineRenderer.positionCount = positions.Count;
        lineRenderer.SetPositions(positions.ToArray());
    }
}
