using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class MainMenuButtonsController : MonoBehaviour
{

    [Header("Buttons")]
    public Button startButton;
    public Button quitButton;

    public Button Level1;

    [Header("UI")]

    public GameObject MainButtons;
    public GameObject LevelChooser;


    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(() => { StartCoroutine(MoveMainButtons()); });
        Level1.onClick.AddListener(() => { SceneManager.LoadScene("SampleScene"); });
        quitButton.onClick.AddListener(() => { Application.Quit(); });

    }

    public IEnumerator MoveMainButtons()
    {
        for (int i = 0; i <= 950; i++)
        {
            MainButtons.transform.position = new Vector3(MainButtons.transform.position.x, MainButtons.transform.position.y + 2.5f);
            yield return new WaitForSeconds(.0005f);
        }
        LevelChooser.SetActive(true);

    }
}
