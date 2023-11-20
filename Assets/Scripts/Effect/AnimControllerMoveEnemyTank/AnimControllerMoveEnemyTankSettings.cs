using UnityEngine;

[CreateAssetMenu(fileName = "MoveEnemyTankSettings", menuName = "ScriptableObjects/MoveEnemyTankSettings")]
public class AnimControllerMoveEnemyTankSettings : ScriptableObject
{
    [Header("�������� ������������")]
    public float SpeedAnim = 1f;
    [Header("�������� �����")]
    public string TankEnemyTrackBack = "";
    [Header("�������� ������")]
    public string TankEnemyTrackForward = "";
    [Header("�������� �����")]
    public string TankEnemyTrackLeft = "";
    [Header("�������� ������")]
    public string TankEnemyTrackRight = "";

    [Header("��������")]
    public bool IsUpDate = false;
}
