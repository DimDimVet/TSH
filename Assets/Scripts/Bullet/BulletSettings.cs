using UnityEngine;

[CreateAssetMenu(fileName = "BulletSettings", menuName = "ScriptableObjects/BulletSettings")]
public class BulletSettings : ScriptableObject
{
    [Header("true-������� �� HealtPlayer, false-������� �� HealtEnemy")]
    public bool IsHealt = false;
    [Header("��� ����")]
    public TypeBullet TypeBullet;
    [Header("�������� ����")]
    public float SpeedBullet = 5f;
    [Header("����� ����� ����")]
    public float KillTime = 5f;
    [Header("�����")]
    public float Damage = 1f;
    [Header("������� ������������ ������"), Range(0, 100)]
    public float PercentDamage = 50f;

    [Header("��������")]
    public bool IsUpDate = false;
}
