using UnityEngine;

[CreateAssetMenu(fileName = "HealtSettings", menuName = "ScriptableObjects/HealtSettings")]
public class HealtSetting : ScriptableObject
{
    [Header("�������� ������")]
    public float SpeedForward = 1f;
    [Header("�������� �����")]
    public float SpeedBack = 1f;
    [Header("�������� ��������")]
    public float SpeedTurn = 0.1f;
}
