using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjectStstistic", menuName = "ScriptableObjects/ScriptableObjectStstistic")]
public class ScriptableObjectStstistic : ScriptableObject
{
    public void SaveStat(Statistic stat)
    {
        PlayerPrefs.SetInt("CountCost", stat.CountCost);
    }
    public Statistic LoadStat()
    {
        Statistic temp = new Statistic();
        temp.CountCost = PlayerPrefs.GetInt("CountCost");
        return temp;
    }
}
