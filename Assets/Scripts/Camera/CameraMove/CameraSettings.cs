using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CameraSettings", menuName = "ScriptableObjects/CameraSettings")]
public class CameraSettings : ScriptableObject
{
    [Header("Установка по оси X")]
    public float AxesX = 0f;
    [Header("Установка по оси Y")]
    public float AxesY = 0f;
    [Header("Установка по оси Z")]
    public float AxesZ = -30f;
    [Header("Дистанция включения триггера")]
    public float LimitZ = 10f, LimitX=10f;
    [Header("Скорость перемещения камеры")]
    public float SpeedMove=2f;

    [Header("Обновить")]
    public bool IsUpDate= false;

}
