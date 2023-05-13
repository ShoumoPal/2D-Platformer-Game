using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button restartButton;
    public Button quitButton;
    private void Awake()
    {
        restartButton.onClick.AddListener(RestartLevel);
        quitButton.onClick.AddListener(QuitLevel);
    }
    public void PlayerHasDied()
    { 
        gameObject.SetActive(true);
    }
    void RestartLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }
    void QuitLevel()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
