using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class MainMenuController : MonoBehaviour
{

    [Header("Buttons")]
    public Button startButton;
    public Button quitButton;

    public Button Level1;
    public Button Level2;

    [Header("UI")]

    public GameObject[] UIs;
    public GameObject Collection;
    public Button Accept;
    public GameObject LevelChooser;

    public GameObject Title;


    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(() => { StartCoroutine(MoveMainButtons()); });
        Level1.onClick.AddListener(() => { SceneManager.LoadScene("SampleScene 1"); });
        Level2.onClick.AddListener(() => { SceneManager.LoadScene("SampleScene 2"); });
        quitButton.onClick.AddListener(() => { Application.Quit(); });
        Accept.onClick.AddListener(() => StartCoroutine(MoveLevelChooser()));
    }

    public IEnumerator MoveMainButtons()
    {
        for (int i = 0; i <= 150; i++)
        {
            for (int j = 0; j < UIs.Length; j++)
            {
                UIs[j].transform.position = new Vector3(UIs[j].transform.position.x, UIs[j].transform.position.y + 7f);
            }

            yield return null;
        }
        Collection.SetActive(true);

    }
    public IEnumerator MoveLevelChooser()
    {
        Collection.SetActive(false);
        for (int i = 0; i <= 280; i++)
        {

            LevelChooser.transform.position = new Vector3(LevelChooser.transform.position.x - 7f, LevelChooser.transform.position.y);


            yield return null;
        }
        LevelChooser.SetActive(true);

    }
}
