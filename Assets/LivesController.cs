using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LivesController : MonoBehaviour
{
    private TextMeshProUGUI livesText;
    private PlayerController playerController;
    private void Awake()
    {
        livesText = GetComponent<TextMeshProUGUI>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    private void Update()
    {
        UpdateLives();
    }
    void UpdateLives()
    {
        livesText.text = "Lives : " + playerController.lives;
    }
}
