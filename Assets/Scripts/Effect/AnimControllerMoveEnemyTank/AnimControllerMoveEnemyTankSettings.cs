using UnityEngine;

[CreateAssetMenu(fileName = "MoveEnemyTankSettings", menuName = "ScriptableObjects/MoveEnemyTankSettings")]
public class AnimControllerMoveEnemyTankSettings : ScriptableObject
{
    [Header("Скорость проигрывания")]
    public float SpeedAnim = 1f;
    [Header("Гусеница назад")]
    public string TankEnemyTrackBack = "";
    [Header("Гусеница вперед")]
    public string TankEnemyTrackForward = "";
    [Header("Гусеница влево")]
    public string TankEnemyTrackLeft = "";
    [Header("Гусеница вправо")]
    public string TankEnemyTrackRight = "";

    [Header("Обновить")]
    public bool IsUpDate = false;
}
