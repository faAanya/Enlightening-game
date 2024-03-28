using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIInputHandler : MonoBehaviour
{
    private PlayerInput uiInputs;
    private static UIInputHandler Instance;

    public MainMenuController mainMenuController;
    public void OnMenuMove(InputAction.CallbackContext context)
    {

        Debug.Log("Pressed");
        mainMenuController.Invoke("MoveMainButtons", 0.0001f);
        mainMenuController.Invoke("MoveLevelChooser", 0.0001f);
        mainMenuController.StartCoroutine(mainMenuController.MoveMainButtons(0, -2.35f));
        mainMenuController.StartCoroutine(mainMenuController.MoveLevelChooser(3.5f, 0f)); ;
        //mainMenuController.StartCoroutine(mainMenuController.MoveLevelChooser(+7f, 0f));
        //        mainMenuController.StartCoroutine(mainMenuController.MoveMainButtons(0, -7f));

    }
}
