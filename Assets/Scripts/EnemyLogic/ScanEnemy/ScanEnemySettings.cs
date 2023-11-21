using UnityEngine;

[CreateAssetMenu(fileName = "ScanEnemySettings", menuName = "ScriptableObjects/ScanEnemySettings")]
public class ScanEnemySettings : ScriptableObject
{
    [Header("Диаметр коллайдера")]
    public float DimCollider = 40f;
    [Header("Множитель диаметра по событию")]
    public float KfCollider = 2f;

    [Header("Обновить")]
    public bool IsUpDate = false;
}
