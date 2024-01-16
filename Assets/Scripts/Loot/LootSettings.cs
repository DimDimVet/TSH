using UnityEngine;

[CreateAssetMenu(fileName = "LootSettings", menuName = "ScriptableObjects/LootSettings")]
public class LootSettings : ScriptableObject
{
    [Header("true-������� �� HealtPlayer, false-������� �� HealtEnemy")]
    public bool IsHealt = false;
    [Header("��������")]
    public float Healt = 1f;

    [Header("��������")]
    public bool IsUpDate = false;
}
