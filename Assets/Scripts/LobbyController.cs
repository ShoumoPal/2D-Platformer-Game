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
        SoundManager.Instance.PlayBGMusic();
        SoundManager.Instance.Play(Sounds.ButtonClick);
        playButton.gameObject.SetActive(false);
        levelSelectionScreen.SetActive(true);
    }
}
