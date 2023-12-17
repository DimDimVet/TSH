using UnityEngine;

[CreateAssetMenu(fileName = "HealtSettings", menuName = "ScriptableObjects/HealtSettings")]
public class HealtSetting : ScriptableObject
{
    [Header("Уровень здоровья")]
    public int HealtCount = 1000;
    //[Header("Скорость назад")]
    //public float SpeedBack = 1f;
    //[Header("Скорость поворота")]
    //public float SpeedTurn = 0.1f;
}
