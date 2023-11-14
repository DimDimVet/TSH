using UnityEngine;

[CreateAssetMenu(fileName = "BulletSettings", menuName = "ScriptableObjects/BulletSettings")]
public class BulletSettings : ScriptableObject
{
    [Header("Скорость пули")]
    public float SpeedBullet = 5f;
    [Header("Время жизни пули")]
    public float KillTime = 5f;

    [Header("Обновить")]
    public bool IsUpDate = false;
}
