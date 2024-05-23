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
            if (mainMenuController.isCollection)
            {
                mainMenuController.MoveMainButtons(0, 0, 0, -450);

                mainMenuController.isCollection = false;
                mainMenuController.isLevelChooser = false;
                mainMenuController.isTitle = true;

            }
            else if (mainMenuController.isLevelChooser)
            {
                mainMenuController.MoveLevelChooser(0, 0, -800, 0);
                // mainMenuController.MoveMainButtons(0, 0, 0, -450);
                mainMenuController.isTitle = false;
                mainMenuController.isLevelChooser = false;
                mainMenuController.isCollection = true;
                pressCounter = 0;
            }
            else
            {
                pressCounter = 0;
            }
        }
    }

}
