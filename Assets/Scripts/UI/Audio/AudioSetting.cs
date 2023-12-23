using System;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "AudioSetting", menuName = "ScriptableObjects/AudioSetting")]
public class AudioSetting : ScriptableObject
{

    [Header("Уровень музыки"), Range(0, 100)]
    public float MuzVol = 50f;
    [Header("Уровень эффектов"), Range(0, 100)]
    public float EfectVol = 50f;

    [Header("Звуковой файл - кнопка")]
    public AudioClip AudioClipButton;

    [Header("Звуковой файл - фон")]
    public AudioClip AudioClipGnd;

}
