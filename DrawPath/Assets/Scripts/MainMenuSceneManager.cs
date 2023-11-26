using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSceneManager : MonoBehaviour
{
    public void OnGamePlayButtonClick()
    {
        SceneManager.LoadScene("GamePlayScene");
    }
}
