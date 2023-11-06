using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CameraSettings", menuName = "ScriptableObjects/CameraSettings")]
public class CameraSettings : ScriptableObject
{
    [Header("��������� �� ��� X")]
    public float AxesX = 0f;
    [Header("��������� �� ��� Y")]
    public float AxesY = 0f;
    [Header("��������� �� ��� Z")]
    public float AxesZ = -30f;
    [Header("��������� ��������� ��������")]
    public float LimitZ = 10f, LimitX=10f;
    [Header("�������� ����������� ������")]
    public float SpeedMove=2f;

    [Header("��������")]
    public bool IsUpDate= false;

}
