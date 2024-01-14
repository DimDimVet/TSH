using UnityEngine;
using UnityEngine.UI;

public class LogicRezultPanel : LogicPanel
{
    [Header("��������� ScriptableObjectStstistic")]
    [SerializeField] private ScriptableObjectStstistic scriptableObjectStstistic;
    [Header("��������� ��������� ����")]
    [SerializeField] private Text rezultText;
    [SerializeField] private string dopText;
    private Statistic statistic;

    public override void SetPanel()
    {
        statistic = scriptableObjectStstistic.LoadStat();
        rezultText.text = $"{dopText} \n{statistic.CountCost}";
    }
}
