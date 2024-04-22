using UnityEngine;
using UnityEngine.InputSystem;

public class UIInputHandler : MonoBehaviour
{
    private PlayerInput uiInputs;
    private static UIInputHandler Instance;

    public MainMenuController mainMenuController;

    private int pressCounter = 0;
    public void OnMenuMove(InputAction.CallbackContext context)
    {
        Debug.Log("Pressed");
        if (context.started)
        {
            pressCounter++;
            if (pressCounter == 1 && mainMenuController.isLevelChooser)
            {
                mainMenuController.MoveLevelChooser(0, 0, 800, 0);
                mainMenuController.isCollection = true;
                mainMenuController.isLevelChooser = false;
            }
            else if (pressCounter == 2 && mainMenuController.isCollection)
            {
                mainMenuController.MoveMainButtons(0, 0, 0, -450);
                mainMenuController.isTitle = true;
                mainMenuController.isCollection = false;
                pressCounter = 0;
            }
            else
            {
                pressCounter = 0;
            }
        }
    }

}
