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
    public GameObject LevelChooser;

    public GameObject Title;


    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(() => { StartCoroutine(MoveMainButtons()); });
        Level1.onClick.AddListener(() => { SceneManager.LoadScene("SampleScene 1"); });
        Level2.onClick.AddListener(() => { SceneManager.LoadScene("SampleScene 2"); });
        quitButton.onClick.AddListener(() => { Application.Quit(); });
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
        LevelChooser.SetActive(true);

    }
}
