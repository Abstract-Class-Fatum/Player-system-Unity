using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class PlayerController : MonoBehaviour
{
    // Gravity
    [SerializeField] private float _baseGravity = 2;
    public float LocalGravity { get; private set;}

    // Raycasts
    public bool IsGrounded { get; private set; }

    // Player input system
    public PlayerInput Input { get; private set; }
    public Vector2 MoveInput { get; private set; }
    public bool JumpPressed { get; private set; }

    // Reference to physics components
    public Rigidbody2D Rb { get; private set; }
    public BoxCollider2D BCol { get; private set; }

    // Reference to player stats SO
    [SerializeField] private PlayerStatsSO _playerStats;
    public PlayerStatsSO PlayerStats
    {
        get => _playerStats;
        private set
        {
            if (value != null)
                _playerStats = value;
            else
                throw new InvalidOperationException($"Missing {(nameof(PlayerStatsSO))}");
        }
    }

    // Reference to script components
    public PlayerMovement Movement { get; private set; }
    public PlayerAction Action { get; private set; }
    public MovementStateMachine MoveMachine { get; private set; }
    public ActionStateMachine ActionMachine { get; private set; }
    public PlayerHealthManager PlayerHealth { get; private set; }

    // Happens on gameObject awake (aka first thing that happens before Start())
    private void Awake()
    {
        // Sets the references once
        CacheComponents();
        // References Control for components once
        Initialization();
    }

    // Sets references
    private void CacheComponents() 
    {
        // Physics references
        Rb = GetComponent<Rigidbody2D>();
        BCol = GetComponent<BoxCollider2D>();
        Input = GetComponent<PlayerInput>();

        // Script references
        Movement = new PlayerMovement()
            ?? throw new Exception($"Missing {(nameof(PlayerMovement))}");
        Action = new PlayerAction()
            ?? throw new Exception($"Missing {(nameof(PlayerAction))}");
        MoveMachine = new MovementStateMachine()
            ?? throw new Exception($"Missing {(nameof(MovementStateMachine))}");
        ActionMachine = new ActionStateMachine()
            ?? throw new Exception($"Missing {(nameof(ActionStateMachine))}");
        PlayerHealth = new PlayerHealthManager()
            ?? throw new Exception($"Missing {(nameof(PlayerHealthManager))}");
    }

    // More consistent initialization naming
    private void InitializeScript<T>(T script) where T : IPlayerScript
    {
        script.Initialize(this, PlayerStats);
    }

    // Sets PlayerController.cs
    private void Initialization()
    {
        // Initializes PlayerController for these:
        InitializeScript(Movement);
        InitializeScript(Action);
        InitializeScript(MoveMachine);
        InitializeScript(ActionMachine);
        InitializeScript(PlayerHealth);

        // Sets other properties/variables
        InitializeVariables();
        InitializeProperties();
    }

    private void InitializeVariables()
    {
        
    }

    private void InitializeProperties()
    {
        // Sets pressing jump to false
        JumpPressed = false;
        // Sets local gravity to base on startup
        LocalGravity = _baseGravity;
    }

    // Subscibing to events
    //private void OnEnable()
    //{
    //    Input.currentActionMap.Enable();

    //    Input. += OnMove;
    //    Input.Player.Move.canceled += OnMove;

    //    Input.Player.Jump.performed += OnJump;
    //    Input.Player.Jump.canceled += OnJump;
    //}

    //// Unsubscribing to events
    //private void OnDisable()
    //{
    //    Input.Move.performed -= OnMove;
    //    Input.Player.Move.canceled -= OnMove;

    //    Input.Player.Jump.performed -= OnJump;
    //    Input.Player.Jump.canceled -= OnJump;

    //    Input.Player.Disable();
    //}

    private void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed) // only when button is pressed
            JumpPressed = true;
        else if (context.canceled) // only when button is released
            JumpPressed = false;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();

        if (context.canceled)
            MoveInput = Vector2.zero;
    }

    private void Update()
    {
        MoveMachine.Update();
    }

    private void FixedUpdate()
    {
        MoveMachine.FixedUpdate();
    }
}