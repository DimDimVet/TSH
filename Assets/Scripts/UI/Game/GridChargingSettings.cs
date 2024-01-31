using UnityEngine;

[CreateAssetMenu(fileName = "GridChargingSettings", menuName = "ScriptableObjects/GridChargingSettings")]
public class GridChargingSettings : ScriptableObject
{
    [Header("Настройки сетки - режим Сharging")]
    public int SpacingXСharging = 0;
    public int SpacingYСharging = 0;
    [Header("Настройки сетки - режим Gun")]
    public int SpacingXGun = 0;
    public int SpacingYGun = 0;
    [Header("Настройки сетки - режим Rif")]
    public int SpacingXRif = 0;
    public int SpacingYRif = 0;
}
