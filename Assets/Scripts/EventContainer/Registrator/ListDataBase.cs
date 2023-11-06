using System.Collections.Generic;
using UnityEngine;

public abstract class ListDataBase : MonoBehaviour
{
    private readonly static List<Construction> data=new List<Construction>();
    /// <summary>
    /// ������� � ����
    /// </summary>
    /// <param name="registrator"></param>
    public void SetData(Construction registrator)
    {
        data.Add(registrator);
    }
    /// <summary>
    /// ������� ����
    /// </summary>
    /// <returns></returns>
    public List<Construction> GetData()
    {
        return data;
    }
    /// <summary>
    /// ������� ����
    /// </summary>
    /// <returns></returns>
    public bool ClearData()
    {
        data.Clear();
        if (data.Count == 0) { return true; } else { return false; }
    }
}
