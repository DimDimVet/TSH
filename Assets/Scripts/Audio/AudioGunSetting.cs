using UnityEngine;

[CreateAssetMenu(fileName = "AudioGunSetting", menuName = "ScriptableObjects/AudioGunSetting")]
public class AudioGunSetting : ScriptableObject
{
    [Header("Звуковой файл - gun")]
    public AudioClip AudioClipGun;
}
