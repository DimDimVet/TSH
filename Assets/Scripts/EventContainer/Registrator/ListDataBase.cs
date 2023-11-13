using System.Collections.Generic;
using UnityEngine;

public abstract class ListDataBase : MonoBehaviour
{
    private readonly static List<Construction> data=new List<Construction>();

    public void SetData(Construction registrator)
    {
        data.Add(registrator);
    }
    public List<Construction> GetData()
    {
        return data;
    }
    public bool ClearData()
    {
        data.Clear();
        if (data.Count == 0) { return true; } else { return false; }
    }
}
