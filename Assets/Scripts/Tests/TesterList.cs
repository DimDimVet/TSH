using System.Collections.Generic;
using UnityEngine;
using static EventManager;

public class TesterList : MonoBehaviour
{
    [Header("�������� � ������� � ������� ����")]
    public bool IsDate = false;

    void Update()
    {
        if (IsDate) { GetTestList(); IsDate = false; }
    }
    private void GetTestList()
    {
        List<Construction> tempList = GetList();
        for (int i = 0; i < tempList.Count; i++) 
        {
            print($"{tempList[i].Hash}");
        }
    }

}
