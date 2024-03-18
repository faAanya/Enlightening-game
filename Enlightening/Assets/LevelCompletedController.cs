using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class LevelCompletedController : MonoBehaviour
{
    [Header("Buttons")]
    public Button quitButton;
    void Start()
    {
        quitButton.onClick.AddListener(() => { Time.timeScale = 1; SceneManager.LoadScene("Main Menu"); });
    }
    public void OpenNextLevel()
    {
        foreach (var item in LevelController.LevelManager.ButtonDict.Keys.ToList())
        {
            if (LevelController.LevelManager.ButtonDict[item])
            {
                if (!item.interactable)
                {
                    item.interactable = true;
                    Debug.Log("LevelOpened");
                }

            }
        }

    }
}
