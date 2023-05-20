using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button button;
    public string levelName;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(LoadLevel);
    }
    private void LoadLevel()
    {
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(levelName);
        switch (levelStatus)
        {
            case LevelStatus.Locked:
                SoundManager.Instance.Play(Sounds.DisabledButton);
                Debug.Log("Level currently locked");
                break;
            case LevelStatus.Unlocked:
                SoundManager.Instance.Play(Sounds.ButtonClick);
                Debug.Log("Level currently unlocked");
                SceneManager.LoadScene(levelName);
                break;
            case LevelStatus.Completed:
                SoundManager.Instance.Play(Sounds.ButtonClick);
                Debug.Log("Level currently completed");
                SceneManager.LoadScene(levelName);
                break;
        }
    }
}
