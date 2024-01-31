using UnityEngine;

[CreateAssetMenu(fileName = "BulletSettings", menuName = "ScriptableObjects/BulletSettings")]
public class BulletSettings : ScriptableObject
{
    [Header("true-триггер по HealtPlayer, false-триггер по HealtEnemy")]
    public bool IsHealt = false;
    [Header("Тип пули")]
    public TypeBullet TypeBullet;
    [Header("Скорость пули")]
    public float SpeedBullet = 5f;
    [Header("Время жизни пули")]
    public float KillTime = 5f;
    [Header("Дамаг")]
    public float Damage = 1f;
    [Header("Процент критического дамага"), Range(0, 100)]
    public float PercentDamage = 50f;

    [Header("Обновить")]
    public bool IsUpDate = false;
}
