using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class MainMenuController : MonoBehaviour
{

    [Header("Buttons")]
    public Button startButton;
    public Button settingsButton;
    public Button quitButton;
    public Button Level1;
    public Button Level2;

    [Header("UI")]

    public GameObject[] UIs;
    public GameObject Settings;

    [Header("Collection")]

    public GameObject Collection;


    public Button Accept;

    [Header("LevelChooser")]
    public GameObject LevelChooser;

    [Header("Bools")]

    public bool settingsOpened;


    public bool isTitle;
    public bool isCollection;

    public bool isLevelChooser;


    void Start()
    {

        isTitle = true;
        isCollection = false;
        isLevelChooser = false;


        settingsOpened = false;
        Settings.SetActive(settingsOpened);


        startButton.onClick.AddListener(() => { MoveMainButtons(0, 450, 0, 0); });
        settingsButton.onClick.AddListener(() =>
        {
            settingsOpened = !settingsOpened;
            Settings.SetActive(settingsOpened);
        });
        Level1.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("SampleScene 1");
            AudioManager.Instance.SetMusicScene(1);
        });
        Level2.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("SampleScene 2");
            AudioManager.Instance.SetMusicScene(2);
        });
        quitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
        Accept.onClick.AddListener(() =>
        {
            MoveLevelChooser(-800, 0, 0, 0);
        });


    }

    public void MoveMainButtons(int dirX1, int dirY1, int dirX2, int dirY2)
    {
        isTitle = false;
        isCollection = true;
        UIs[0].GetComponent<RectTransform>().anchoredPosition = new Vector3(dirX1, dirY1);
        UIs[1].GetComponent<RectTransform>().anchoredPosition = new Vector3(dirX2, dirY2);

    }
    public void MoveLevelChooser(int dirX1, int dirY1, int dirX2, int dirY2)
    {
        isCollection = false;
        isLevelChooser = true;

        UIs[1].GetComponent<RectTransform>().anchoredPosition = new Vector3(dirX1, dirY1);
        LevelChooser.GetComponent<RectTransform>().anchoredPosition = new Vector3(dirX2, dirY2);


        LevelChooser.SetActive(true);

    }
}
