using UnityEngine;

[CreateAssetMenu(fileName = "AnimatorPlayerSettings", menuName = "ScriptableObjects/AnimatorPlayerSettings")]
public class AnimControllerMovePlayerSettings : ScriptableObject
{
    [Header("�������� ������������")]
    public float SpeedAnim = 1f;
    [Header("�������� �����")]
    public string TankPlayerTrackBack = "";
    [Header("�������� ������")]
    public string TankPlayerTrackForward = "";
    [Header("�������� �����")]
    public string TankPlayerTrackLeft = "";
    [Header("�������� ������")]
    public string TankPlayerTrackRight = "";

    [Header("��������")]
    public bool IsUpDate = false;

}
