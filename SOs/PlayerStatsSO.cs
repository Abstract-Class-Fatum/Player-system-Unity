using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatsSO", menuName = "Scriptable Objects/PlayerStatsSO")]
public class PlayerStatsSO : ScriptableObject
{
    // Movement
    public int baseMoveSpeed;

    // Action
    public int baseJumpPower;

    // Health
    public int baseHealth;
}
