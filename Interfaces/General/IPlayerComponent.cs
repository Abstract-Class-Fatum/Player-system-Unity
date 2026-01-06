public interface IPlayerComponent
{
    PlayerController Control { get; }
    void Initialize(PlayerController playerController);
}