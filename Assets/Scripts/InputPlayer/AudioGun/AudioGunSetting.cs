using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGunSetting : ScriptableObject
{
    [Header("Звуковой файл - gun Player")]
    public AudioClip AudioClipGunPlayer;
    [Header("Звуковой файл - gun Enemy")]
    public AudioClip AudioClipGunEnemy;
    [Header("Звуковой файл - AutoGun")]
    public AudioClip AudioClipAutoGun;

}
