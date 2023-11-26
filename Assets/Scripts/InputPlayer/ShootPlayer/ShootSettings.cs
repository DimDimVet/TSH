using UnityEngine;
[CreateAssetMenu(fileName = "ShootSettings", menuName = "ScriptableObjects/ShootSettings")]
public class ShootSettings : ScriptableObject
{
    [Header("Время перезарядки пули")]
    public float CurrentTime = 5f;
    [Header("Тип управления(Player - true)")]
    public bool IsInputPlayer = false;
    
    [Header("Обновить")]
    public bool IsUpDate = false;
}
