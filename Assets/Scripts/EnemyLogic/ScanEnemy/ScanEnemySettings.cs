using UnityEngine;

[CreateAssetMenu(fileName = "ScanEnemySettings", menuName = "ScriptableObjects/ScanEnemySettings")]
public class ScanEnemySettings : ScriptableObject
{
    [Header("������� ����������")]
    public float DimCollider = 15f;

    [Header("��������")]
    public bool IsUpDate = false;
}
