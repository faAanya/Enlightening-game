using UnityEngine;
using UnityEngine.InputSystem;

public class UIInputManager : MonoBehaviour
{
    private PlayerInput playerInput;

    public void OnPauseMenuINput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (Time.timeScale != 0)
            {
                PauseMenuUI.OnPauseEnable.Invoke();
            }
            else
            {
                PauseMenuUI.OnPauseDisable.Invoke();
            }
        }

    }
}
