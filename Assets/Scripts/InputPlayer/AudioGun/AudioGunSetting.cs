using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGunSetting : ScriptableObject
{
    [Header("�������� ���� - gun Player")]
    public AudioClip AudioClipGunPlayer;
    [Header("�������� ���� - gun Enemy")]
    public AudioClip AudioClipGunEnemy;
    [Header("�������� ���� - AutoGun")]
    public AudioClip AudioClipAutoGun;

}
