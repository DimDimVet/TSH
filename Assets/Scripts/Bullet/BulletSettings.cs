using UnityEngine;

[CreateAssetMenu(fileName = "BulletSettings", menuName = "ScriptableObjects/BulletSettings")]
public class BulletSettings : ScriptableObject
{
    [Header("�������� ����")]
    public float SpeedBullet = 5f;
    [Header("����� ����� ����")]
    public float KillTime = 5f;

    [Header("��������")]
    public bool IsUpDate = false;
}
