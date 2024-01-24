using System.Collections.Generic;
using UnityEngine;
using static EventBus;

public class TesterList : MonoBehaviour
{
    [Header("Получить и вывести в консоль лист")]
    public bool IsDate = false;

    void Update()
    {
        if (IsDate) { GetTestList(); IsDate = false; }
    }
    private void GetTestList()
    {
        List<Construction> tempList = GetList();
        print($"count={tempList.Count}");
        for (int i = 0; i < tempList.Count; i++) 
        {
            print($"{tempList[i].Hash} - {tempList[i].CameraComponent}");
        }
    }

}
