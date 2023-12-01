using UnityEngine;

[CreateAssetMenu(fileName = "ScanEnemySettings", menuName = "ScriptableObjects/ScanEnemySettings")]
public class ScanEnemySettings : ScriptableObject
{
    [Header("������� ����������")]
    public float DiametrCollider = 40f;
    [Header("��������� �������� �� �������")]
    public float KfCollider = 2f;

    [Header("��������")]
    public bool IsUpDate = false;
}
