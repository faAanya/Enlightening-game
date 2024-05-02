using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using Unity.VisualScripting;
using TMPro;

public class LevelCompletedController : MonoBehaviour
{
    [Header("Buttons")]
    public Button quitButton;
    public Button restartButton;
    public LevelsSO levelsSO;

    public TMP_Text earnedMoney;

    public int iLevel;

    public GameObject Map;



    void Start()
    {
        iLevel = 1;
        restartButton.onClick.AddListener(() => { Time.timeScale = 1; SceneManager.LoadScene(SceneManager.GetActiveScene().name); });
        quitButton.onClick.AddListener(() => { Time.timeScale = 1; OpenNextLevel(); AudioManager.Instance.SetMusicScene(0); SceneManager.LoadScene("Main Menu"); });
    }
    public void OpenNextLevel()
    {
        Debug.Log("Level opened");
        for (int i = 0; i < levelsSO.openedLevels.Length; i++)
        {

            if (levelsSO.openedLevels[i] == false)
            {
                levelsSO.openedLevels[i] = true;
                break;
            }

        }

    }


}

