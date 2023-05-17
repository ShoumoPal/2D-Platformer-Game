using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelController : MonoBehaviour
{
    public GameObject levelOverUI;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Level completed!");
            collision.gameObject.GetComponent<PlayerController>().enabled = false;
            levelOverUI.SetActive(true);
            LevelManager.Instance.MarkCurrentLevelComplete();
        }
    }
}
