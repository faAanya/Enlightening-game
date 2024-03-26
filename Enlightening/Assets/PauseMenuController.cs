using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    [Header("Buttons")]
    public Button resumeButton;
    public Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        resumeButton.onClick.AddListener(() => { PauseMenuUI.OnPauseDisable.Invoke(); });
        quitButton.onClick.AddListener(() => { Time.timeScale = 1; SceneManager.LoadScene("Main Menu"); });
    }
}
