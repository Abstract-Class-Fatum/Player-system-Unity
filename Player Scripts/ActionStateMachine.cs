public class ActionStateMachine
{
    // Stores current state
    private IActionState _currentState;

    // Cached states
    public NoActionState NoActionState { get; private set; }
    public DashState DashState { get; private set; }
    public JumpState JumpState { get; private set; }

    // References
    public PlayerController Control { get; private set; }

    // Initializes Player controller and sets state
    public void Initialize(PlayerController playerController)
    {
        Control = playerController;

        NoActionState = new NoActionState();
        DashState = new DashState();
        JumpState = new JumpState();
    }

    public void ChangeState(IActionState newState)
    {
        _currentState.Exit();
        _currentState = newState;
        _currentState.Enter();
    }

    public void Update()
    {
        _currentState.Update(Control);
    }

    public void FixedUpdate()
    {
        _currentState.FixedUpdate(Control);
    }
}