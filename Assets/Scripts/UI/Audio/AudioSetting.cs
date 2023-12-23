using System;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "AudioSetting", menuName = "ScriptableObjects/AudioSetting")]
public class AudioSetting : ScriptableObject
{

    [Header("������� ������"), Range(0, 100)]
    public float MuzVol = 50f;
    [Header("������� ��������"), Range(0, 100)]
    public float EfectVol = 50f;

    [Header("�������� ���� - ������")]
    public AudioClip AudioClipButton;

    [Header("�������� ���� - ���")]
    public AudioClip AudioClipGnd;

}
