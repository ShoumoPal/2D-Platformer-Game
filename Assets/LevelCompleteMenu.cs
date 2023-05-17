using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelCompleteMenu : MonoBehaviour
{
    public Button mainMenuButton;
    public Button nextButton;
    private void Awake()
    {
        mainMenuButton.onClick.AddListener(OpenMainMenu);
        nextButton.onClick.AddListener(LoadNextLevel);

    }
    void OpenMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    void LoadNextLevel()
    {
        LevelManager.Instance.LoadNextScene();
    }
}
