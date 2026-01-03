public class MovementStateMachine
{
    // Stores current state
    IState = _currentState; 

    // References
    public PlayerController Control { get; private set; }

    // Initializes the state machine along with setting it to idle
    public void Initialize(PlayerController player)
    {
        Control = player;
        _currentState = new IdleState();
        _currentState.Enter(player);
    }

    // Name says it all
    public void ChangeState(IState newState)
    {
        _currentState.Exit(player);
        _currentState = newState;
        _currentState.Enter(player);
    }

    // Updates state logic via Update()
    public void Update()
    {
        _currentState.Update();
    }

    // Updates state logic via FixedUpdate();
    public void FixedUpdate()
    {
        _currentState.FixedUpdate();
    }
}