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

    public int iLevel;

    public GameObject Map;

    void Start()
    {
        iLevel = 1;
        quitButton.onClick.AddListener(() => { Time.timeScale = 1; OpenNextLevel(); AudioManager.Instance.SetMusicScene(0); SceneManager.LoadScene("Main Menu"); });
    }
    public void OpenNextLevel()
    {
        Debug.Log("Level opened");
        // for (int i = 0; i < levelsSO.openedLevels.Length; i++)
        // {

        //     if (!levelsSO.openedLevels[i])
        //     {
        //         levelsSO.openedLevels[i] = !levelsSO.openedLevels[i];
        //         break;
        //     }

        // }

    }


}

