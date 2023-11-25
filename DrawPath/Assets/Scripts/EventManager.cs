using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EventManager : MonoBehaviour
{
    [SerializeField]
    private EventObject _eventObjectPrefab;

    private void Awake()
    {
        EventObject.pool = new ObjectPool<EventObject>(OnCreateEventObject, OnGetEventObject, OnReleaseEventObject);
    }

    private EventObject OnCreateEventObject()
    {
        EventObject eventObject = Instantiate(_eventObjectPrefab);
        return eventObject;
    }

    private void OnGetEventObject(EventObject eventObject)
    {
        SetEvent(eventObject);
        eventObject.gameObject.SetActive(true);
    }

    private void OnReleaseEventObject(EventObject eventObject)
    {
        eventObject.gameObject.SetActive(false);
    }

    private void SetEvent(EventObject eventObject)
    {

    }

    public void MakeEvent(Vector3 position)
    {
        var eventObject = EventObject.pool.Get();
        eventObject.transform.position = position;
    }
}
