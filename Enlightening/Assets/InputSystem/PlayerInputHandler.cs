using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{

    private PlayerInput playerInput;
    public Player player;

    public Vector2 RawMovementInput { get; private set; }
    public Vector2 RawDashDirectionInput { get; private set; }
    public Vector2Int DashDirectionInput { get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }

    public Vector2 InputVector;
    public float moveSpeed;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>(); 
        player = GetComponent<Player>();
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

        Debug.Log(RawMovementInput);
        NormInputX = (int)(RawMovementInput * Vector2.right).normalized.x;
        NormInputY = (int)(RawMovementInput * Vector2.up).normalized.y;
        InputVector = new Vector2(NormInputX, NormInputY);
        player.RB.velocity = InputVector * 10;
        Debug.Log(InputVector);

        //player.InputHandler.InputVector.Normalize();
        //    player.totalSpeed = 4 * player.InputHandler.moveSpeed;
        //   
        //    player.InputHandler.moveSpeed = Mathf.Clamp(player.InputHandler.InputVector.magnitude, 0.0f, 1.0f);
        
    }
}
