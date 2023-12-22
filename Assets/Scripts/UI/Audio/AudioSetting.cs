using UnityEngine;

[CreateAssetMenu(fileName = "AudioSetting", menuName = "ScriptableObjects/AudioSetting")]
public class AudioSetting : ScriptableObject
{
    [Header("������� ������"), Range(0,100)]
    public float muzVol=50f;
    [Header("������� ��������"), Range(0, 100)]
    public float efectVol=50f;
}
