using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using JyCustomTool;

public class GamePlaySceneManager : MonoBehaviour
{
    [SerializeField]
    private RunningObject runningObject;
    [SerializeField]
    private TextMeshProUGUI distanceText;
    [SerializeField]
    private AudioClip bgm;
    public EventManager EventManager;
    public static GamePlaySceneManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        Application.targetFrameRate = 120;
    }

    private void Start()
    {
        SoundManager.Instance.PlayBGM(bgm, loop: true);
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
