using UnityEngine;
[CreateAssetMenu(fileName = "ShootSettings", menuName = "ScriptableObjects/ShootSettings")]
public class ShootSettings : ScriptableObject
{
    [Header("Время перезарядки пули")]
    public float CurrentTime = 5f;

    [Header("Обновить")]
    public bool IsUpDate = false;
}
