using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class PlayerController : MonoBehaviour
{
    // Gravity
    [SerializeField] private float _baseGravity = 2;
    public float LocalGravity { get; private set;}

    // Player input system
    public PlayerInputActions Input { get; private set; }
    public Vector2 MoveInput { get; private set; }
    public bool JumpPressed { get; private set; }

    // Reference to physics components
    public Rigidbody2D Rb { get; private set; }
    public BoxCollider2D BCol { get; private set; }

    // Reference to script components
    public PlayerMovement Movement { get; private set; }
    public PlayerAction Action { get; private set; }
    public MovementStateMachine MoveMachine { get; private set; }
    public ActionStateMachine ActionMachine { get; private set; }
    public PlayerHealthManager PlayerHealth { get; private set; }

    // Happens on gameObject awake (aka first thing that happens before Start())
    private void Awake()
    {
        // Input
        Input = new PlayerInputActions();
        // Sets the references once
        CacheComponents();
        // References Control for components once
        Initialization();
    }

    // Sets references
    private void CacheComponents() 
    {
        // Physics references
        Rb = GetComponent<Rigidbody2D>()
            ?? throw new Exception($"Missing {(nameof(Rigidbody2D))}");
        BCol = GetComponent<BoxCollider2D>()
            ?? throw new Exception($"Missing {(nameof(BoxCollider2D))}");

        // Script references
        Movement = GetComponent<PlayerMovement>()
            ?? throw new Exception($"Missing {(nameof(PlayerMovement))}");
        Action = GetComponent<PlayerAction>()
            ?? throw new Exception($"Missing {(nameof(PlayerAction))}");
        MoveMachine = GetComponent<MovementStateMachine>()
            ?? throw new Exception($"Missing {(nameof(MovementStateMachine))}");
        ActionMachine = GetComponent<ActionStateMachine>()
            ?? throw new Exception($"Missing {(nameof(ActionStateMachine))}");
        PlayerHealth = GetComponent<PlayerHealthManager>()
            ?? throw new Exception($"Missing {(nameof(PlayerHealthManager))}");
    }

    private void InitializeComponent<T>(T component) where T : IPlayerComponent
    {
        component.Initialize(this);
    }

    // Sets PlayerController.cs
    private void Initialization()
    {
        // Initializes PlayerController for these:
        InitializeComponent(Movement);
        InitializeComponent(Action);
        InitializeComponent(MoveMachine);
        InitializeComponent(ActionMachine);
        InitializeComponent(PlayerHealth);

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

    private void OnEnable()
    {
        Input.Player.Enable();

        input.Player.Move.performed += OnMove;
        input.Player.Move.canceled += OnMove;

        Control.Input.Player.Jump.performed += OnJump;
        Control.Input.Player.Jump.canceled += OnJump;
    }

    private void OnDisable()
    {
        input.Player.Move.performed -= OnMove;
        input.Player.Move.canceled -= OnMove;

        Control.Input.Player.Jump.performed -= OnJump;
        Control.Input.Player.Jump.canceled -= OnJump;
        
        Input.Player.Disable();
    }

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
        
    }

    private void FixedUpdate()
    {
        MoveMachine.FixedUpdate();
    }

}