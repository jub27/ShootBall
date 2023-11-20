using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField]
    private RunningObject _runningObject;
    [SerializeField]
    private Image[] _backgroundImages;

    private void Update()
    {
        for(int i = 0; i < _backgroundImages.Length; i++)
        {
            _backgroundImages[i].material.SetTextureOffset("_MainTex", new Vector4(_runningObject.transform.position.x * i / 200.0f, 0));
        }
    }
}
