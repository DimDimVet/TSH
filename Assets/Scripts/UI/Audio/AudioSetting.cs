using UnityEngine;

[CreateAssetMenu(fileName = "AudioSetting", menuName = "ScriptableObjects/AudioSetting")]
public class AudioSetting : ScriptableObject
{
    [Header("������� ��������")]
    public int HealtCount = 1000;
    [Header("��������� �������")]
    public int CostObject = 1;
    //[Header("�������� ��������")]
    //public float SpeedTurn = 0.1f;
}
