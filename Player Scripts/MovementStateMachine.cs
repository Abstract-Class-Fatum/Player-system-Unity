public class MovementStateMachine : IPlayerComponent
{
    // Stores current state
    private IState _currentState; 

    // Cached states
    public IdleState IdleState { get; private set; }
    public RunState RunState { get; private set; }

    // References
    public PlayerController Control { get; private set; }

    // Initializes the state machine and cached states along with setting it to idle
    public void Initialize(PlayerController playerController)
    {
        Control = playerController;

        IdleState = new IdleState();
        RunState  = new RunState();

        ChangeState(IdleState);
    }

    // Name says it all
    public void ChangeState(IState newState)
    {
        if (newState == null)
            throw new Exception()

        if (newState == _currentState) return;

        _currentState?.Exit(Control);
        _currentState = newState;
        _currentState.Enter(Control);
    }

    // Updates state logic via Update()
    public void Update()
    {
        _currentState.Update(Control);
    }

    // Updates state logic via FixedUpdate();
    public void FixedUpdate()
    {
        _currentState.FixedUpdate(Control);
    }
}