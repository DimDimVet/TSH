using UnityEngine;

[CreateAssetMenu(fileName = "TurnSettings", menuName = "ScriptableObjects/TurnSettings")]
public class TurnSettings : ScriptableObject
{
    [Header("�������� ��������")]
    public float SpeedTurn = 2f;
    [Header("��� �����(�����. 10)")]
    public float WeightTurn = 10f;
    //[Header("���� ��������(����������� �� ����)")]
    //public float ForceMove = 50000f;
    //[Header("���� ��������(����������� �� ����)")]
    //public float ForceTurn = 40000f;

    [Header("��������")]
    public bool IsUpDate = false;
}
