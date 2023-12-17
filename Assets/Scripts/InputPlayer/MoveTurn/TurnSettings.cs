using UnityEngine;

[CreateAssetMenu(fileName = "TurnSettings", menuName = "ScriptableObjects/TurnSettings")]
public class TurnSettings : ScriptableObject
{
    [Header("Скорость вращения")]
    public float SpeedTurn = 5f;

    [Header("Обновить")]
    public bool IsUpDate = false;

    [Header("Смещение по Х(рек. не более 0.007)")]
    public float MaxOffSetX = 0.007f;
}
