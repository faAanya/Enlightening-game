using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{

 
    [HideInInspector] public PlayerController player;
    private PlayerInput playerInput;

    public Vector2 RawMovementInput { get; private set; }
    public Vector2 RawDashDirectionInput { get; private set; }
    public Vector2Int DashDirectionInput { get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }

    public Vector2 InputVector;

    public PlayerDataSO playerDataSO;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>(); 
        player = GetComponent<PlayerController>();
    }

    public void OnMoveInput(InputAction.CallbackContext context)

    {
        RawMovementInput = context.ReadValue<Vector2>();
        if (Math.Abs(RawMovementInput.x) < 0.5f)
        {
            NormInputX = 0;
        }
        else
        {
            if (RawMovementInput.x < 0) NormInputX = -1;
            else NormInputX = 1;
        }
        if (Math.Abs(RawMovementInput.y) < 0.5f)
        {
            NormInputY = 0;
        }
        else
        {
            if (RawMovementInput.y < 0) NormInputY = -1;
            else NormInputY = 1;
        }

        InputVector = new Vector2(NormInputX, NormInputY);
    }

    public void OnDashInput()
    {
        Debug.Log("Dash");
    }


 
}
