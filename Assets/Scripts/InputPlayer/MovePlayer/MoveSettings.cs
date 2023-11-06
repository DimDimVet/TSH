using UnityEngine;

[CreateAssetMenu(fileName = "MoveSettings", menuName = "ScriptableObjects/MoveSettings")]
public class MoveSettings : ScriptableObject
{
    [Header("Скорость вперед")]
    public float SpeedForward = 1f;
    [Header("Скорость назад")]
    public float SpeedBack = 1f;
    [Header("Скорость поворота")]
    public float SpeedTurn = 0.1f;

    [Header("Вес машины(реком. 50)")]
    public float Weight = 50f;
    [Header("Сила движения(зависимость от веса)")]
    public float ForceMove = 50000f;
    [Header("Сила поворота(зависимость от веса)")]
    public float ForceTurn = 40000f;

    [Header("Указать слой GND")]
    public LayerMask GroundLayer;

    [Header("Задержка нажатия")]
    public float ShootDelay = 1f;

    [Header("Обновить")]
    public bool IsUpDate = false;
}
