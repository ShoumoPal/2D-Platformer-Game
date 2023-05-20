using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

    public string[] levels;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        for(int i = 0; i< levels.Length; i++)
        {
            SetLevelStatus(levels[i], LevelStatus.Locked);
        }
        if (GetLevelStatus(levels[0]) == LevelStatus.Locked)
        {
            SetLevelStatus(levels[0], LevelStatus.Unlocked);
        }
    }

    public void LoadAnyLevel(int levelNumber)
    {
        SceneManager.LoadScene(levelNumber);
    }
    public void LoadNextScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        int currentSceneIndex = Array.FindIndex(levels, level => level == currentScene.name);
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex < levels.Length)
        {
            SceneManager.LoadScene(nextSceneIndex + 1);
        }
        else
        {
            Debug.Log("All levels completed!");
        }
    }
    public void MarkCurrentLevelComplete()
    {
        //set level complete
        Scene currentScene = SceneManager.GetActiveScene();
        LevelManager.Instance.SetLevelStatus(currentScene.name, LevelStatus.Completed);

        //unlock next level

        //int nextSceneIndex = scene.buildIndex + 1;
        //Scene nextScene = SceneManager.GetSceneByBuildIndex(nextSceneIndex);
        //LevelManager.Instance.SetLevelStatus(nextScene.name, LevelStatus.Unlocked);

        int currentSceneIndex = Array.FindIndex(levels, level => level == currentScene.name);
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex < levels.Length)
        {
            SetLevelStatus(levels[nextSceneIndex], LevelStatus.Unlocked);
        }
    }
    public LevelStatus GetLevelStatus(string level)
    {
        LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(level, 0);
        return levelStatus;
    }
    public void SetLevelStatus(string level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);
        Debug.Log("Set level: " + level + " to :" + levelStatus);
    }
}
