public interface IPlayerComponent
{
    PlayerController Control { get; }
    PlayerStats playerStats { get; }
    void Initialize(PlayerController playerController, PlayerStats playerStats);
}