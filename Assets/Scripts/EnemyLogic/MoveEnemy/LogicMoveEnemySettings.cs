using UnityEngine;

[CreateAssetMenu(fileName = "LogicMoveEnemySettings", menuName = "ScriptableObjects/LogicMoveEnemySettings")]
public class LogicMoveEnemySettings : ScriptableObject
{
    [Header("Скорость движения")]
    public float SpeedMove = 5f;
    [Header("Ускорение")]
    public float Acceleration = 7f;
    [Header("Скорость поворота")]
    public float SpeedAngle = 120f;
    [Header("Стоп дистанция до цели")]
    public float StopDistance = 15f;

    [Header("Обновить")]
    public bool IsUpDate = false;
}
