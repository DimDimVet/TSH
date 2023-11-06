using UnityEngine;

[CreateAssetMenu(fileName = "TurnSettings", menuName = "ScriptableObjects/TurnSettings")]
public class TurnSettings : ScriptableObject
{
    [Header("Скорость вращения")]
    public float SpeedTurn = 2f;
    [Header("Вес башни(реком. 10)")]
    public float WeightTurn = 10f;
    //[Header("Сила движения(зависимость от веса)")]
    //public float ForceMove = 50000f;
    //[Header("Сила поворота(зависимость от веса)")]
    //public float ForceTurn = 40000f;

    [Header("Обновить")]
    public bool IsUpDate = false;
}
