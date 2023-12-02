using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuSceneManager : MonoBehaviour
{
    private const float BACKGROUND_SCROLL_SPEED = 0.3f;
    [SerializeField]
    private Image _backgroundImage;
    private float passedTime;

    private void Awake()
    {
        passedTime = 0;
    }

    private void Update()
    {
        //passedTime += Time.deltaTime;
        //_backgroundImage.material.SetTextureOffset("_MainTex", new Vector2(BACKGROUND_SCROLL_SPEED * passedTime, 0));
    }

    public void OnGamePlayButtonClick()
    {
        SceneManager.LoadScene("GamePlayScene");
    }
}
