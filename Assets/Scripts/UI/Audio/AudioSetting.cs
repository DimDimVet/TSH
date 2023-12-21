using UnityEngine;

[CreateAssetMenu(fileName = "AudioSetting", menuName = "ScriptableObjects/AudioSetting")]
public class AudioSetting : ScriptableObject
{
    [Header("Уровень здоровья")]
    public int HealtCount = 1000;
    [Header("Стоимость объекта")]
    public int CostObject = 1;
    //[Header("Скорость поворота")]
    //public float SpeedTurn = 0.1f;
}
