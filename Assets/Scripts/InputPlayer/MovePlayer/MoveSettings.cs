using UnityEngine;

[CreateAssetMenu(fileName = "MoveSettings", menuName = "ScriptableObjects/MoveSettings")]
public class MoveSettings : ScriptableObject
{
    [Header("��������� ��������")]
    public float SpeedMove = 100f;

    //[Header("��������� ������")]
    //public float Force = 1f;
    //public float Height = 1f;

    [Header("������� ���� GND")]
    public LayerMask GroundLayer;

    [Header("�������� �������")]
    public float ShootDelay = 1f;
}
