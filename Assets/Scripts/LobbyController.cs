using UnityEngine;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button playButton;
    public GameObject levelSelectionScreen;

    private void Awake()
    {
        playButton.onClick.AddListener(PlayLevel);
    }
    private void PlayLevel()
    {
        playButton.gameObject.SetActive(false);
        levelSelectionScreen.SetActive(true);
    }
}
