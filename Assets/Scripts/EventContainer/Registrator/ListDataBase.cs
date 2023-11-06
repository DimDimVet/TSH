using System.Collections.Generic;
using UnityEngine;

public abstract class ListDataBase : MonoBehaviour
{
    private readonly static List<Construction> data=new List<Construction>();
    /// <summary>
    /// Запишем в лист
    /// </summary>
    /// <param name="registrator"></param>
    public void SetData(Construction registrator)
    {
        data.Add(registrator);
    }
    /// <summary>
    /// Получим лист
    /// </summary>
    /// <returns></returns>
    public List<Construction> GetData()
    {
        return data;
    }
    /// <summary>
    /// Очистим лист
    /// </summary>
    /// <returns></returns>
    public bool ClearData()
    {
        data.Clear();
        if (data.Count == 0) { return true; } else { return false; }
    }
}
