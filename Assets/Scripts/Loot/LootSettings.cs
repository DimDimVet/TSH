using UnityEngine;

[CreateAssetMenu(fileName = "LootSettings", menuName = "ScriptableObjects/LootSettings")]
public class LootSettings : ScriptableObject
{
    [Header("true-триггер по HealtPlayer, false-триггер по HealtEnemy")]
    public bool IsHealt = false;
    [Header("Здоровье")]
    public float Healt = 1f;

    [Header("Обновить")]
    public bool IsUpDate = false;
}
