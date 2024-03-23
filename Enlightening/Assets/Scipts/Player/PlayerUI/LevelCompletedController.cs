using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using Unity.VisualScripting;

public class LevelCompletedController : MonoBehaviour
{
    [Header("Buttons")]
    public Button quitButton;
    public LevelsSO levelsSO;

    void Start()
    {

        quitButton.onClick.AddListener(() => { Time.timeScale = 1; OpenNextLevel(); SceneManager.LoadScene("Main Menu"); });
    }
    public void OpenNextLevel()
    {
        Debug.Log("Level opened");
        for (int i = 0; i < levelsSO.openedLevels.Length; i++)
        {

            if (!levelsSO.openedLevels[i])
            {
                levelsSO.openedLevels[i] = !levelsSO.openedLevels[i];
                break;
            }

        }

    }
}
