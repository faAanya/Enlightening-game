using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D RB;
    public PlayerInputHandler InputHandler { get; private set; }
    
    public StateMachine StateMachine { get; private set; }

    public float health;
    public float movementSpeed;

    private void Awake()
    {
        InputHandler = GetComponent<PlayerInputHandler>();
    }

    void Start()
    {
        StateMachine = new StateMachine(this);
        RB = GetComponent<Rigidbody2D>();
        StateMachine.Initialize(StateMachine.PlayerIdleState);
    }

    void Update()
    {
        StateMachine.Update();
    }
    
}
