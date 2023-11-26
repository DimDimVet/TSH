using UnityEngine;
[CreateAssetMenu(fileName = "ShootSettings", menuName = "ScriptableObjects/ShootSettings")]
public class ShootSettings : ScriptableObject
{
    [Header("����� ����������� ����")]
    public float CurrentTime = 5f;
    [Header("��� ����������(Player - true)")]
    public bool IsInputPlayer = false;
    
    [Header("��������")]
    public bool IsUpDate = false;
}
