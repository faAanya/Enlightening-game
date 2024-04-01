using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    [Header("Buttons")]
    public Button resumeButton;
    public Button quitButton;
    public Button settingsButton;


    [Header("Other")]
    public bool settingsOpened;
    public GameObject Settings;
    void Start()
    {
        settingsOpened = false;
        Settings.SetActive(settingsOpened);
        resumeButton.onClick.AddListener(() => { PauseMenuUI.OnPauseDisable.Invoke(); });
        quitButton.onClick.AddListener(() => { Time.timeScale = 1; SceneManager.LoadScene("Main Menu"); AudioManager.Instance.SetMusicScene(0); });
        settingsButton.onClick.AddListener(() =>
        {
            settingsOpened = !settingsOpened;
            Settings.SetActive(settingsOpened);
    });
    }
}
