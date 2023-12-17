using UnityEngine;

[CreateAssetMenu(fileName = "TurnSettings", menuName = "ScriptableObjects/TurnSettings")]
public class TurnSettings : ScriptableObject
{
    [Header("�������� ��������")]
    public float SpeedTurn = 5f;

    [Header("��������")]
    public bool IsUpDate = false;

    [Header("�������� �� �(���. �� ����� 0.007)")]
    public float MaxOffSetX = 0.007f;
}
