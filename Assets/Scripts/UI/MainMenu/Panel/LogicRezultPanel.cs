using UnityEngine;
using UnityEngine.UI;

public class LogicRezultPanel : LogicPanel
{
    [Header("Подключим ScriptableObjectStstistic")]
    [SerializeField] private ScriptableObjectStstistic scriptableObjectStstistic;
    [Header("Подключим текстовое поле")]
    [SerializeField] private Text rezultText;
    [SerializeField] private string dopText;
    private Statistic statistic;

    public override void SetPanel()
    {
        statistic = scriptableObjectStstistic.LoadStat();
        rezultText.text = $"{dopText} \n{statistic.CountCost}";
    }
}
