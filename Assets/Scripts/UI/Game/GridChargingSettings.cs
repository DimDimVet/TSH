using UnityEngine;

[CreateAssetMenu(fileName = "GridChargingSettings", menuName = "ScriptableObjects/GridChargingSettings")]
public class GridChargingSettings : ScriptableObject
{
    [Header("��������� ����� - ����� �harging")]
    public int SpacingX�harging = 0;
    public int SpacingY�harging = 0;
    [Header("��������� ����� - ����� Gun")]
    public int SpacingXGun = 0;
    public int SpacingYGun = 0;
    [Header("��������� ����� - ����� Rif")]
    public int SpacingXRif = 0;
    public int SpacingYRif = 0;
}
