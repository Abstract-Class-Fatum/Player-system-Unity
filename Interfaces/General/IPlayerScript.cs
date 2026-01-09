public interface IPlayerScript
{
    PlayerController Control { get; }
    PlayerStatsSO Stats { get; }
    void Initialize(PlayerController playerController, PlayerStatsSO playerStatsSO);
}