public class MovementStateMachine
{
    // Stores current state
    private IState _currentState; 

    // References
    public PlayerController Control { get; private set; }

    // Initializes the state machine along with setting it to idle
    public void Initialize(PlayerController playerController)
    {
        Control = playerController;
        _currentState = new IdleState();
        _currentState.Enter(playerController);
    }

    // Name says it all
    public void ChangeState(IState newState)
    {
        _currentState.Exit(Control);
        _currentState = newState;
        _currentState.Enter(Control);
    }

    // Updates state logic via Update()
    public void Update()
    {
        _currentState.Update(PlayerController playerController);
    }

    // Updates state logic via FixedUpdate();
    public void FixedUpdate()
    {
        _currentState.FixedUpdate(PlayerController playerController);
    }
}