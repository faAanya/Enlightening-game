using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class MainMenuController : MonoBehaviour
{
    public GameObject Title;
    [Header("Buttons")]
    public Button startButton;
    public Button quitButton;
    public Button Level1;
    public Button Level2;

    [Header("UI")]

    public GameObject[] UIs;

    [Header("Collection")]

    public GameObject Collection;


    public Button Accept;

    [Header("LevelChooser")]
    public GameObject LevelChooser;

    [Header("Bools")]
    public bool isTitle;
    public bool isCollection;

    public bool isLevelChooser;


    void Start()
    {
        startButton.onClick.AddListener(() => { StartCoroutine(MoveMainButtons(0f, 7f)); });
        Level1.onClick.AddListener(() => { SceneManager.LoadScene("SampleScene 1"); AudioManager.Instance.SetMusicScene(1); });
        Level2.onClick.AddListener(() => { SceneManager.LoadScene("SampleScene 2"); AudioManager.Instance.SetMusicScene(2); });
        quitButton.onClick.AddListener(() => { Application.Quit(); });
        Accept.onClick.AddListener(() => { StartCoroutine(MoveLevelChooser(-7f, 0f)); StartCoroutine(MoveMainButtons(0f, 7f)); });
    }

    public IEnumerator MoveMainButtons(float dirX, float dirY)
    {
        for (int i = 0; i <= 160; i++)
        {
            for (int j = 0; j < UIs.Length; j++)
            {
                UIs[j].transform.position = new Vector3(UIs[j].transform.position.x + dirX, UIs[j].transform.position.y + dirY);
            }

            yield return null;
        }
    }
    public IEnumerator MoveLevelChooser(float dirX, float dirY)
    {

        for (int i = 0; i <= 280; i++)
        {

            LevelChooser.transform.position = new Vector3(LevelChooser.transform.position.x + dirX, LevelChooser.transform.position.y + dirY);


            yield return null;
        }
        LevelChooser.SetActive(true);

    }
}
