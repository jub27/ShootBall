using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UIElements;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    private RunningObject runningObject;
    [SerializeField]
    private TextMeshProUGUI distanceText;

    private void Awake()
    {
        Application.targetFrameRate = 120;
    }

    // Update is called once per frame
    void Update()
    {
        SetDistanceText(Mathf.FloorToInt(runningObject.transform.position.x).ToString());
    }

    private void SetDistanceText(string distance)
    {
        distanceText.text = $"{distance}m";
    }
}
